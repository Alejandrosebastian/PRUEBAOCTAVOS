using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pruebaunoparcial.Models
{
    public class Empleo
    {
        public int EmpleoId { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
        public DateTime Fecha_ini { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string Mediador { get; set; }

        


    }
}
