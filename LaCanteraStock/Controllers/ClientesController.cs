using LaCanteraStock.AccesoDatos;
using LaCanteraStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LaCanteraStock.Controllers
{
    public class ClientesController : Controller
    {
        private readonly BDContexto _context;

        public ClientesController(BDContexto context)
        {
            _context = context;
        }

        // Desplegable de tipos de documento
        private void CargarTiposDocumento()
        {
            ViewBag.ListaTipos = new SelectList(
                _context.TiposDocumento.ToList(), "TipoDocumentoID", "Nombre");
        }

        // Nombres de los tipos de documento para mostrarlos
        private void CargarNombres()
        {
            ViewBag.TiposDocumento = _context.TiposDocumento
                .ToDictionary(t => t.TipoDocumentoID, t => t.Nombre);
        }

        public IActionResult Index()
        {
            CargarNombres();
            var lista = _context.Clientes.ToList();
            return View(lista);
        }

        public IActionResult Details(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();
            CargarNombres();
            return View(cliente);
        }

        public IActionResult Create()
        {
            CargarTiposDocumento();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                CargarTiposDocumento();
                return View(cliente);
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();
            CargarTiposDocumento();
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                CargarTiposDocumento();
                return View(cliente);
            }

            _context.Clientes.Update(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();
            CargarNombres();
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();

            try
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("",
                    "No se puede eliminar: este cliente tiene ventas registradas.");
                CargarNombres();
                return View(cliente);
            }
        }
    }
}
