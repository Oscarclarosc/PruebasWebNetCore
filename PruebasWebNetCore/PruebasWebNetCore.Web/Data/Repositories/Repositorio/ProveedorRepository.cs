

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProveedorRepository : GenericRepository<Proveedor> , IProveedorRepository
    {
        private readonly DataContext context;

        public ProveedorRepository(DataContext context):base(context)
        {
            this.context = context;
        }

        //Telefono
        public async Task AddTelefonoAsync(TelefonoViewModel model)
        {
            var proveedor = await this.GetProveedorConTelefonoAsync(model.PoseedorId);
            if (proveedor == null)
            {
                return;
            }

            var telefono = new Telefono
            {
                Numero = model.Numero,
                Extencion = model.Extencion,
                Estado = model.Estado
            };
            proveedor.Telefonos.Add(telefono);
            this.context.Proveedores.Update(proveedor);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> DeleteTelefonoAsync(Telefono telefono)
        {
            var proveedor = await this.context.Proveedores.Where(c => c.Telefonos.Any(ci => ci.Id == telefono.Id)).FirstOrDefaultAsync();
            if (proveedor == null)
            {
                return 0;
            }

            this.context.Telefonos.Remove(telefono);
            await this.context.SaveChangesAsync();
            return proveedor.Id;
        }

        public async Task<Proveedor> GetProveedorConTelefonoAsync(int id)
        {
            return await this.context.Proveedores
            .Include(c => c.Telefonos)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

        public IQueryable GetProveedorConTelefonos()
        {
            return this.context.Proveedores
            .Include(c => c.Telefonos)
            .OrderBy(c => c.Nombre);
        }

        public async Task<Telefono> GetTelefonoAsync(int id)
        {
            return await this.context.Telefonos.FindAsync(id);
        }

        public async Task<int> UpdateTelefonoAsync(Telefono telefono)
        {
            var proveedor = await this.context.Proveedores.Where(c => c.Telefonos.Any(ci => ci.Id == telefono.Id)).FirstOrDefaultAsync();
            if (proveedor == null)
            {
                return 0;
            }

            this.context.Telefonos.Update(telefono);
            await this.context.SaveChangesAsync();
            return proveedor.Id;
        }

        //Direccion
        public async Task AddDireccionAsync(DireccionViewModel model)
        {
            var proveedor = await this.GetProveedorConDireccionAsync(model.PoseedorId);
            if (proveedor == null)
            {
                return;
            }

            var direccion = new Direccion
            {
                DireccionFisica = model.DireccionFisica,
                Estado = model.Estado
            };
            proveedor.Direcciones.Add(direccion);
            this.context.Proveedores.Update(proveedor);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> DeleteDireccionAsync(Direccion direccion)
        {
            var proveedor = await this.context.Proveedores.Where(c => c.Direcciones.Any(ci => ci.Id == direccion.Id)).FirstOrDefaultAsync();
            if (proveedor == null)
            {
                return 0;
            }

            this.context.Direcciones.Remove(direccion);
            await this.context.SaveChangesAsync();
            return proveedor.Id;
        }

        public async Task<Proveedor> GetProveedorConDireccionAsync(int id)
        {
            return await this.context.Proveedores
            .Include(c => c.Direcciones)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

        public IQueryable GetProveedorConDireccionesYTelefonos()
        {
            return this.context.Proveedores
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
            var proveedor = await this.context.Proveedores.Where(c => c.Direcciones.Any(ci => ci.Id == direccion.Id)).FirstOrDefaultAsync();
            if (proveedor == null)
            {
                return 0;
            }

            this.context.Direcciones.Update(direccion);
            await this.context.SaveChangesAsync();
            return proveedor.Id;
        }

        public async Task<Proveedor> GetProveedorConDireccionYTelefonoAsync(int id)
        {
            return await this.context.Proveedores
            .Include(c => c.Direcciones)
            .Include(c => c.Telefonos)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

        public IEnumerable<SelectListItem> GetComboProveedor()
        {
            var list = this.context.Proveedores.Select(p => new SelectListItem
            {
                Text = p.Nombre,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Proveedor...)",
                Value = "0"

            });
            return list;
        }



    }
}
