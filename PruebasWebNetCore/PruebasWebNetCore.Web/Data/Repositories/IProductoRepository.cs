

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using PruebasWebNetCore.Web.Data.Entities;
    using System.Threading.Tasks;

    public interface IProductoRepository : IGenericRepository<Producto>
    {

        Task AddColorToProductAsync(Color color);

    }
}
