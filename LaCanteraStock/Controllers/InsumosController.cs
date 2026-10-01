using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaCanteraStock.AccesoDatos;
using LaCanteraStock.Models;

namespace LaCanteraStock.Controllers
{
    public class InsumosController : Controller
    {
        private readonly BDContexto _context;

        public InsumosController(BDContexto context)
        {
            _context = context;
        }

        //DETALLES DE CONFECCIÓN (principal)
        public async Task<IActionResult> Index()
        {
            var lista = await _context.DetallesConfeccion
                .Include(d => d.Categoria)
                .Include(d => d.Tela)
                .Include(d => d.Talla)
                .Include(d => d.TipoEstampado)
                .OrderByDescending(d => d.FechaRegistro)
                .ToListAsync();

            ViewBag.TotalRegistros = lista.Count;
            ViewBag.TotalTelas = await _context.Telas.CountAsync(t => t.Activo);
            ViewBag.TotalCategorias = await _context.Categorias.CountAsync(c => c.Activo);

            return View(lista);
        }

        public async Task<IActionResult> Create()
        {
            await CargarCombos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DetalleConfeccion model)
        {
            if (ModelState.IsValid)
            {
                model.FechaRegistro = DateTime.Now;
                _context.DetallesConfeccion.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await CargarCombos();
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.DetallesConfeccion.FindAsync(id);
            if (item == null) return NotFound();
            await CargarCombos(item);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DetalleConfeccion model)
        {
            if (id != model.DetalleConfeccionID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await CargarCombos(model);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.DetallesConfeccion
                .Include(d => d.Categoria)
                .Include(d => d.Tela)
                .Include(d => d.Talla)
                .Include(d => d.TipoEstampado)
                .FirstOrDefaultAsync(d => d.DetalleConfeccionID == id);

            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.DetallesConfeccion.FindAsync(id);
            if (item != null)
            {
                _context.DetallesConfeccion.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        //TELAS (insumos de tela)
        public async Task<IActionResult> Telas()
        {
            return View(await _context.Telas.OrderBy(t => t.Nombre).ToListAsync());
        }

        public IActionResult CreateTela()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTela(Tela tela)
        {
            if (ModelState.IsValid)
            {
                _context.Telas.Add(tela);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Telas));
            }
            return View(tela);
        }

        //Agregar EditTela/DeleteTela

        private async Task CargarCombos(DetalleConfeccion? model = null)
        {
            ViewBag.CategoriaID = new SelectList(await _context.Categorias.Where(c => c.Activo).ToListAsync(), "CategoriaID", "Nombre", model?.CategoriaID);
            ViewBag.TelaID = new SelectList(await _context.Telas.Where(t => t.Activo).ToListAsync(), "TelaID", "Nombre", model?.TelaID);
            ViewBag.TallaID = new SelectList(await _context.Tallas.ToListAsync(), "TallaID", "Nombre", model?.TallaID);
            ViewBag.TipoEstampadoID = new SelectList(await _context.TiposEstampado.ToListAsync(), "TipoEstampadoID", "Nombre", model?.TipoEstampadoID);
        }
    }
}