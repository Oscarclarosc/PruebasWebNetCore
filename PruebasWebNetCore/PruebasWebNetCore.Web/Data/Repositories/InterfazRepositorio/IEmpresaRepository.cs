
namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IEmpresaRepository : IGenericRepository<Empresa>
    {

        //Telefonos
        IQueryable GetEmpresasConTelefonos();

        Task<Empresa> GetEmpresaConTelefonoAsync(int id);

        Task<Telefono> GetTelefonoAsync(int id);

        Task AddTelefonoAsync(TelefonoViewModel model);

        Task<int> UpdateTelefonoAsync(Telefono telefono);

        Task<int> DeleteTelefonoAsync(Telefono telefono);

        //Direcciones

        Task AddDireccionAsync(DireccionViewModel model);

        Task<int> DeleteDireccionAsync(Direccion direccion);

        Task<Empresa> GetEmpresaConDireccionAsync(int id);

        IQueryable GetEmpresasConDireccionesYTelefonos();

        Task<Direccion> GetDireccionAsync(int id);

        Task<int> UpdateDireccionAsync(Direccion direccion);

        Task<Empresa> GetEmpresaConDireccionYTelefonoAsync(int id);

        IEnumerable<SelectListItem> GetComboEmpresas();


    }
}
