﻿

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class InformacionFase : IEntity
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Cantidad Entrada")]
        public decimal CantidaEntrada { get; set; }

        [Required]
        [Display(Name = "Fecha de Inicio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }

        [Required]
        public string Fase { get; set; }

        [Required]
        public Empleado Empleado { get; set; }

        [Required]
        public Pedido Pedido { get; set; }


        public Desecho Desecho { get; set; }

        public ProductoTerminado ProductoTerminado { get; set; }

    }
}
