
namespace PruebasWebNetCore.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Color
    {
        public int Id { get; set; }

        [Display(Name = "Color")]
        public string Nombre { get; set; }

        [Display(Name ="Codigo")]
        public string Codigo { get; set; }

        [Display(Name = "Visualizar Color")]
        public string ImagenUrl { get; set; }

        [Display(Name = "Esta Disponible?")]
        public bool Estado { get; set; }
    }
}
