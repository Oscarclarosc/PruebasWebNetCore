using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class Persona
    {
        public int PersonaId { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Ci { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Email { get; set; }

        public bool Estado { get; set; }

        //
        public int TelefonoId { get; set; }

        public int DireccionId { get; set; }

    }
}
