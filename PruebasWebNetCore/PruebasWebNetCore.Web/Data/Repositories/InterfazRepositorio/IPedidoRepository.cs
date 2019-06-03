

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPedidoRepository : IGenericRepository<Pedido>
    {

        //Impresiones
        
        IQueryable GetPedidoConImpresion();

        Task<Pedido> GetPedidoConImpresionAsync(int id);

        Task<ImpresionPedido> GetImpresionAsync(int id);

        Task AddImpresionAsync(ImpresionPedidoViewModel model);


            //TODO: arreglar
            //Task<int> UpdateImpresionAsync(ImpresionPedido impresion);

            // Task<int> DeleteImpresionAsync(ImpresionPedido impresion);

            //
        Task AddPedidoAsync(PedidoViewModel model);
        IQueryable GetPedidoWithAll();

        IQueryable GetPedidoPorFase(User user);

        //
        Task CabiarEstadoAsync(Pedido pedido);

    }
}
