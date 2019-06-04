

namespace PruebasWebNetCore.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class AlmacenMateriaPrimaViewModel
    {

        public int AlmacenMateriaPrimaId { get; set; }

        public string UserId { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }

        [Display(Name = "Materia Prima")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una Materia Prima")]
        public int MateriaPrimaId { get; set; }
        public IEnumerable<SelectListItem> MateriasPrimas { get; set; }


    }
}
