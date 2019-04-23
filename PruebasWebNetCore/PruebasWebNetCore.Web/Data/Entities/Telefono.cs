using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class Telefono
    {
        public int TelefonoId { get; set; }

        public int Numero { get; set; }

        public string Extencion { get; set; }

        public bool Estado { get; set; }

    }
}
