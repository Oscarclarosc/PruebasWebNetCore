

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IInformacionFaseRepository : IGenericRepository<InformacionFase>
    {

        Task AddInformacionFaseAsync(InformacionFaseViewModel model);

        Task<InformacionFase> GetInformacionFasePorEmpleadoAsync(User user);

        //Desechos
        Task AddDesechoAsync(DesechoViewModel model);
        Task<Desecho> GetDesechoAsync(int id);
        IQueryable GetDesechosAll();
        Task CambiarEstadoEnAlmacen(Desecho desecho);


        //Producto Terminado
        Task AddProductoTerminadoAsync(ProductoTerminadoViewModel model);
        Task<ProductoTerminado> GetProductoTerminadoAsync(int id);

        IQueryable GetInformacionFasePorPedido(int idpedido);
        Task<InformacionFase> GetInformacionFaseDetalle(int id);
    }
}
