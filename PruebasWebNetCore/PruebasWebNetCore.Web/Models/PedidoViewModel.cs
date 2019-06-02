

namespace PruebasWebNetCore.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class PedidoViewModel
    {

        public int PedidoId { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Estado del Pedido")]
        public string EstadoPedido { get; set; }

        [Required]
        [Display(Name = "Cantidad del Pedido")]
        public decimal CantidadPedido { get; set; }

        [Required]
        [Display(Name = "Cantidad a Extruir")]
        public decimal CantidadExtruir { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Producto")]
        public int ProductoId { get; set; }

        public IEnumerable<SelectListItem> Productos { get; set; }

        [Display(Name = "Empresa")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una empresa")]
        public int EmpresaId { get; set; }

        public IEnumerable<SelectListItem> Empresas { get; set; }

    }
}
