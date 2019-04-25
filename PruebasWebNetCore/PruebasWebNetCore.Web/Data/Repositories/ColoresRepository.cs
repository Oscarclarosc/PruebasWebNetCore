
//aqui deberian de hacerse las consultas especificas para la tabla colores
namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Entities;

    public class ColoresRepository : GenericRepository<Color>, IColoresRepository
    {
        public ColoresRepository(DataContext context) : base(context)
        {

        }
    }
}
