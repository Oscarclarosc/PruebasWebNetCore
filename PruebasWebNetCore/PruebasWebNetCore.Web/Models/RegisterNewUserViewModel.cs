
namespace PruebasWebNetCore.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterNewUserViewModel
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

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [MinLength(6)]
        public string Password { get; set; }


        [Required]
        public string Telefono { get; set; }

        [Required]
        public int Ci { get; set; }

        [Required]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password")]
        public string Confirm { get; set; }

        [Required]
        public string Cargo { get; set; }

    }
}
