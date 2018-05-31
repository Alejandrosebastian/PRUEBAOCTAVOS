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
    public class DesempleadoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private DesempleadoesController claseDesempleado;

        public DesempleadoesController(ApplicationDbContext context)
        {
            _context = context;
            claseDesempleado = new DesempleadoModels(context);
        }

        // GET: Desempleadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Desempleado.ToListAsync());
        }

        
        public List<IdentityError> ControladorGuardaSexo(string sexo)
        {
            return claseSexo.ModeloGrabaSexo(sexo);
        }

        public List<object[]> ControladorListaSexos()
        {
            return claseSexo.ModeloListaSexos();
        }
        public List<Sexo> ControladorUnSexo(int sexoId)
        {
            //var sexo = _context.Sexos.Where(s => s.SexoId == sexoId).ToList();
            var sexo = (from s in _context.Sexos
                        where s.SexoId == sexoId
                        select s).ToList();
            return sexo;
        }
        public List<IdentityError> ControladorEditaSexo(int id, string sexo)
        {
            return claseSexo.ModeloEditarSexo(id, sexo);
        }
        public List<IdentityError> ControladorEliminarSexo(int id)
        {
            return claseSexo.ModeloEliminarSexo(id);
        }
    }
}
