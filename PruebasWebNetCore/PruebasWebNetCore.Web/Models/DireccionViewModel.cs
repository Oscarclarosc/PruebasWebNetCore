

namespace PruebasWebNetCore.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DireccionViewModel
    {
        public int PoseedorId { get; set; }

        public int DireccionId { get; set; }


        [Required]
        [Display(Name = "Direccion")]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string DireccionFisica { get; set; }

        [Display(Name = "City")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a city.")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }

        [Display(Name = "Country")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a country.")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        public bool Estado { get; set; }
    }
}
