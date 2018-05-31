using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pruebaunoparcial.Data;
using Pruebaunoparcial.Models;

namespace Pruebaunoparcial.Controllers
{
    public class EstudiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estudios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudio.ToListAsync());
        }

        // GET: Estudios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudio
                .SingleOrDefaultAsync(m => m.EstudioId == id);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // GET: Estudios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstudioId,Detalle")] Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudio);
        }

        // GET: Estudios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudio.SingleOrDefaultAsync(m => m.EstudioId == id);
            if (estudio == null)
            {
                return NotFound();
            }
            return View(estudio);
        }

        // POST: Estudios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstudioId,Detalle")] Estudio estudio)
        {
            if (id != estudio.EstudioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudioExists(estudio.EstudioId))
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
            return View(estudio);
        }

        // GET: Estudios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudio
                .SingleOrDefaultAsync(m => m.EstudioId == id);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // POST: Estudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudio = await _context.Estudio.SingleOrDefaultAsync(m => m.EstudioId == id);
            _context.Estudio.Remove(estudio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudioExists(int id)
        {
            return _context.Estudio.Any(e => e.EstudioId == id);
        }
    }
}
