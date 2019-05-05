

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using System.Threading.Tasks;
    using PruebasWebNetCore.Web.Data.Entities;

    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        private readonly DataContext context;

        public ProductoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task AddColorToProductAsync(Color colorModelo)
        {
            var color = await this.context.Colores.FindAsync(colorModelo.Id);

            if(color == null)
            {
                return;
            }



            throw new System.NotImplementedException();
        }
    }
}
