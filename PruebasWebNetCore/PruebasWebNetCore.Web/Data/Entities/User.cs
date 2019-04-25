
//TODO: agregar los demas atributos (esta seria la tabla persona)
namespace PruebasWebNetCore.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class User: IdentityUser
    {
        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }
    }
}
