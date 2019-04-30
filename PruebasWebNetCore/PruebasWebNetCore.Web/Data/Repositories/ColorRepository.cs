

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Entities;

    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(DataContext context) : base(context)
        {

        }
    }
}
