﻿

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PedidoMateriaPrima : IEntity
    {

        public int Id { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public string EstadoPedido { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required]
        public Empleado Empleado { get; set; }

        [Required]
        public MateriaPrima MateriaPrima { get; set; }

        [Required]
        public AlmacenMateriaPrima AlmacenMateriaPrima { get; set; }

    }
}
