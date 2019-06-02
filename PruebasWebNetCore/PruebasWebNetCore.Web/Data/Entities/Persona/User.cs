
//TODO: aqui se agregarian los atributos de persona
//TODO: falta agregar la clase entity
namespace PruebasWebNetCore.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser
    {
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [MaxLength(50)]
        [Required]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [MaxLength(50)]
        [Required]
        public string ApellidoMaterno { get; set; }


        [Display(Name = "Nombre Completo")]
        public string FullName { get { return $"{this.Nombre}{this.ApellidoPaterno}{this.ApellidoMaterno}"; } }


        [Display(Name = "Carnet")]
        //[Required]
        public int Ci { get; set; }


        [Display(Name = "Telefono")]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        [Display(Name = "Cargo")]
       // [Required]
        public string Cargo { get; set; }

        [NotMapped]
        [Display(Name ="Es Admin?")]
        public bool IsAdmin { get; set; }

        //public City City { get; set; }

        //TODO: se podria agregar la foto aqui tambien

    }
}
