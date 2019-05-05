

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using PruebasWebNetCore.Web.Data.Entities;

    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        private readonly DataContext context;

        public EmpleadoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
