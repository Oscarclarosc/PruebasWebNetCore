
//clase que sirve para ingresar datos por defecto
namespace PruebasWebNetCore.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using PruebasWebNetCore.Web.Data.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;

        //private Random random;

        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userManager.FindByEmailAsync("oscarclarosc@gmail.com");

            //creo que esto estaba mal
            if (user == null)
            {
                {
                    user = new User
                    {
                        Nombre = "Oscar",
                        ApellidoPaterno = "Claros",
                        ApellidoMaterno = "Carrillo",
                        Email = "oscarclarosc@gmail.com",
                        UserName = "oscarclarosc@gmail.com",
                        PhoneNumber = "7651519"
                    };
                }
                var result = await this.userManager.CreateAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se pudo crear el usuario en el Seeder");
                }
            }

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
