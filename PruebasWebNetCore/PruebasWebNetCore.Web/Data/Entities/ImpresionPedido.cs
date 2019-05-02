

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ImpresionPedido : IEntity
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Se necesita el texto de la impresion")]
        [Display(Name = "Texto")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "Se necesitan las caras impresas")]
        [Display(Name = "Caras Impresas")]
        public int CarasImpresas { get; set; }

        //TODO: agregar el displayformat para mostrar cm junto al numero
        [Required(ErrorMessage = "Se necesita la dimension del rodillo")]
        [Display(Name = "Dimension del Rodillo")]
        public int DimensionRodillo { get; set; }

        //
        public Color Color { get; set; }

    }
}
