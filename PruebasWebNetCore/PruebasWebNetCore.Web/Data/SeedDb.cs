
//clase que sirve para ingresar datos por defecto
namespace PruebasWebNetCore.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Data.Entities;
    using Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper )
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            //Usuarios
            //Aqui se agregan todos los roles que voy a tener en el programa
            //CheckRoleAsync revisa si el rol existe, si no es asi lo agrega a la tabla de roles
            await this.userHelper.CheckRoleAsync("Administrador");
            var user = await this.userHelper.GetUserByEmailAsync("oscarclarosc@gmail.com");

            if (user == null)
            {
                {
                    user = new User
                    {
                        Nombre = "Oscar",
                        ApellidoPaterno = "Claros",
                        ApellidoMaterno = "Carrillo",
                        Ci = 11337793,
                        Cargo = "Administrador",
                        Email = "oscarclarosc@gmail.com",
                        UserName = "oscarclarosc@gmail.com",
                        PhoneNumber = "7651519",
                        Disponible = true,

                    };
                }
                var result = await this.userHelper.AddUSerAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se pudo crear el usuario en el Seeder");
                }
                await this.userHelper.AddUserToRoleAsync(user, "Administrador");
                var token = await this.userHelper.GenerateEmailConfirmationTokenAsync(user);
                await this.userHelper.ConfirmEmailAsync(user, token);
            }
            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Administrador");

            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Administrador");
            }

            //Paises y Ciudades
            if (!this.context.Countries.Any())
            {
                var cities = new List<City>();
                cities.Add(new City { Name = "Santa Cruz" });
                cities.Add(new City { Name = "Cochabamba" });
                cities.Add(new City { Name = "Potosi" });
                cities.Add(new City { Name = "La paz" });
                cities.Add(new City { Name = "Tarija" });
                cities.Add(new City { Name = "Beni" });
                cities.Add(new City { Name = "Pando" });
                cities.Add(new City { Name = "Chuquisaca" });
                cities.Add(new City { Name = "Oruro" });
                this.context.Countries.Add(new Country
                {
                    Cities = cities,
                    Name = "Bolivia"
                });
                await this.context.SaveChangesAsync();
            }


            if (!this.context.Colores.Any())
            {
                this.AddColor("Rojo", "#FF0000");
                this.AddColor("Amarillo", "#FFFF00");
                this.AddColor("Verde", "#008000");
                this.AddColor("Azul", "#0000FF");
                this.AddColor("Incoloro", "#XXXXXX");
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
