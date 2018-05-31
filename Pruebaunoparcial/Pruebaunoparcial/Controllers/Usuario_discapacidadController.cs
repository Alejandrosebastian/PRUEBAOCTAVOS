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
    public class Usuario_discapacidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Usuario_discapacidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usuario_discapacidad
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Usuario_discapacidad.Include(u => u.Discapacidad).Include(u => u.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Usuario_discapacidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario_discapacidad = await _context.Usuario_discapacidad
                .Include(u => u.Discapacidad)
                .Include(u => u.Usuario)
                .SingleOrDefaultAsync(m => m.Usuario_discapacidadId == id);
            if (usuario_discapacidad == null)
            {
                return NotFound();
            }

            return View(usuario_discapacidad);
        }

        // GET: Usuario_discapacidad/Create
        public IActionResult Create()
        {
            ViewData["DiscapacidadId"] = new SelectList(_context.Discapacidad, "DiscapacidadId", "DiscapacidadId");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Apellido");
            return View();
        }

        // POST: Usuario_discapacidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Usuario_discapacidadId,UsuarioId,DiscapacidadId")] Usuario_discapacidad usuario_discapacidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario_discapacidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiscapacidadId"] = new SelectList(_context.Discapacidad, "DiscapacidadId", "DiscapacidadId", usuario_discapacidad.DiscapacidadId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Apellido", usuario_discapacidad.UsuarioId);
            return View(usuario_discapacidad);
        }

        // GET: Usuario_discapacidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario_discapacidad = await _context.Usuario_discapacidad.SingleOrDefaultAsync(m => m.Usuario_discapacidadId == id);
            if (usuario_discapacidad == null)
            {
                return NotFound();
            }
            ViewData["DiscapacidadId"] = new SelectList(_context.Discapacidad, "DiscapacidadId", "DiscapacidadId", usuario_discapacidad.DiscapacidadId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Apellido", usuario_discapacidad.UsuarioId);
            return View(usuario_discapacidad);
        }

        // POST: Usuario_discapacidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Usuario_discapacidadId,UsuarioId,DiscapacidadId")] Usuario_discapacidad usuario_discapacidad)
        {
            if (id != usuario_discapacidad.Usuario_discapacidadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario_discapacidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Usuario_discapacidadExists(usuario_discapacidad.Usuario_discapacidadId))
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
            ViewData["DiscapacidadId"] = new SelectList(_context.Discapacidad, "DiscapacidadId", "DiscapacidadId", usuario_discapacidad.DiscapacidadId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Apellido", usuario_discapacidad.UsuarioId);
            return View(usuario_discapacidad);
        }

        // GET: Usuario_discapacidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario_discapacidad = await _context.Usuario_discapacidad
                .Include(u => u.Discapacidad)
                .Include(u => u.Usuario)
                .SingleOrDefaultAsync(m => m.Usuario_discapacidadId == id);
            if (usuario_discapacidad == null)
            {
                return NotFound();
            }

            return View(usuario_discapacidad);
        }

        // POST: Usuario_discapacidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario_discapacidad = await _context.Usuario_discapacidad.SingleOrDefaultAsync(m => m.Usuario_discapacidadId == id);
            _context.Usuario_discapacidad.Remove(usuario_discapacidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Usuario_discapacidadExists(int id)
        {
            return _context.Usuario_discapacidad.Any(e => e.Usuario_discapacidadId == id);
        }
    }
}
