

namespace PruebasWebNetCore.Web.Models
{
    using PruebasWebNetCore.Web.Data.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class InformacionFaseViewModel
    {
        public int InformacionFaseId { get; set; }

        public int PedidoId { get; set; }

        public string UserId { get; set; }


        [Required]
        [Display(Name = "Cantidad Entrada")]
        public decimal CantidaEntrada { get; set; }

        [Required]
        [Display(Name = "Fecha de Inicio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }

    }
}
