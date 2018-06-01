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
    public class EmpleosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EmpleosModel claseempleos;

        public EmpleosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empleos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleo.ToListAsync());
        }
        public List<IdentityError> ControladorGurdaempleo(string cargo, string empresa, DateTime fechaini, DateTime fechafin, string mediador)
        {
            return claseempleos.listaempleo(cargo, empresa, fechaini, fechafin, mediador);
        }
        public List<object[]> Controladorlistaempleos()
        {
            return claseempleos.ModelolistaEmpleo();
        }
        public  List<IdentityError> ControladoreditaEmpleos(int id, string cargo, string empresa, DateTime fechaini, DateTime fechafin, string mediador)
        {
            return claseempleos.ModeloEditarEmpleo(cargo, empresa, fechaini, fechafin, mediador);
        }
        public List<IdentityError> Controladoreliminaempleos(int id)
        {
            return claseempleos.ModeloEliminarempleo(id);
        }
        
    }   
}
