
//clase que sirve para ingresar datos por defecto
namespace PruebasWebNetCore.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        //private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();
            //adicionar usuario
            var user = await this.userHelper.GetUserByEmailAsync("oscarclarosc@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    Nombre = "Oscar",
                    ApellidoPaterno = "Claros",
                    ApellidoMaterno = "Carrillo",
                    Email = "oscarclarosc@gmail.com",
                    UserName = "oscarclarosc@gmail.com",
                    PhoneNumber = "77651519"
                  
                };
            }

            var result = await this.userHelper.AddUserAsync(user, "123456");
            if(result != IdentityResult.Success)
            {
                throw new InvalidOperationException("No se pudo crear el usuario en el Seed");
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
