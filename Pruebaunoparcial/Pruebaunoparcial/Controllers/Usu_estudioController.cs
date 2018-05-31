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
    public class Usu_estudioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Usu_estudioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usu_estudio
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Usu_estudio.Include(u => u.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Usu_estudio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usu_estudio = await _context.Usu_estudio
                .Include(u => u.Usuario)
                .SingleOrDefaultAsync(m => m.Usu_estudioId == id);
            if (usu_estudio == null)
            {
                return NotFound();
            }

            return View(usu_estudio);
        }

        // GET: Usu_estudio/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido");
            return View();
        }

        // POST: Usu_estudio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Usu_estudioId,UsuarioId,EstudiosId")] Usu_estudio usu_estudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usu_estudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido", usu_estudio.UsuarioId);
            return View(usu_estudio);
        }

        // GET: Usu_estudio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usu_estudio = await _context.Usu_estudio.SingleOrDefaultAsync(m => m.Usu_estudioId == id);
            if (usu_estudio == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido", usu_estudio.UsuarioId);
            return View(usu_estudio);
        }

        // POST: Usu_estudio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Usu_estudioId,UsuarioId,EstudiosId")] Usu_estudio usu_estudio)
        {
            if (id != usu_estudio.Usu_estudioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usu_estudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Usu_estudioExists(usu_estudio.Usu_estudioId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido", usu_estudio.UsuarioId);
            return View(usu_estudio);
        }

        // GET: Usu_estudio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usu_estudio = await _context.Usu_estudio
                .Include(u => u.Usuario)
                .SingleOrDefaultAsync(m => m.Usu_estudioId == id);
            if (usu_estudio == null)
            {
                return NotFound();
            }

            return View(usu_estudio);
        }

        // POST: Usu_estudio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usu_estudio = await _context.Usu_estudio.SingleOrDefaultAsync(m => m.Usu_estudioId == id);
            _context.Usu_estudio.Remove(usu_estudio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Usu_estudioExists(int id)
        {
            return _context.Usu_estudio.Any(e => e.Usu_estudioId == id);
        }
    }
}
