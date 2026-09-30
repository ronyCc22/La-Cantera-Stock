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
