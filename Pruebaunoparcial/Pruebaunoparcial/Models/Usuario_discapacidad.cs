using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pruebaunoparcial.Models
{
    public class Usuario_discapacidad 
    
    {
        public int Usuario_discapacidadId { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int DiscapacidadId { get; set; }
        public Discapacidad Discapacidad { get; set; }


    }
}
