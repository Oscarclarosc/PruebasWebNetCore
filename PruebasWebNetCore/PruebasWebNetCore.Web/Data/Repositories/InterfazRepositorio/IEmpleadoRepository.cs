

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Data.Entities;
    using Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IEmpleadoRepository : IGenericRepository<Empleado>
    {
        //Telefonos
        IQueryable GetEmpleadosConTelefonos();

        Task<Empleado> GetEmpleadoConTelefonoAsync(int id);

        Task<Telefono> GetTelefonoAsync(int id);

        Task AddTelefonoAsync(TelefonoViewModel model);

        Task<int> UpdateTelefonoAsync(Telefono telefono);

        Task<int> DeleteTelefonoAsync(Telefono telefono);

        //Direcciones

        Task AddDireccionAsync(DireccionViewModel model);

        Task<int> DeleteDireccionAsync(Direccion direccion);

        Task<Empleado> GetEmpleadoConDireccionAsync(int id);

        IQueryable GetEmpleadosConDireccionesYTelefonos();

        Task<Direccion> GetDireccionAsync(int id);

        Task<int> UpdateDireccionAsync(Direccion direccion);

        Task<Empleado> GetEmpleadoConDireccionYTelefonoAsync(int id);


        Task<Empleado> GetEmpleadoPorCarnet(int carnet);

    }
}
