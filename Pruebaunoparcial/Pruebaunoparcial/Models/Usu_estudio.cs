using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pruebaunoparcial.Models
{
    public class Usu_estudio
    {
        public int Usu_estudioId { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int EstudiosId { get; set; }
        public Estudio Estudio { get; set; }
    }
}
