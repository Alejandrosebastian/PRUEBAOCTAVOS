using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pruebaunoparcial.Models
{
    public class Curso
    { 
        public int CursoId { get; set; } 
        public DateTime fecha_ini { get; set; }  

        public DateTime Fecha_fin { get; set; } 
        public string obsevacion { get; set; }
        public string entidad { get; set; }

    }
}
