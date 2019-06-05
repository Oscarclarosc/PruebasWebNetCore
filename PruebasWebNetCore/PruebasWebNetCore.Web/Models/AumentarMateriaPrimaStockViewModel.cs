using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Models
{
    public class AumentarMateriaPrimaStockViewModel
    {
        public int AlmacenMateriaPrimaId { get; set; }

        public int MateriaPrimaId { get; set; }

        public int EmpleadoId { get; set; }

        [Required]
        [Display(Name ="Cantidad a Aumentar")]
        public decimal Cantidad { get; set; }

        [Required]
        public decimal CantidadAnterior { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }


        public string Observaciones { get; set; }

    }
}
