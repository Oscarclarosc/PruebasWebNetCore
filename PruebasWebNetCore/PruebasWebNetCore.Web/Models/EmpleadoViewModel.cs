﻿

namespace PruebasWebNetCore.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using PruebasWebNetCore.Web.Data.Entities;
    using System.ComponentModel.DataAnnotations;

    public class EmpleadoViewModel : Empleado
    {
        [Display(Name = "Foto")]
        public IFormFile ImagenFile { get; set; }
    }
}
