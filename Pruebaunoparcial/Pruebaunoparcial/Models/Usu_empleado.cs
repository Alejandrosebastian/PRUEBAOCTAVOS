using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pruebaunoparcial.Models
{
    public class Usu_empleado
    {
        public int Usu_empleadoId { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int EmpleoId { get; set; }
        public Empleo Empleo { get; set; }
        public int DesempleoId { get; set; }
        public Desempleado Desempleado { get; set; }
    }
}
