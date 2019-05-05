
namespace PruebasWebNetCore.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AlmacenDesecho : IEntity
    {
        public int Id { get; set; }

        [Required]
        public double Cantidad { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }

        [Required]
        public MateriaPrima MateriaPrima { get; set; }

        [Required]
        public Empleado Empleado { get; set; }
    }
}
