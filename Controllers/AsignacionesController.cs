using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudRazorCore.Models;

namespace CrudRazorCore.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly DualDBContext _context;

        public AsignacionesController(DualDBContext context)
        {
            _context = context;
        }

        // GET: Asignaciones
        public async Task<IActionResult> Index()
        {
            var lista = _context.Asignaciones
                .Include(a => a.AlumnoNav)
                .Include(a => a.EmpresaNav)
                .Include(a => a.AsesorNav);

            return View(await lista.ToListAsync());
        }

        // GET: Asignaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var asignacion = await _context.Asignaciones
                .Include(a => a.AlumnoNav)
                .Include(a => a.EmpresaNav)
                .Include(a => a.AsesorNav)
                .FirstOrDefaultAsync(m => m.Id_Asignacion == id);

            if (asignacion == null) return NotFound();

            return View(asignacion);
        }

        // --------- helpers combos ----------
        private void CargarCombos(Asignacion? asignacion = null)
        {
            ViewBag.Alumnos = new SelectList(
                _context.Alumnos.ToList(),
                "Matricula",
                "Nombre",
                asignacion?.Matricula_Alumno
            );

            ViewBag.Empresas = new SelectList(
                _context.Empresas.ToList(),
                "RFC_Empresa",
                "Nombre_Empresa",
                asignacion?.RFC_Empresa
            );

            ViewBag.Asesores = new SelectList(
                _context.Asesores.ToList(),
                "Id_Asesor",
                "Nombre_Asesor",
                asignacion?.Id_Asesor
            );
        }

        // GET: Asignaciones/Create
        public IActionResult Create()
        {
            CargarCombos();
            return View();
        }

        // POST: Asignaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            CargarCombos(asignacion);
            return View(asignacion);
        }

        // GET: Asignaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null) return NotFound();

            CargarCombos(asignacion);
            return View(asignacion);
        }

        // POST: Asignaciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Asignacion asignacion)
        {
            if (id != asignacion.Id_Asignacion) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Asignaciones.Any(e => e.Id_Asignacion == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            CargarCombos(asignacion);
            return View(asignacion);
        }

        // GET: Asignaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var asignacion = await _context.Asignaciones
                .Include(a => a.AlumnoNav)
                .Include(a => a.EmpresaNav)
                .Include(a => a.AsesorNav)
                .FirstOrDefaultAsync(m => m.Id_Asignacion == id);

            if (asignacion == null) return NotFound();

            return View(asignacion);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion != null)
            {
                _context.Asignaciones.Remove(asignacion);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
