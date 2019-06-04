using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebasWebNetCore.Web.Data.Entities;
using PruebasWebNetCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasWebNetCore.Web.Data.Repositories
{
    public class MateriaPrimaRepository:GenericRepository<MateriaPrima>, IMateriaPrimaRepository
    {
        private readonly DataContext context;
        private readonly IColorRepository colorRepository;

        public MateriaPrimaRepository(DataContext context,IColorRepository colorRepository):base (context)
        {
            this.context = context;
            this.colorRepository = colorRepository;
        }

        public async Task AddMateriaPrimaAsync(MateriaPrimaViewModel model)
        {
            var color = await this.colorRepository.GetByIdAsync(model.ColorId);
            var materiaprima = new MateriaPrima
            {
                Nombre = model.Nombre,
                Clase = model.Clase,
                Estado = model.Estado,
                Observaciones = model.Observaciones,
                Tipo = model.Tipo,
                ColorId = model.ColorId,
                Color = color
            };
            this.context.MateriasPrimas.Update(materiaprima);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateMateriaPrimaAsync(MateriaPrimaViewModel model)
        {
            var color = await this.colorRepository.GetByIdAsync(model.ColorId);
            var materiaprima = new MateriaPrima
            {
                Id=model.MateriaPrimaId,
                Nombre = model.Nombre,
                Clase = model.Clase,
                Estado = model.Estado,
                Observaciones = model.Observaciones,
                Tipo = model.Tipo,
                ColorId = model.ColorId,
                Color = color
            };
            this.context.MateriasPrimas.Update(materiaprima);
            await this.context.SaveChangesAsync();
        }

        public IQueryable GetMateriaPrimaWithColor()
        {
            return this.context.MateriasPrimas
            .Include(d => d.Color)
            .OrderBy(c => c.Nombre);
        }

        public IEnumerable<SelectListItem> GetComboMateriasPrimas()
        {
            var list = this.context.MateriasPrimas.Select(p => new SelectListItem
            {
                Text = p.Clase + " "+ p.Nombre ,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione una Materia Prima...)",
                Value = "0"

            });
            return list;
        }

    }
}
