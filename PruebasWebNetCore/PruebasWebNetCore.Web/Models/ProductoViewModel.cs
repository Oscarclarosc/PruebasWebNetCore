

namespace PruebasWebNetCore.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductoViewModel
    {
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Se necesita el Ancho del Producto")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Ancho { get; set; }

        [Required(ErrorMessage = "Se necesita el Largo del Producto")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
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

        [Required(ErrorMessage = "Se necesita el codigo del Producto")]
        [Display(Name = "Codigo")]
        public string Codigo { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Display(Name = "Color")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Color")]
        public int ColorId { get; set; }

        public IEnumerable<SelectListItem> Colores { get; set; }

    }
}
