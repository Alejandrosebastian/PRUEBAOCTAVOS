using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pruebaunoparcial.Data;
using Pruebaunoparcial.Models;
using Microsoft.AspNetCore.Identity;

namespace Pruebaunoparcial.Controllers
{
    public class DiscapacidadesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private DiscapacidadModel claseDiscapacidad;

        public DiscapacidadesController(ApplicationDbContext context)
        {
            _context = context;
            claseDiscapacidad = new DiscapacidadModel(context);

        }

        // GET: Discapacidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Discapacidad.ToListAsync());
        }

        public List<IdentityError> ControladorGuardaDiscapacidad(string discapacidad)
        {
            return claseDiscapacidad.ModeloGrabaDiscapacidad(discapacidad);
        }

        public List<object[]> ControladorListaDiscapacidad()
        {
            return claseDiscapacidad.ModeloListaDiscapacidad();
        }

        public List<IdentityError> ControladorEditaDiscapacidad(int id, string discapacidad)
        {
            return claseDiscapacidad.ModeloEditarDiscapacidad(id, discapacidad);
        }
        public List<Discapacidad> ControladorUnDiscapacidad(int discapacidadId)
        {
          
            var discapacidad = (from s in _context.Discapacidad
                        where s.DiscapacidadId == discapacidadId
                        select s).ToList();
            return discapacidad;
        }

        public List<IdentityError> ControladorEliminarDiscapacidad(int id)
        {
            return claseDiscapacidad.ModeloEliminarDiscapacidad(id);
        }
    }
}
