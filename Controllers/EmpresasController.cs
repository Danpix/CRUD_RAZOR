using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudRazorCore.Models;

namespace CrudRazorCore.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly DualDBContext _context;

        public EmpresasController(DualDBContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            var empresas = await _context.Empresas
                .Include(e => e.AsesorNav)
                .ToListAsync();

            return View(empresas);
        }

        // GET: Empresas/Details/ID
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var empresa = await _context.Empresas
                .Include(e => e.AsesorNav)
                .FirstOrDefaultAsync(m => m.RFC_Empresa == id);

            if (empresa == null) return NotFound();

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            ViewBag.Asesores = new SelectList(
                _context.Asesores.ToList(),
                "Id_Asesor",
                "Nombre_Asesor"
            );

            return View();
        }

        // POST: Empresas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Asesores = new SelectList(
                _context.Asesores.ToList(),
                "Id_Asesor",
                "Nombre_Asesor",
                empresa.Clave_Asesor
            );

            return View(empresa);
        }

        // GET: Empresas/Edit/RFC
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null) return NotFound();

            ViewBag.Asesores = new SelectList(
                _context.Asesores.ToList(),
                "Id_Asesor",
                "Nombre_Asesor",
                empresa.Clave_Asesor
            );

            return View(empresa);
        }

        // POST: Empresas/Edit/RFC
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Empresa empresa)
        {
            if (id != empresa.RFC_Empresa) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Empresas.Any(e => e.RFC_Empresa == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Asesores = new SelectList(
                _context.Asesores.ToList(),
                "Id_Asesor",
                "Nombre_Asesor",
                empresa.Clave_Asesor
            );

            return View(empresa);
        }

        // GET: Empresas/Delete/RFC
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var empresa = await _context.Empresas
                .Include(e => e.AsesorNav)
                .FirstOrDefaultAsync(m => m.RFC_Empresa == id);

            if (empresa == null) return NotFound();

            return View(empresa);
        }

        // POST: Empresas/Delete/RFC
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
