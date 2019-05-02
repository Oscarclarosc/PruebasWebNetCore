

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using PruebasWebNetCore.Web.Data.Entities;

    public class ImpresionRepository : GenericRepository<ImpresionPedido>, IImpresionRepository
    {

        public ImpresionRepository(DataContext context) : base(context)
        {

        }

    }
}
