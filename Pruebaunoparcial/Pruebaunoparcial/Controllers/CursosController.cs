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
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private CursoModel claseCurso;

        public CursosController(ApplicationDbContext context)
        {
            _context = context;
            claseCurso = new CursoModel(context);
        }
        // GET: Estudios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Curso.ToListAsync());
        }


        public List<object[]> ControladorListaCurso()
        {
            return claseCurso.ModeloListaCursos();
        }
    }
}