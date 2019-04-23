using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class Direccion
    {
        public int CiudadId { get; set; }

        public string Ciudad { get; set; }

        public string Pais { get; set; }

        public string DireccionFisica { get; set; }

        public bool Estado { get; set; }

    }
}
