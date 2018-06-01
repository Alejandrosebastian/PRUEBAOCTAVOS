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
        private DesempleadoModels claseDesempleado;

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

        
        public List<IdentityError> ControladorGuardaDesempleado(string tiempo,DateTime fecha_ini, DateTime fecha_fin)
        {
            return claseDesempleado.ModeloGrabaDesempleo(tiempo,fecha_ini,fecha_fin);
        }

        public List<object[]> ControladorListaDesempleados()
        {
            return claseDesempleado.ModeloListaDesempleado();
        }
        public List<Desempleado> ControladorUnDesempleado(int DesempleadoId)
        {
            //var sexo = _context.Sexos.Where(s => s.SexoId == sexoId).ToList();
            var desempleado = (from s in _context.Desempleado
                        where s.DesempleadoId == DesempleadoId
                        select s).ToList();
            return desempleado;
        }
        public List<IdentityError> ControladorEditaDesempleado(int id, string tiempo,DateTime fecha_ini,DateTime fecha_fin)
        {
            return claseDesempleado.ModeloEditarDesempleado(id, tiempo,fecha_ini,fecha_fin);
        }
        public List<IdentityError> ControladorEliminarSexo(int id)
        {
            return claseDesempleado.ModeloEliminarDesempleado(id);
        }
    }
}
