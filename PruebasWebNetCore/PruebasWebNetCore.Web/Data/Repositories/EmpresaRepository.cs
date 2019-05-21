

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository
    {
        private readonly DataContext context;

        public EmpresaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        //Telefono
        public async Task AddTelefonoAsync(TelefonoViewModel model)
        {
            var empresa = await this.GetEmpresaConTelefonoAsync(model.PoseedorId);
            if (empresa == null)
            {
                return;
            }

            var telefono = new Telefono
            {
                Numero = model.Numero,
                Extencion = model.Extencion,
                Estado = model.Estado
            };
            empresa.Telefonos.Add(telefono);
            this.context.Empresas.Update(empresa);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> DeleteTelefonoAsync(Telefono telefono)
        {
            var empresa = await this.context.Empresas.Where(c => c.Telefonos.Any(ci => ci.Id == telefono.Id)).FirstOrDefaultAsync();
            if (empresa == null)
            {
                return 0;
            }

            this.context.Telefonos.Remove(telefono);
            await this.context.SaveChangesAsync();
            return empresa.Id;
        }

        public async Task<Empresa> GetEmpresaConTelefonoAsync(int id)
        {
            return await this.context.Empresas
            .Include(c => c.Telefonos)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

        public IQueryable GetEmpresasConTelefonos()
        {
            return this.context.Empresas
            .Include(c => c.Telefonos)
            .OrderBy(c => c.Nombre);
        }

        public async Task<Telefono> GetTelefonoAsync(int id)
        {
            return await this.context.Telefonos.FindAsync(id);
        }

        public async Task<int> UpdateTelefonoAsync(Telefono telefono)
        {
            var empresa = await this.context.Empresas.Where(c => c.Telefonos.Any(ci => ci.Id == telefono.Id)).FirstOrDefaultAsync();
            if (empresa == null)
            {
                return 0;
            }

            this.context.Telefonos.Update(telefono);
            await this.context.SaveChangesAsync();
            return empresa.Id;
        }

        //Direccion
        public async Task AddDireccionAsync(DireccionViewModel model)
        {
            var empresa = await this.GetEmpresaConDireccionAsync(model.PoseedorId);
            if (empresa == null)
            {
                return;
            }

            var direccion = new Direccion
            {
                DireccionFisica = model.DireccionFisica,
                Estado = model.Estado
            };
            empresa.Direcciones.Add(direccion);
            this.context.Empresas.Update(empresa);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> DeleteDireccionAsync(Direccion direccion)
        {
            var empresa = await this.context.Empresas.Where(c => c.Direcciones.Any(ci => ci.Id == direccion.Id)).FirstOrDefaultAsync();
            if (empresa == null)
            {
                return 0;
            }

            this.context.Direcciones.Remove(direccion);
            await this.context.SaveChangesAsync();
            return empresa.Id;
        }

        public async Task<Empresa> GetEmpresaConDireccionAsync(int id)
        {
            return await this.context.Empresas
            .Include(c => c.Direcciones)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

        public IQueryable GetEmpresasConDireccionesYTelefonos()
        {
            return this.context.Empresas
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
            var empresa = await this.context.Empresas.Where(c => c.Direcciones.Any(ci => ci.Id == direccion.Id)).FirstOrDefaultAsync();
            if (empresa == null)
            {
                return 0;
            }

            this.context.Direcciones.Update(direccion);
            await this.context.SaveChangesAsync();
            return empresa.Id;
        }

        public async Task<Empresa> GetEmpresaConDireccionYTelefonoAsync(int id)
        {
            return await this.context.Empresas
            .Include(c => c.Direcciones)
            .Include(c => c.Telefonos)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

    }
}
