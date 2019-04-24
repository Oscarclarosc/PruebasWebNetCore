
//clase que sirve para ingresar datos por defecto
namespace PruebasWebNetCore.Web.Data
{
    using PruebasWebNetCore.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        //private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Colores.Any())
            {
                this.AddColor("Rojo", "#FF0000");
                this.AddColor("Amarillo", "#FFFF00");
                this.AddColor("Verde", "#008000");
                this.AddColor("Azul", "#0000FF");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddColor(string nombre, string codigo)
        {
            this.context.Colores.Add(new Color
            {
                Nombre = nombre,
                Codigo = codigo,
                Estado = true,
            });
        }

    }
}
