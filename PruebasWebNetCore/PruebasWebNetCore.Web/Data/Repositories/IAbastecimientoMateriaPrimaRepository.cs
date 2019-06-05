

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAbastecimientoMateriaPrimaRepository:IGenericRepository<AbastecimientoMateriaPrima>
    {

        Task AddAbastecimientoDeMateriaPrimaAsync(AbastecimientoMateriaPrimaViewModel model);

        IQueryable GetAbastecimientoMateriaPrimaSolicitud();

        IQueryable GetAbastecimientoMateriaPrimaAll();

        IQueryable GetAbastecimientoMateriaPrimaProcesado(Empleado empleado);

        Task<AbastecimientoMateriaPrima> GetAbastecimientoMateriaPrimaAllAsync(int id);

        Task CambiarEstadoAsync(AbastecimientoMateriaPrima pedido, AlmacenMateriaPrima almacen);


    }
}
