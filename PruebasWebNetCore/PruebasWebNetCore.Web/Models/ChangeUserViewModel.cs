

namespace PruebasWebNetCore.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    //Lo unico que no se puede cambiar a los usuarios es el correo
    public class ChangeUserViewModel
    {

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }


    }
}
