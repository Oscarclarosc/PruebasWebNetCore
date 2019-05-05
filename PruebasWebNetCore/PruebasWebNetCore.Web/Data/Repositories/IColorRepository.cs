

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using PruebasWebNetCore.Web.Data.Entities;
    using System.Collections.Generic;

    public interface IColorRepository : IGenericRepository<Color>
    {

        IEnumerable<SelectListItem> GetComboColors();


    }
}
