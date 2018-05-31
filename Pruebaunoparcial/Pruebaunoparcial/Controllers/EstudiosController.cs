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
    public class EstudiosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EstudioModel claseEstudio;

        public EstudiosController(ApplicationDbContext context)
        {
            _context = context;
            claseEstudio = new EstudioModel(context);
        }
        // GET: Estudios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudio.ToListAsync());
        }
        public List<IdentityError> ControladorGuardaEstudio(string estudio)
        {
            return claseEstudio.ModeloGrabaEstudio(estudio);
        }

        public List<object[]> ControladorListaEstudio()
        {
            return claseEstudio.ModeloListaEstudio();
        }

        public List<IdentityError> ControladorEditaEstudio(int id, string estudio)
        {
            return claseEstudio.ModeloEditarEstudio(id, estudio);
        }
        public List<Estudio> ControladorUnEstudio(int estudioId)
        {
           
            var estudio = (from s in _context.Estudio
                        where s.EstudioId == estudioId
                        select s).ToList();
            return estudio;
        }

        public List<IdentityError> ControladorEliminarEstudio(int id)
        {
            return claseEstudio.ModeloEliminarEstudio(id);
        }
    }
}
