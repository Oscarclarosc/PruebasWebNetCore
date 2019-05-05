using System;
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
        public string Extencion { get; set; }

        public bool Estado { get; set; }

        public Empresa Empresa { get; set; }

        public Empleado Empleado { get; set; }

    }
}
