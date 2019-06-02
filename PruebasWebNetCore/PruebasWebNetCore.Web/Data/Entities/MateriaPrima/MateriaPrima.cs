using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class MateriaPrima:IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Clase { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Observaciones { get; set; }

        [Required]
        public bool Estado { get; set; }

        
        public int ColorId { get; set; }

        [Required]
        public Color Color { get; set; }

    }
}
