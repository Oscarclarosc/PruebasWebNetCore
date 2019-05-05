

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    //TODO: falta hacer la implementacion en las vista de seleccionar un color
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

        //TODO: agregar el displayformat para mostrar cm junto al numero si se puede
        [Required(ErrorMessage = "Se necesita la dimension del rodillo")]
        [Display(Name = "Dimension del Rodillo")]
        public decimal DimensionRodillo { get; set; }

        //
        [Required]
        public Color Color { get; set; }


        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
