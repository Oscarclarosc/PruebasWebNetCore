﻿

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Direccion:IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string Ciudad { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string Pais { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string DireccionFisica { get; set; }

        public bool Estado { get; set; }

    }
}
