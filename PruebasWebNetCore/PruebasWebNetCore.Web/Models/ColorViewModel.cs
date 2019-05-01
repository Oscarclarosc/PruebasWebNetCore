

namespace PruebasWebNetCore.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using PruebasWebNetCore.Web.Data.Entities;
    using System.ComponentModel.DataAnnotations;

    public class ColorViewModel:Color
    {
        //
        [Display(Name = "Imagen")]
        public IFormFile ImagenFile { get; set; }
    }
}
