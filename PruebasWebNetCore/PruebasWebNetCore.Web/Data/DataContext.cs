

//en esta clase es donde se implementan las conexiones entre las tablas y es donde crea los dbset el entity F
namespace PruebasWebNetCore.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;
    using System.Linq;

    //using System.Data.Entity;

    public class DataContext : IdentityDbContext<User>
    {

        //Son las instrucciones para que el modelo se mande a la base de datos
        public DbSet<Color> Colores { get; set; } // se recomiendan llamar las propiedades en plural

        public DbSet<ImpresionPedido> Impresiones { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Telefono> Telefonos { get; set; }

        public DbSet<Fase> Fases { get; set; }

        public DbSet<InformacionFase> InformacionesFases { get; set; }

        public DbSet<Desecho> Desechoes { get; set; }

        public DbSet<ProductoTerminado> ProductosTerminados { get; set; }

        public DbSet<MateriaPrima> MateriasPrimas { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }


        //constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //para no permitir el borrado en cascada
            var cascadeFKS = builder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach(var fk in cascadeFKS)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Relaciones 1 a 0..1
            builder.Entity<Pedido>()
            .HasOne<ImpresionPedido>(s => s.Impresion)
            .WithOne(ad => ad.Pedido)
            .HasForeignKey<ImpresionPedido>(ad => ad.PedidoId);

            builder.Entity<InformacionFase>()
            .HasOne<Desecho>(s => s.Desecho)
            .WithOne(ad => ad.InformacionFase)
            .HasForeignKey<Desecho>(ad => ad.InformacionFaseId);

            builder.Entity<InformacionFase>()
            .HasOne<ProductoTerminado>(s => s.ProductoTerminado)
            .WithOne(ad => ad.InformacionFase)
            .HasForeignKey<ProductoTerminado>(ad => ad.InformacionFaseId);

        }

    }
}
