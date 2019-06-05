

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPedidoMateriaPrimaRepository : IGenericRepository<PedidoMateriaPrima>
    {

        Task AddPedidoDeMateriaPrimaAsync(PedidoMateriaPrimaViewModel model);

        IQueryable GetPedidoMateriaPrimaSolicitud();

        IQueryable GetPedidoMateriaPrimaAll();

        IQueryable GetPedidoMateriaPrimaProcesado(Empleado empleado);

        Task<PedidoMateriaPrima> GetPedidoMateriaPrimaAllAsync(int id);

        Task CambiarEstadoAsync(PedidoMateriaPrima pedido, AlmacenMateriaPrima almacen);

    }
}
