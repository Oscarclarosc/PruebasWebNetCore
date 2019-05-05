

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        private readonly DataContext context;

        public ColorRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> GetComboColors()
        {
            var list = this.context.Colores.Select(p => new SelectListItem
            {
                Text = p.Nombre,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Color...)",
                Value = "0"

            });
            return list;
        }
    }
}
