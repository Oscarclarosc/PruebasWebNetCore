﻿

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System.Threading.Tasks;

    public interface IAlmacenMateriaPrimaRepository : IGenericRepository<AlmacenMateriaPrima>
    {

        Task AddAlmacenMateriaPrimaAsync(AlmacenMateriaPrimaViewModel model);


    }
}
