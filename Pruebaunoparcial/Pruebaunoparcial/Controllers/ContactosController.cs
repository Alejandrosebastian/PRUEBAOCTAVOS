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
    public class ContactoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contactoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Contacto.Include(c => c.Empleado).Include(c => c.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
                .Include(c => c.Empleado)
                .Include(c => c.Usuario)
                .SingleOrDefaultAsync(m => m.ContactoId == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // GET: Contactoes/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "EmpleadoId", "Apellido");
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido");
            return View();
        }

        // POST: Contactoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactoId,Fecha,Motivo,Observacion,EmpleadoId,UsuarioId")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "EmpleadoId", "Apellido", contacto.EmpleadoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido", contacto.UsuarioId);
            return View(contacto);
        }

        // GET: Contactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto.SingleOrDefaultAsync(m => m.ContactoId == id);
            if (contacto == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "EmpleadoId", "Apellido", contacto.EmpleadoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido", contacto.UsuarioId);
            return View(contacto);
        }

        // POST: Contactoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactoId,Fecha,Motivo,Observacion,EmpleadoId,UsuarioId")] Contacto contacto)
        {
            if (id != contacto.ContactoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.ContactoId))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "EmpleadoId", "Apellido", contacto.EmpleadoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Apellido", contacto.UsuarioId);
            return View(contacto);
        }

        // GET: Contactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
                .Include(c => c.Empleado)
                .Include(c => c.Usuario)
                .SingleOrDefaultAsync(m => m.ContactoId == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: Contactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacto = await _context.Contacto.SingleOrDefaultAsync(m => m.ContactoId == id);
            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(int id)
        {
            return _context.Contacto.Any(e => e.ContactoId == id);
        }
    }
}
