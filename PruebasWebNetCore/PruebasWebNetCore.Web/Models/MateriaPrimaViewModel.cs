using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Models
{
    public class MateriaPrimaViewModel
    {
        public int MateriaPrimaId { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Clase { get; set; }

        [Required]
        public string Nombre { get; set; }

        
        public string Observaciones { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Display(Name = "Color")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Color")]
        public int ColorId { get; set; }

        public IEnumerable<SelectListItem> Colores { get; set; }

    }
}
