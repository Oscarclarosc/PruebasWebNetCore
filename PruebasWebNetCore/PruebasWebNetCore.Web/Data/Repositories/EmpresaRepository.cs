

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using PruebasWebNetCore.Web.Data.Entities;

    public class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository
    {
        private readonly DataContext context;

        public EmpresaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
