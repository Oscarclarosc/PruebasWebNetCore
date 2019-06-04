

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AlmacenMateriaPrima : IEntity
    {
        public int Id { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required]
        public Empleado Empleado { get; set; }

        //TODO : hbailitar el required pero agregar que se cargue en los add etc
        //[Required]
        public int MateriaPrimaId { get; set; }

        [Required]
        public MateriaPrima MateriaPrima { get; set; }

        public string Observaciones { get; set; }

       
    }
}
