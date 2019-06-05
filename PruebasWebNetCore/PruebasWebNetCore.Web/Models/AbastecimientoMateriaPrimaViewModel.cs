

namespace PruebasWebNetCore.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class AbastecimientoMateriaPrimaViewModel
    {

        public int AbastecimientoMaterialId { get; set; }

        public string UserId { get; set; }

        public int AlmacenMateriaPrima { get; set; }

        [Required]
        public decimal Cantidad { get; set; }


        [Display(Name = "Materia Prima")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una Materia Prima")]
        public int MateriaPrimaId { get; set; }

        public IEnumerable<SelectListItem> MateriasPrimas { get; set; }

        [Display(Name = "Materia Prima")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una Materia Prima")]
        public int ProveedorId { get; set; }

        public IEnumerable<SelectListItem> Proveedores { get; set; }



    }
}
