

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAlmacenDesechoRepository : IGenericRepository<AlmacenDesecho>
    {

        Task AddAlmacenDesechoAsync(AlmacenDesechoViewModel model);
        IQueryable GetAlmacenDesechoAll();

    }
}
