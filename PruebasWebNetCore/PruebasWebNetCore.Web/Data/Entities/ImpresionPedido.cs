using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Entities
{
    public class ImpresionPedido
    {
        public int ImpresionPedidoId { get; set; }

        public string Texto { get; set; }

        public int CarasImpresas { get; set; }

        public int DimensionRodillo { get; set; }

        //
        public int ColorId { get; set; }

    }
}
