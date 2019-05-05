﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class ProductoTerminado:IEntity
    {
        public int Id { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }

        public int InformacionFaseId { get; set; }
        public InformacionFase InformacionFase { get; set; }

    }
}
