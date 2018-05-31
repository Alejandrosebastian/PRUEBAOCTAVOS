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
    public class Usu_empleadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Usu_empleadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usu_empleado
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Usu_empleado.Include(u => u.Empleo).Include(u => u.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Usu_empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usu_empleado = await _context.Usu_empleado
                .Include(u => u.Empleo)
                .Include(u => u.Usuario)
                .SingleOrDefaultAsync(m => m.Usu_empleadoId == id);
            if (usu_empleado == null)
            {
                return NotFound();
            }

            return View(usu_empleado);
        }

        // GET: Usu_empleado/Create
        public IActionResult Create()
        {
            ViewData["EmpleoId"] = new SelectList(_context.Empleo, "EmpleoId", "EmpleoId");
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido");
            return View();
        }

        // POST: Usu_empleado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Usu_empleadoId,UsuarioId,EmpleoId,DesempleoId")] Usu_empleado usu_empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usu_empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleoId"] = new SelectList(_context.Empleo, "EmpleoId", "EmpleoId", usu_empleado.EmpleoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido", usu_empleado.UsuarioId);
            return View(usu_empleado);
        }

        // GET: Usu_empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usu_empleado = await _context.Usu_empleado.SingleOrDefaultAsync(m => m.Usu_empleadoId == id);
            if (usu_empleado == null)
            {
                return NotFound();
            }
            ViewData["EmpleoId"] = new SelectList(_context.Empleo, "EmpleoId", "EmpleoId", usu_empleado.EmpleoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido", usu_empleado.UsuarioId);
            return View(usu_empleado);
        }

        // POST: Usu_empleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Usu_empleadoId,UsuarioId,EmpleoId,DesempleoId")] Usu_empleado usu_empleado)
        {
            if (id != usu_empleado.Usu_empleadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usu_empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Usu_empleadoExists(usu_empleado.Usu_empleadoId))
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
            ViewData["EmpleoId"] = new SelectList(_context.Empleo, "EmpleoId", "EmpleoId", usu_empleado.EmpleoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido", usu_empleado.UsuarioId);
            return View(usu_empleado);
        }

        // GET: Usu_empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usu_empleado = await _context.Usu_empleado
                .Include(u => u.Empleo)
                .Include(u => u.Usuario)
                .SingleOrDefaultAsync(m => m.Usu_empleadoId == id);
            if (usu_empleado == null)
            {
                return NotFound();
            }

            return View(usu_empleado);
        }

        // POST: Usu_empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usu_empleado = await _context.Usu_empleado.SingleOrDefaultAsync(m => m.Usu_empleadoId == id);
            _context.Usu_empleado.Remove(usu_empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Usu_empleadoExists(int id)
        {
            return _context.Usu_empleado.Any(e => e.Usu_empleadoId == id);
        }
    }
}
