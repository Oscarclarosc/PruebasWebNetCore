

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        private readonly DataContext context;
        private readonly ICountryRepository countryRepository;

        public EmpleadoRepository(DataContext context, ICountryRepository countryRepository) : base(context)
        {
            this.context = context;
            this.countryRepository = countryRepository;
        }

        //Telefono
        public async Task AddTelefonoAsync(TelefonoViewModel model)
        {
            var empleado = await this.GetEmpleadoConTelefonoAsync(model.PoseedorId);
            if (empleado == null)
            {
                return;
            }

            var telefono = new Telefono
            {
                Numero = model.Numero,
                Extencion = model.Extencion,
                Estado = model.Estado
            };
            empleado.Telefonos.Add(telefono);
            this.context.Empleados.Update(empleado);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> DeleteTelefonoAsync(Telefono telefono)
        {
            var empleado = await this.context.Empleados.Where(c => c.Telefonos.Any(ci => ci.Id == telefono.Id)).FirstOrDefaultAsync();
            if (empleado == null)
            {
                return 0;
            }

            this.context.Telefonos.Remove(telefono);
            await this.context.SaveChangesAsync();
            return empleado.Id;
        }

        public async Task<Empleado> GetEmpleadoConTelefonoAsync(int id)
        {
            return await this.context.Empleados
            .Include(c => c.Telefonos)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

        public IQueryable GetEmpleadosConTelefonos()
        {
            return this.context.Empleados
            .Include(c => c.Telefonos)
            .OrderBy(c => c.Nombre);
        }

        public async Task<Telefono> GetTelefonoAsync(int id)
        {
            return await this.context.Telefonos.FindAsync(id);
        }

        public async Task<int> UpdateTelefonoAsync(Telefono telefono)
        {
            var empleado = await this.context.Empleados.Where(c => c.Telefonos.Any(ci => ci.Id == telefono.Id)).FirstOrDefaultAsync();
            if (empleado == null)
            {
                return 0;
            }

            this.context.Telefonos.Update(telefono);
            await this.context.SaveChangesAsync();
            return empleado.Id;
        }

        //Direccion


        public async Task AddDireccionAsync(DireccionViewModel model)
        {
            var empleado = await this.GetEmpleadoConDireccionAsync(model.PoseedorId);
            if (empleado == null)
            {
                return;
            }

            var city = await this.countryRepository.GetCityAsync(model.CityId);
            var direccion = new Direccion
            {
                DireccionFisica = model.DireccionFisica,
                City = city,
                CityId=model.CityId,
                Estado = model.Estado
            };
            empleado.Direcciones.Add(direccion);
            this.context.Empleados.Update(empleado);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> DeleteDireccionAsync(Direccion direccion)
        {
            var empleado = await this.context.Empleados.Where(c => c.Direcciones.Any(ci => ci.Id == direccion.Id)).FirstOrDefaultAsync();
            if (empleado == null)
            {
                return 0;
            }

            this.context.Direcciones.Remove(direccion);
            await this.context.SaveChangesAsync();
            return empleado.Id;
        }

        public async Task<Empleado> GetEmpleadoConDireccionAsync(int id)
        {
            return await this.context.Empleados
            .Include(c => c.Direcciones)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

        public IQueryable GetEmpleadosConDireccionesYTelefonos()
        {
            return this.context.Empleados
            .Include(c => c.Telefonos)
            .Include(d => d.Direcciones)
            .OrderBy(c => c.Nombre);
        }

        public async Task<Direccion> GetDireccionAsync(int id)
        {
            return await this.context.Direcciones.FindAsync(id);
        }

        public async Task<int> UpdateDireccionAsync(Direccion direccion)
        {
            var empleado = await this.context.Empleados.Where(c => c.Direcciones.Any(ci => ci.Id == direccion.Id)).FirstOrDefaultAsync();
            if (empleado == null)
            {
                return 0;
            }

            this.context.Direcciones.Update(direccion);
            await this.context.SaveChangesAsync();
            return empleado.Id;
        }

        public async Task<Empleado> GetEmpleadoConDireccionYTelefonoAsync(int id)
        {
            return await this.context.Empleados
            .Include(c => c.Direcciones)
            .Include(c => c.Telefonos)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }



    }


}
