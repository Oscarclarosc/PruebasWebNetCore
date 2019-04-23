using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class Pedido
    {

        public int PedidoId { get; set; }

        public string EstadoPedido { get; set; }

        public decimal CantidadPedido { get; set; }

        public decimal CantidadExtruir { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        //
        public int ClienteId { get; set; }

        public int ProductoId { get; set; }

        public int ImpresionPedidoId { get; set; }

    }
}
