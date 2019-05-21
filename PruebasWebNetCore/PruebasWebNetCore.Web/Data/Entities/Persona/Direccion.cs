

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Direccion:IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string DireccionFisica { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public bool Estado { get; set; }
    }
}
