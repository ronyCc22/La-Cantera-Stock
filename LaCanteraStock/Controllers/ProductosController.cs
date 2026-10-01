using LaCanteraStock.AccesoDatos;
using LaCanteraStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LaCanteraStock.Controllers
{
    public class ProductosController : Controller
    {
        private readonly BDContexto _context;

        public ProductosController(BDContexto context)
        {
            _context = context;
        }

        // GET: Productos/Catalogo
        public IActionResult Catalogo(string? categoria, short? tallaId, string? buscar)
        {
            // 1. Base de productos activos
            var consulta = _context.Productos
                .Where(p => p.Activo)
                .AsQueryable();

            // 2. Filtro por Categoría (Camisetas / Shorts)
            if (!string.IsNullOrEmpty(categoria))
            {
                var cat = _context.Categorias.FirstOrDefault(c => c.Nombre.ToLower() == categoria.ToLower());
                if (cat != null)
                {
                    consulta = consulta.Where(p => p.CategoriaID == cat.CategoriaID);
                }
            }

            // 3. Filtro por buscador (Nombre o Descripción)
            if (!string.IsNullOrEmpty(buscar))
            {
                consulta = consulta.Where(p => p.Nombre.Contains(buscar) || p.Descripcion.Contains(buscar));
            }

            var productos = consulta.OrderBy(p => p.Nombre).ToList();
            var productoIds = productos.Select(p => p.ProductoID).ToList();

            // 4. Cargar existencias por talla de los productos encontrados
            var productoTallas = _context.ProductoTallas
                .Where(pt => productoIds.Contains(pt.ProductoID))
                .ToList();

            // 5. Filtro adicional por Talla específica (si el vendedor seleccionó una)
            if (tallaId.HasValue)
            {
                var idsConTallaDisponible = productoTallas
                    .Where(pt => pt.TallaID == tallaId.Value && pt.StockActual > 0)
                    .Select(pt => pt.ProductoID)
                    .Distinct()
                    .ToList();

                productos = productos.Where(p => idsConTallaDisponible.Contains(p.ProductoID)).ToList();
            }

            // 6. Enviar datos de soporte a la vista mediante ViewBag (respetando arquitectura estándar)
            ViewBag.Tallas = _context.Tallas.OrderBy(t => t.Orden).ToList();
            ViewBag.Categorias = _context.Categorias.Where(c => c.Activo).ToList();
            ViewBag.ProductosTallas = productoTallas;
            ViewBag.CategoriaSeleccionada = categoria;
            ViewBag.TallaSeleccionada = tallaId;
            ViewBag.Buscar = buscar;

            return View(productos);
        }

        // Prepara el desplegable de categorías
        private void CargarCategorias()
        {
            ViewBag.ListaCategorias = new SelectList(
                _context.Categorias.ToList(), "CategoriaID", "Nombre");
        }

        // Prepara los nombres de las categorías para mostrarlos
        private void CargarNombres()
        {
            ViewBag.Categorias = _context.Categorias
                .ToDictionary(c => c.CategoriaID, c => c.Nombre);
        }

        public IActionResult Index()
        {
            CargarNombres();
            var lista = _context.Productos.ToList();
            return View(lista);
        }

        public IActionResult Details(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();
            CargarNombres();
            return View(producto);
        }

        public IActionResult Create()
        {
            CargarCategorias();
            return View(new Producto { Activo = true });
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                CargarCategorias();
                return View(producto);
            }

            _context.Productos.Add(producto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();
            CargarCategorias();
            return View(producto);
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                CargarCategorias();
                return View(producto);
            }

            _context.Productos.Update(producto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();
            CargarNombres();
            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();

            try
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("",
                    "No se puede eliminar: este producto está en uso.");
                CargarNombres();
                return View(producto);
            }
        }
    }
}
