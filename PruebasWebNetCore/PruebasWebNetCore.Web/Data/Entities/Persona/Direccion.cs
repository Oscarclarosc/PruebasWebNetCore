

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Direccion:IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string DireccionFisica { get; set; }

        public bool Estado { get; set; }

        public Empresa Empresa { get; set; }

        public Empleado Empleado { get; set; }

    }
}
