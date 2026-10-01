using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaCanteraStock.AccesoDatos;
using LaCanteraStock.Models;

namespace LaCanteraStock.Controllers
{
    public class InventarioController : Controller
    {
        private readonly BDContexto _context;

        public InventarioController(BDContexto context)
        {
            _context = context;
        }

        // GET: Inventario
        public async Task<IActionResult> Index()
        {
            var inventarios = await _context.ProductoTallas.ToListAsync();
            var productos = await _context.Productos.ToDictionaryAsync(p => p.ProductoID, p => p.Nombre);
            var tallas = await _context.Tallas.ToDictionaryAsync(t => t.TallaID, t => t.Nombre);

            ViewBag.Productos = productos;
            ViewBag.Tallas = tallas;

            return View(inventarios);
        }

        // GET: Inventario/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.ProductoID = new SelectList(await _context.Productos.ToListAsync(), "ProductoID", "Nombre");
            ViewBag.TallaID = new SelectList(await _context.Tallas.ToListAsync(), "TallaID", "Nombre");
            return View();
        }

        // POST: Inventario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoTalla productoTalla)
        {
            if (ModelState.IsValid)
            {
                _context.ProductoTallas.Add(productoTalla);
                await _context.SaveChangesAsync();

                if (productoTalla.StockActual > 0)
                {
                    var movimientoInicial = new MovimientoStock
                    {
                        ProductoTallaID = productoTalla.ProductoTallaID,
                        TipoMovimientoID = 1, // 1: Entrada Inicial
                        Cantidad = productoTalla.StockActual,
                        Fecha = DateTime.Now,
                        UsuarioID = 1, // Usuario por defecto / Admin
                        Observacion = "Ingreso de stock inicial"
                    };
                    _context.MovimientosStock.Add(movimientoInicial);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.ProductoID = new SelectList(await _context.Productos.ToListAsync(), "ProductoID", "Nombre", productoTalla.ProductoID);
            ViewBag.TallaID = new SelectList(await _context.Tallas.ToListAsync(), "TallaID", "Nombre", productoTalla.TallaID);
            return View(productoTalla);
        }

        // GET: Inventario/Movimientos
        public async Task<IActionResult> Movimientos()
        {
            var movimientos = await _context.MovimientosStock
                .OrderByDescending(m => m.Fecha)
                .ToListAsync();

            var productoTallas = await _context.ProductoTallas.ToDictionaryAsync(pt => pt.ProductoTallaID, pt => pt);
            var productos = await _context.Productos.ToDictionaryAsync(p => p.ProductoID, p => p.Nombre);
            var tallas = await _context.Tallas.ToDictionaryAsync(t => t.TallaID, t => t.Nombre);
            var tiposMovimiento = await _context.TiposMovimiento.ToDictionaryAsync(tm => tm.TipoMovimientoID, tm => tm.Nombre);

            ViewBag.ProductoTallas = productoTallas;
            ViewBag.Productos = productos;
            ViewBag.Tallas = tallas;
            ViewBag.TiposMovimiento = tiposMovimiento;

            return View(movimientos);
        }
    }
}