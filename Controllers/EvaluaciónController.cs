using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asp.Models;

namespace asp.Controllers
{
    public class EvaluaciónController : Controller
    {
        private readonly EscuelaContext _context;

        public EvaluaciónController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Evaluación
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.Evaluación.Include(e => e.Alumno).Include(e => e.Asignatura);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: Evaluación/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluación = await _context.Evaluación
                .Include(e => e.Alumno)
                .Include(e => e.Asignatura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluación == null)
            {
                return NotFound();
            }

            return View(evaluación);
        }

        // GET: Evaluación/Create
        public IActionResult Create()
        {
            ViewData["AlumnoId"] = new SelectList(_context.Alumno, "Id", "Id");
            ViewData["AsignaturaId"] = new SelectList(_context.Asignatura, "Id", "Id");
            return View();
        }

        // POST: Evaluación/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlumnoId,AsignaturaId,Nota,Id,Nombre")] Evaluación evaluación)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluación);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumno, "Id", "Id", evaluación.AlumnoId);
            ViewData["AsignaturaId"] = new SelectList(_context.Asignatura, "Id", "Id", evaluación.AsignaturaId);
            return View(evaluación);
        }

        // GET: Evaluación/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluación = await _context.Evaluación.FindAsync(id);
            if (evaluación == null)
            {
                return NotFound();
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumno, "Id", "Id", evaluación.AlumnoId);
            ViewData["AsignaturaId"] = new SelectList(_context.Asignatura, "Id", "Id", evaluación.AsignaturaId);
            return View(evaluación);
        }

        // POST: Evaluación/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AlumnoId,AsignaturaId,Nota,Id,Nombre")] Evaluación evaluación)
        {
            if (id != evaluación.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluación);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluaciónExists(evaluación.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumno, "Id", "Id", evaluación.AlumnoId);
            ViewData["AsignaturaId"] = new SelectList(_context.Asignatura, "Id", "Id", evaluación.AsignaturaId);
            return View(evaluación);
        }

        // GET: Evaluación/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluación = await _context.Evaluación
                .Include(e => e.Alumno)
                .Include(e => e.Asignatura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluación == null)
            {
                return NotFound();
            }

            return View(evaluación);
        }

        // POST: Evaluación/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var evaluación = await _context.Evaluación.FindAsync(id);
            _context.Evaluación.Remove(evaluación);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluaciónExists(string id)
        {
            return _context.Evaluación.Any(e => e.Id == id);
        }
    }
}
