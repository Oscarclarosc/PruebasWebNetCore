using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Models
{
    public class RegisterNewUserViewModel
    {
        [Required]
        [Display(Name ="Nombre")]
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
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password")]
        public string Confirm { get; set; }
    }
}
