
//TODO: aqui se agregarian los atributos de persona
//TODO: falta agregar la clase entity
namespace PruebasWebNetCore.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string ApellidoPaterno { get; set; }

        [Required]
        public string ApellidoMaterno { get; set; }

        [Required]
        [Display(Name ="Carnet")]
        public int Ci { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        //TODO: Agregar el atributo nombre completo para mostrar el nombre completo en un solo string
        public string NombreCompleto { get { return $"{this.Nombre} {this.ApellidoPaterno} {this.ApellidoMaterno}"; } }

    }
}
