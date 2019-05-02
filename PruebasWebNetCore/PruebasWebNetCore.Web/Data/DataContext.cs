﻿

//en esta clase es donde se implementan las conexiones entre las tablas y es donde crea los dbset el entity F
namespace PruebasWebNetCore.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;

    //using System.Data.Entity;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Color> Colores { get; set; } // se recomiendan llamar las propiedades en plural

        public DbSet<ImpresionPedido> Impresiones { get; set; }


        //constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ImpresionPedido>()
                .HasOne(e => e.Color)
                .WithMany(c => c.ImpresionesPedido)
                .IsRequired();
        }*/

    }
}
