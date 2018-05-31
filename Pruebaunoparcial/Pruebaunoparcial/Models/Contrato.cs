using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pruebaunoparcial.Models
{
    public class Contrato
    {
        public int ContratoId { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Escriba el tipo de contrato")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "tenia que poner de 3 a 100 caraccteres")]
        public int Tipo_contrato { get; set; }
    }
}
