﻿

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    //TODO: revisar si la relacion con Impresion Pedido esta bien
    public class Pedido : IEntity
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Estado del Pedido")]
        public string EstadoPedido { get; set; }

        [Required]
        [Display(Name = "Cantidad del Pedido")]
        public decimal CantidadPedido { get; set; }

        [Required]
        [Display(Name = "Cantidad a Extruir")]
        public decimal CantidadExtruir { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        //Relacion uno a muchos
        [Required]
        public Producto Producto { get; set; }

        //Relacion 0 a uno
        public ImpresionPedido Impresion { get; set; }

        [Required]
        public Empresa Empresa { get; set; }


    }
}
