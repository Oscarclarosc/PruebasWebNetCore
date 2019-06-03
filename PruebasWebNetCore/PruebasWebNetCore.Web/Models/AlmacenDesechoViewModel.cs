

namespace PruebasWebNetCore.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AlmacenDesechoViewModel
    {
        public int AlmacenDesechoId { get; set; }

        public string UserId { get; set; }

        public int DesechoId { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }

    }
}
