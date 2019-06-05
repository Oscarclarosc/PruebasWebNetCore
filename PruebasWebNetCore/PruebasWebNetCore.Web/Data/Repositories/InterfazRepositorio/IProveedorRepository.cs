

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProveedorRepository : IGenericRepository<Proveedor>
    {

        //Telefonos
        IQueryable GetProveedorConTelefonos();

        Task<Proveedor> GetProveedorConTelefonoAsync(int id);

        Task<Telefono> GetTelefonoAsync(int id);

        Task AddTelefonoAsync(TelefonoViewModel model);

        Task<int> UpdateTelefonoAsync(Telefono telefono);

        Task<int> DeleteTelefonoAsync(Telefono telefono);

        //Direcciones

        Task AddDireccionAsync(DireccionViewModel model);

        Task<int> DeleteDireccionAsync(Direccion direccion);

        Task<Proveedor> GetProveedorConDireccionAsync(int id);

        IQueryable GetProveedorConDireccionesYTelefonos();

        Task<Direccion> GetDireccionAsync(int id);

        Task<int> UpdateDireccionAsync(Direccion direccion);

        Task<Proveedor> GetProveedorConDireccionYTelefonoAsync(int id);

        IEnumerable<SelectListItem> GetComboProveedor();

    }
}
