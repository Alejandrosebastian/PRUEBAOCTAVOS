using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pruebaunoparcial.Data;

namespace Pruebaunoparcial.Models
{
    public class EmpleosModel
    {
        ApplicationDbContext _context;
        public EmpleosModel(ApplicationDbContext _contexto)
        {
            _context = _contexto;
        }
       

    }
}
