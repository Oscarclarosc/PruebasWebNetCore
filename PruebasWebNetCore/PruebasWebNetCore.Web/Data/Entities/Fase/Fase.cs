using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class Fase:IEntity
    {

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Caracteristicas { get; set; }

        public string ImagenUrl { get; set; }


    }
}
