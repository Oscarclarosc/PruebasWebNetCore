

namespace PruebasWebNetCore.Web.Data
{

    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;

    public class DataContext : DbContext
    {
        public DbSet<Color> Colores { get; set; } // se recomiendan llamar las propiedades en plural


        //constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
