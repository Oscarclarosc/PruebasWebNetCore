using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }

        public string Cargo { get; set; }

        public DateTime FechaContrato { get; set; }

        public DateTime HoraEntrada { get; set; }

        public bool Estado { get; set; }


    }
}
