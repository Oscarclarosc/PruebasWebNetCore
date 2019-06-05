
namespace PruebasWebNetCore.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Proveedor : IEntity
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [Display(Name = "Proveedor")]
        public string Nombre { get; set; }

        public ICollection<Telefono> Telefonos { get; set; }

        [Display(Name = "# Telefonos")]
        public int NumeroTelefonos => this.Telefonos == null ? 0 : this.Telefonos.Count;

        public ICollection<Direccion> Direcciones { get; set; }

        [Display(Name = "# Direcciones")]
        public int NumeroDirecciones => this.Direcciones == null ? 0 : this.Direcciones.Count;

    }
}
