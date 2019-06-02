

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Producto : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Se necesita el Ancho del Producto")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Ancho { get; set; }

        [Required(ErrorMessage = "Se necesita el Largo del Producto")]
        [DisplayFormat(DataFormatString = "{0:N2}" ,ApplyFormatInEditMode = false)]
        public decimal Largo { get; set; }

        [Required(ErrorMessage = "Se necesita el Espesor del Producto")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public decimal Espesor { get; set; }

        [Required(ErrorMessage = "Se necesita el Material del Producto")]
        public string Material { get; set; }

        [Required(ErrorMessage = "Se necesita el tipo de Acabado del Producto")]
        [Display(Name = "Tipo de Acabado")]
        public string TipoAcabado { get; set; }

        [Required(ErrorMessage = "Se necesita el tipo de Corte del Producto")]
        [Display(Name = "Tipo de Corte")]
        public string TipoCorte { get; set; }

        [Required(ErrorMessage = "Se necesita el Codigo del producto")]
        [Display(Name = "Codigo")]
        public string Codigo { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }


        public int ColorId { get; set; }
        public Color Color { get; set; }


    }
}
