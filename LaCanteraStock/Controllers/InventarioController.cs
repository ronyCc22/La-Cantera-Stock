using LaCanteraStock.AccesoDatos;
using LaCanteraStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaCanteraStock.Controllers
{
    public class InventarioController : Controller
    {
        private readonly BDContexto _context;

        public InventarioController(BDContexto context)
        {
            _context = context;
        }

        // Desplegables de productos y tallas
        private void CargarListas()
        {
            ViewBag.ListaProductos = new SelectList(
                _context.Productos.ToList(), "ProductoID", "Nombre");

            ViewBag.ListaTallas = new SelectList(
                _context.Tallas.OrderBy(t => t.Orden).ToList(),
                "TallaID", "Nombre");
        }

        // Stock actual de cada producto y talla
        public IActionResult Index()
        {
            ViewBag.Productos = _context.Productos
                .ToDictionary(p => p.ProductoID, p => p.Nombre);

            ViewBag.Tallas = _context.Tallas
                .ToDictionary(t => t.TallaID, t => t.Nombre);

            var lista = _context.ProductoTallas.ToList();
            return View(lista);
        }

        // Formulario para asignar una talla a un producto
        public IActionResult Create()
        {
            CargarListas();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductoTalla productoTalla)
        {
            bool yaExiste = _context.ProductoTallas.Any(x =>
                x.ProductoID == productoTalla.ProductoID &&
                x.TallaID == productoTalla.TallaID);

            if (yaExiste)
                ModelState.AddModelError("",
                    "Ese producto ya tiene esa talla registrada.");

            if (productoTalla.StockActual < 0 || productoTalla.StockMinimo < 0)
                ModelState.AddModelError("",
                    "El stock no puede ser negativo.");

            if (!ModelState.IsValid)
            {
                CargarListas();
                return View(productoTalla);
            }

            _context.ProductoTallas.Add(productoTalla);
            _context.SaveChanges();

            // Si empieza con stock, se anota como una Entrada
            if (productoTalla.StockActual > 0)
            {
                var movimiento = new MovimientoStock
                {
                    ProductoTallaID = productoTalla.ProductoTallaID,
                    TipoMovimientoID = 1,
                    Cantidad = productoTalla.StockActual,
                    Fecha = DateTime.Now,
                    UsuarioID = 1,
                    Observacion = "Stock inicial"
                };
                _context.MovimientosStock.Add(movimiento);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // Historial de entradas y salidas de stock
        public IActionResult Movimientos()
        {
            var nombres = (from pt in _context.ProductoTallas
                           join p in _context.Productos
                               on pt.ProductoID equals p.ProductoID
                           join t in _context.Tallas
                               on pt.TallaID equals t.TallaID
                           select new
                           {
                               pt.ProductoTallaID,
                               Nombre = p.Nombre + " - " + t.Nombre
                           }).ToList();

            ViewBag.Nombres = nombres
                .ToDictionary(x => x.ProductoTallaID, x => x.Nombre);

            ViewBag.Tipos = _context.TiposMovimiento
                .ToDictionary(t => t.TipoMovimientoID, t => t.Nombre);

            var lista = _context.MovimientosStock
                .OrderByDescending(m => m.Fecha)
                .ToList();

            return View(lista);
        }
    }
}
