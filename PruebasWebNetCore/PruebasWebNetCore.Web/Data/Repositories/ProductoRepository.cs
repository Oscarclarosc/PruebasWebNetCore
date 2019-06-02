

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;

    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        private readonly DataContext context;
        private readonly IColorRepository colorRepository;

        public ProductoRepository(DataContext context, IColorRepository colorRepository) : base(context)
        {
            this.context = context;
            this.colorRepository = colorRepository;
        }

        public async Task AddProductoAsync(ProductoViewModel model)
        {
            var color = await this.colorRepository.GetByIdAsync(model.ColorId);
            var producto = new Producto
            {
                Ancho=model.Ancho,
                Espesor= model.Espesor,
                Largo = model.Largo,
                Material=model.Material,
                TipoAcabado=model.TipoAcabado,
                TipoCorte=model.TipoCorte,
                Codigo = model.Codigo, 
                Estado=model.Estado,
                ColorId = model.ColorId,
                Color = color
            };
            this.context.Productos.Update(producto);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateProductoAsync(ProductoViewModel model)
        {
            var color = await this.colorRepository.GetByIdAsync(model.ColorId);
            var producto = new Producto
            {
                Id=model.ProductoId,
                Ancho = model.Ancho,
                Espesor = model.Espesor,
                Largo = model.Largo,
                Material = model.Material,
                TipoAcabado = model.TipoAcabado,
                TipoCorte = model.TipoCorte,
                Codigo= model.Codigo,
                Estado = model.Estado,
                ColorId = model.ColorId,
                Color = color
            };
            this.context.Productos.Update(producto);
            await this.context.SaveChangesAsync();
        }

        public IQueryable GetProductoWithColor()
        {
            return this.context.Productos
            .Include(d => d.Color)
            .OrderBy(c => c.Material);
        }

        public IEnumerable<SelectListItem> GetComboProductos()
        {
            var list = this.context.Productos.Select(p => new SelectListItem
            {
                Text = p.Codigo,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Producto...)",
                Value = "0"

            });
            return list;
        }

    }
}
