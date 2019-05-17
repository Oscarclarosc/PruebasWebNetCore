

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using System.Threading.Tasks;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;

    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        private readonly DataContext context;

        public ProductoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }


    }
}
