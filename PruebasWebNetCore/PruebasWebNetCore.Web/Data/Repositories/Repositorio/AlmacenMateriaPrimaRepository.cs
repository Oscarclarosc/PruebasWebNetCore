

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Helpers;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AlmacenMateriaPrimaRepository : GenericRepository<AlmacenMateriaPrima> ,IAlmacenMateriaPrimaRepository
    {
        private readonly DataContext context;
        private readonly IMateriaPrimaRepository materiaPrimaRepository;
        private readonly IUserHelper userHelper;
        private readonly IEmpleadoRepository empleadoRepository;

        public AlmacenMateriaPrimaRepository(DataContext context, IMateriaPrimaRepository materiaPrimaRepository, IUserHelper userHelper, IEmpleadoRepository empleadoRepository) : base(context)
        {
            this.context = context;
            this.materiaPrimaRepository = materiaPrimaRepository;
            this.userHelper = userHelper;
            this.empleadoRepository = empleadoRepository;
        }

        public async Task AddAlmacenMateriaPrimaAsync(AlmacenMateriaPrimaViewModel model)
        {
            var materiaprima = await this.materiaPrimaRepository.GetByIdAsync(model.MateriaPrimaId);
            var user = await this.userHelper.GetUserByIdAsync(model.UserId);
            var empleado = await this.empleadoRepository.GetEmpleadoPorCarnet(user.Ci);
            var almacenmateriaprima = new AlmacenMateriaPrima
            {
                Cantidad = model.Cantidad,
                Empleado = empleado,
                Fecha = DateTime.Today,
                MateriaPrimaId = materiaprima.Id,
                MateriaPrima = materiaprima,
                Observaciones = model.Observaciones
            };
            this.context.AlmacenesMateriasPrimas.Update(almacenmateriaprima);
            await this.context.SaveChangesAsync();
        }


        //Para aumentar el stock

        public async Task AumentarStock(AlmacenMateriaPrima almacen, decimal cantidad)
        {
            decimal aux;
            aux = almacen.Cantidad + cantidad;
            almacen.Cantidad = aux;
            this.context.AlmacenesMateriasPrimas.Update(almacen);
            await this.context.SaveChangesAsync();
        }


        //Para reducir el Stock
        public async Task ReducirStock(AlmacenMateriaPrima almacen, decimal cantidad)
        {
            decimal aux;
            aux = almacen.Cantidad - cantidad;
            almacen.Cantidad = aux;
            this.context.AlmacenesMateriasPrimas.Update(almacen);
            await this.context.SaveChangesAsync();
        }


        public IQueryable GetAlmacenMaterialPrimaAll()
        {
            return this.context.AlmacenesMateriasPrimas
            .Include(d => d.MateriaPrima)
            .OrderBy(c => c.Fecha);
        }

        public async Task<AlmacenMateriaPrima> GetAlmacenMateriaPrimaAllAsync(int id)
        {
            return await this.context.AlmacenesMateriasPrimas
            .Include(e => e.Empleado)
            .Include(e => e.MateriaPrima.Color)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

        //para obtener el id del inventario por la materia prima
        public async Task<AlmacenMateriaPrima> GetAlmacenMateriaPrimaPorMateriaPrimaAsync(int idMateriaPrima)
        {
            return await this.context.AlmacenesMateriasPrimas
            .Where(c => c.MateriaPrima.Id == idMateriaPrima)
            .FirstOrDefaultAsync();
        }



    }
}
