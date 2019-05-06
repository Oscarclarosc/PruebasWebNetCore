

namespace PruebasWebNetCore.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using PruebasWebNetCore.Web.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductoViewModel : Producto
    {
        [Display(Name = "Color")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un color ")]
        public int ColorId { get; set; }

        public IEnumerable<SelectListItem> Colores { get; set; }

    }
}
