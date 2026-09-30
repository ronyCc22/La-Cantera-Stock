using LaCanteraStock.AccesoDatos;
using LaCanteraStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaCanteraStock.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly BDContexto _context;

        public CategoriasController(BDContexto context)
        {
            _context = context;
        }

        // Lista todas las categorías
        public IActionResult Index()
        {
            var lista = _context.Categorias.ToList();
            return View(lista);
        }

        // Muestra una categoría
        public IActionResult Details(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        // Muestra el formulario vacío
        public IActionResult Create()
        {
            return View(new Categoria { Activo = true });
        }

        // Guarda la categoría nueva
        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (!ModelState.IsValid) return View(categoria);

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Muestra el formulario con los datos actuales
        public IActionResult Edit(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        // Guarda los cambios
        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (!ModelState.IsValid) return View(categoria);

            _context.Categorias.Update(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Pide confirmación antes de eliminar
        public IActionResult Delete(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        // Elimina de verdad
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null) return NotFound();

            try
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("",
                    "No se puede eliminar: esta categoría está en uso.");
                return View(categoria);
            }
        }
    }
}
