

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Persona:IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [Display(Name = "CI")]
        public int Ci { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        //TODO: Agregar el atributo nombre completo para mostrar el nombre completo en un solo string
        public string NombreCompleto { get { return $"{this.Nombre} {this.ApellidoPaterno} {this.ApellidoMaterno}"; } }
    }
}
