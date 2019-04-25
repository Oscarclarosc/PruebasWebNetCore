
namespace PruebasWebNetCore.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Color
    {
        public int Id { get; set; }

        [MaxLength(30)] 
        [Required(ErrorMessage = "Se necesita el nombre del color")]
        [Display(Name = "Color")]
        public string Nombre { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Se necesita el codigo del color")]
        [Display(Name ="Codigo")]
        public string Codigo { get; set; }

        [Display(Name = "Visualizar Color")]
        public string ImagenUrl { get; set; }

        [Display(Name = "Esta Disponible?")]
        public bool Estado { get; set; }
    }
}
