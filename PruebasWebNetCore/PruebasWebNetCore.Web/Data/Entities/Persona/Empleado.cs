using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class Empleado : Persona
    {

        [Required]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string Cargo { get; set; }

        [Required]
        [Display(Name = "Fecha de Contratacion")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaContrato { get; set; }

        [Required]
        [Display(Name = "Hora de Entrada")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraEntrada { get; set; }

        [Display(Name = "Foto")]
        public string ImagenUrl { get; set; }

        public ICollection<Telefono> Telefonos { get; set; }
        
        [Display(Name = "# Telefonos")]
        public int NumeroTelefonos { get { return this.Telefonos == null ? 0 : this.Telefonos.Count; } }

        public ICollection<Direccion> Direcciones { get; set; }

        [Display(Name = "# Direcciones")]
        public int NumeroDirecciones { get { return this.Direcciones == null ? 0 : this.Direcciones.Count; } }

        public bool Estado { get; set; }
    }
}
