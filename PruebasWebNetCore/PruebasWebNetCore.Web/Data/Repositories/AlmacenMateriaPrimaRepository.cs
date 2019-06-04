

namespace PruebasWebNetCore.Web.Data.Repositories
{
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
                Fecha = model.Fecha,
                MateriaPrima = materiaprima,
                Observaciones = model.Observaciones
            };
            this.context.AlmacenesMateriasPrimas.Update(almacenmateriaprima);
            await this.context.SaveChangesAsync();
        }




    }
}
