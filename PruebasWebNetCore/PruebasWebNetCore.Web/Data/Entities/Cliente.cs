using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Tipo { get; set; }

        public int PersonaId { get; set; }

        public int EmpresaId { get; set; }
    }
}
