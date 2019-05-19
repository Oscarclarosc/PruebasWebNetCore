

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Empresa : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [Display(Name = "Empresa")]
        public string Nombre { get; set; }

        public ICollection<Telefono> Telefonos { get; set; }

        [Display(Name = "# Telefonos")]
        public int NumeroTelefonos { get { return this.Telefonos == null ? 0 : this.Telefonos.Count; } }

        public ICollection<Direccion> Direcciones { get; set; }

        [Display(Name = "# Direcciones")]
        public int NumeroDirecciones { get { return this.Direcciones == null ? 0 : this.Direcciones.Count; } }
    }
}
