using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudRazorCore.Models;

namespace CrudRazorCore.Controllers
{
    public class AsesoresController : Controller
    {
        private readonly DualDBContext _context;

        public AsesoresController(DualDBContext context)
        {
            _context = context;
        }

        // GET: Asesores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Asesores.ToListAsync());
        }

        // GET: Asesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var asesor = await _context.Asesores
                .FirstOrDefaultAsync(m => m.Id_Asesor == id);

            if (asesor == null) return NotFound();

            return View(asesor);
        }

        // GET: Asesores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asesores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Asesor asesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asesor);
        }

        // GET: Asesores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var asesor = await _context.Asesores.FindAsync(id);
            if (asesor == null) return NotFound();

            return View(asesor);
        }

        // POST: Asesores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Asesor asesor)
        {
            if (id != asesor.Id_Asesor) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Asesores.Any(e => e.Id_Asesor == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(asesor);
        }

        // GET: Asesores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var asesor = await _context.Asesores
                .FirstOrDefaultAsync(m => m.Id_Asesor == id);

            if (asesor == null) return NotFound();

            return View(asesor);
        }

        // POST: Asesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asesor = await _context.Asesores.FindAsync(id);
            if (asesor != null)
            {
                _context.Asesores.Remove(asesor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
