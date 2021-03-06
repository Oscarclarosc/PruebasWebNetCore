﻿
namespace PruebasWebNetCore.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AlmacenDesecho : IEntity
    {
        public int Id { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required]
        public Empleado Empleado { get; set; }

        [Required]
        public Desecho Desecho { get; set; }

        public string Observaciones { get; set; }

        
    }
}
