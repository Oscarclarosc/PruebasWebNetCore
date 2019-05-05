using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class Empleado : User
    {

        [Required]
        public string Cargo { get; set; }

        [Required]
        [Display(Name = "Fecha de Contratacion")]
        public DateTime FechaContrato { get; set; }

        [Required]
        [Display(Name = "Hora de Entrada")]
        public DateTime HoraEntrada { get; set; }

        public bool Estado { get; set; }
    }
}
