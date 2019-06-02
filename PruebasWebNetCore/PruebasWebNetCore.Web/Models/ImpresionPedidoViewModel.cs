using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Models
{
    public class ImpresionPedidoViewModel
    {
        public int PedidoId { get; set; }

        public int ImpresionId { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Se necesita el texto de la impresion")]
        [Display(Name = "Texto")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "Se necesitan las caras impresas")]
        [Display(Name = "Caras Impresas")]
        public int CarasImpresas { get; set; }

        //TODO: agregar el displayformat para mostrar cm junto al numero si se puede
        [Required(ErrorMessage = "Se necesita la dimension del rodillo")]
        [Display(Name = "Dimension del Rodillo")]
        public decimal DimensionRodillo { get; set; }

        [Display(Name = "Color")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Color")]
        public int ColorId { get; set; }

        public IEnumerable<SelectListItem> Colores { get; set; }


    }
}
