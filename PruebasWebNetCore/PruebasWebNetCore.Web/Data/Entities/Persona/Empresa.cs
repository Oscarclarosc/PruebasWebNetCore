

namespace PruebasWebNetCore.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Empresa : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [Display(Name = "Empresa")]
        public string Nombre { get; set; }
    }
}
