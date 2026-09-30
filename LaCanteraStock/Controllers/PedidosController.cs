using LaCanteraStock.AccesoDatos;
using LaCanteraStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaCanteraStock.Controllers
{
    public class PedidosController : Controller
    {
        private readonly BDContexto _context;

        public PedidosController(BDContexto context)
        {
            _context = context;
        }

        // Desplegables del formulario de nueva venta
        private void CargarListasCreate()
        {
            ViewBag.ListaClientes = new SelectList(
                _context.Clientes.ToList(), "ClienteID", "NombreCompleto");

            ViewBag.ListaModalidades = new SelectList(
                _context.ModalidadesPedido.ToList(), "ModalidadID", "Nombre");
        }

        // Lista de productos con stock, para agregar a la venta
        private void CargarProductos()
        {
            var datos = (from pt in _context.ProductoTallas
                         join p in _context.Productos
                             on pt.ProductoID equals p.ProductoID
                         join t in _context.Tallas
                             on pt.TallaID equals t.TallaID
                         where p.Activo && pt.StockActual > 0
                         orderby p.Nombre, t.Orden
                         select new
                         {
                             pt.ProductoTallaID,
                             Producto = p.Nombre,
                             Talla = t.Nombre,
                             pt.StockActual
                         }).ToList();

            ViewBag.ListaProductos = datos.Select(d => new SelectListItem
            {
                Value = d.ProductoTallaID.ToString(),
                Text = d.Producto + " - " + d.Talla +
                       " (stock: " + d.StockActual + ")"
            }).ToList();
        }

        // Lista de todas las ventas
        public IActionResult Index()
        {
            ViewBag.Clientes = _context.Clientes
                .ToDictionary(c => c.ClienteID, c => c.NombreCompleto);

            ViewBag.Estados = _context.EstadosPedido
                .ToDictionary(e => e.EstadoPedidoID, e => e.Nombre);

            var lista = _context.Pedidos
                .OrderByDescending(p => p.PedidoID)
                .ToList();

            return View(lista);
        }

        // Formulario de nueva venta (parte MAESTRO)
        public IActionResult Create()
        {
            CargarListasCreate();
            return View();
        }

        // Guarda la boleta y pasa a agregar productos
        [HttpPost]
        public IActionResult Create(int clienteId, byte modalidadId,
                                    DateTime fechaEntrega, string observaciones)
        {
            int numero = _context.Pedidos.Count() + 1;

            var pedido = new Pedido
            {
                NumeroBoleta = "B" + numero.ToString("D6"),
                FechaEmision = DateTime.Now,
                FechaEntrega = fechaEntrega,
                ClienteID = clienteId,
                ModalidadID = modalidadId,
                EstadoPedidoID = 1,
                UsuarioID = 1,
                Observaciones = observaciones ?? "",
                Total = 0
            };

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = pedido.PedidoID });
        }

        // Muestra la boleta y sus productos (parte DETALLE)
        public IActionResult Details(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null) return NotFound();

            var cliente = _context.Clientes.Find(pedido.ClienteID);
            ViewBag.Cliente = cliente == null ? "" : cliente.NombreCompleto;

            ViewBag.Detalles = _context.DetallesPedido
                .Where(d => d.PedidoID == id)
                .ToList();

            CargarProductos();
            return View(pedido);
        }

        // Agrega un producto a la venta y descuenta el stock
        [HttpPost]
        public IActionResult AgregarDetalle(int pedidoId, int productoTallaId,
                                            int cantidad)
        {
            if (cantidad <= 0)
            {
                TempData["Error"] = "La cantidad debe ser mayor a 0.";
                return RedirectToAction("Details", new { id = pedidoId });
            }

            var pedido = _context.Pedidos.Find(pedidoId);
            var productoTalla = _context.ProductoTallas.Find(productoTallaId);
            if (pedido == null || productoTalla == null) return NotFound();

            var producto = _context.Productos.Find(productoTalla.ProductoID);
            var talla = _context.Tallas.Find(productoTalla.TallaID);
            if (producto == null || talla == null) return NotFound();

            // Regla: no se puede vender más de lo que hay
            if (productoTalla.StockActual < cantidad)
            {
                TempData["Error"] = "Stock insuficiente. Disponible: " +
                                    productoTalla.StockActual;
                return RedirectToAction("Details", new { id = pedidoId });
            }

            // 1) La línea de la venta
            var detalle = new DetallePedido
            {
                PedidoID = pedidoId,
                ProductoTallaID = productoTallaId,
                Descripcion = producto.Nombre + " - " + talla.Nombre,
                Cantidad = cantidad,
                PrecioUnitario = producto.PrecioUnitario,
                Subtotal = cantidad * producto.PrecioUnitario
            };
            _context.DetallesPedido.Add(detalle);

            // 2) Descontar el stock
            productoTalla.StockActual -= cantidad;

            // 3) Sumar al total de la boleta
            pedido.Total += detalle.Subtotal;

            // 4) Anotar la salida en el historial
            var movimiento = new MovimientoStock
            {
                ProductoTallaID = productoTallaId,
                TipoMovimientoID = 2,
                Cantidad = cantidad,
                Fecha = DateTime.Now,
                PedidoID = pedidoId,
                UsuarioID = 1,
                Observacion = "Venta " + pedido.NumeroBoleta
            };
            _context.MovimientosStock.Add(movimiento);

            // Se guarda todo junto: o se guarda todo, o nada
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = pedidoId });
        }
    }
}
