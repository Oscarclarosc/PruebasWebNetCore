

namespace PruebasWebNetCore.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TelefonoViewModel
    {
        public int PoseedorId { get; set; }

        public int TelefonoId { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [MaxLength(5, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string Extencion { get; set; }

        public bool Estado { get; set; }
    }
}
