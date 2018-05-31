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
    public class EmpleosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empleos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleo.ToListAsync());
        }

        // GET: Empleos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleo
                .SingleOrDefaultAsync(m => m.EmpleoId == id);
            if (empleo == null)
            {
                return NotFound();
            }

            return View(empleo);
        }

        // GET: Empleos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleoId,Cargo,Empresa,Fecha_ini,Fecha_fin,Mediador")] Empleo empleo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleo);
        }

        // GET: Empleos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleo.SingleOrDefaultAsync(m => m.EmpleoId == id);
            if (empleo == null)
            {
                return NotFound();
            }
            return View(empleo);
        }

        // POST: Empleos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleoId,Cargo,Empresa,Fecha_ini,Fecha_fin,Mediador")] Empleo empleo)
        {
            if (id != empleo.EmpleoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleoExists(empleo.EmpleoId))
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
            return View(empleo);
        }

        // GET: Empleos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleo
                .SingleOrDefaultAsync(m => m.EmpleoId == id);
            if (empleo == null)
            {
                return NotFound();
            }

            return View(empleo);
        }

        // POST: Empleos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleo = await _context.Empleo.SingleOrDefaultAsync(m => m.EmpleoId == id);
            _context.Empleo.Remove(empleo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleoExists(int id)
        {
            return _context.Empleo.Any(e => e.EmpleoId == id);
        }
    }
}
