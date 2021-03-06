﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class Telefono:IEntity
    {
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [MaxLength(5, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string Extencion { get; set; }

        public bool Estado { get; set; }

    }
}
