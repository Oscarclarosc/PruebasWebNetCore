

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProductoRepository : IGenericRepository<Producto>
    {

        Task AddProductoAsync(ProductoViewModel model);
        Task UpdateProductoAsync(ProductoViewModel model);
        IQueryable GetProductoWithColor();

        IEnumerable<SelectListItem> GetComboProductos();


    }
}
