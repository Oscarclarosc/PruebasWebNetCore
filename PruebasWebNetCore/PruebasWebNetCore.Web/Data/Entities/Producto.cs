using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class Producto
    {

        public int ProductoId { get; set; }

        public decimal Ancho { get; set; }

        public decimal Largo { get; set; }

        public decimal Espesor { get; set; }

        public string Material { get; set; }

        public string TipoAcabado { get; set; }

        public string TipoCorte { get; set; }

        public bool Estado { get; set; }

        //
        public int ColorId { get; set; }

    }
}
