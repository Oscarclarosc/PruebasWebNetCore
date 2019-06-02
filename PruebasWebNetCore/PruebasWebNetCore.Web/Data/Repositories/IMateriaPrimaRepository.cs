using PruebasWebNetCore.Web.Data.Entities;
using PruebasWebNetCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Repositories
{
    public interface IMateriaPrimaRepository:IGenericRepository<MateriaPrima>
    {

        Task AddMateriaPrimaAsync(MateriaPrimaViewModel model);
        Task UpdateMateriaPrimaAsync(MateriaPrimaViewModel model);
        IQueryable GetMateriaPrimaWithColor();

    }
}
