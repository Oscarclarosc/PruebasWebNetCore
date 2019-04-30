
//TODO: aqui se agregarian los atributos de persona
//TODO: falta agregar la clase entity
namespace PruebasWebNetCore.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

    }
}
