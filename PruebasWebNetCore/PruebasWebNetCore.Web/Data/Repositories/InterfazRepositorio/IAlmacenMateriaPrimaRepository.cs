

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAlmacenMateriaPrimaRepository : IGenericRepository<AlmacenMateriaPrima>
    {

        Task AddAlmacenMateriaPrimaAsync(AlmacenMateriaPrimaViewModel model);

        IQueryable GetAlmacenMaterialPrimaAll();

        Task<AlmacenMateriaPrima> GetAlmacenMateriaPrimaAllAsync(int id);


        Task<AlmacenMateriaPrima> GetAlmacenMateriaPrimaPorMateriaPrimaAsync(int idMateriaPrima);

        Task AumentarStock(AlmacenMateriaPrima almacen, decimal cantidad);

        Task ReducirStock(AlmacenMateriaPrima almacen, decimal cantidad);

    }
}
