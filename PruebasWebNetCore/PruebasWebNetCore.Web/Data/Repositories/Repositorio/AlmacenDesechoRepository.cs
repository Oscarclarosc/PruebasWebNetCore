

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Helpers;
    using PruebasWebNetCore.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class AlmacenDesechoRepository : GenericRepository<AlmacenDesecho>, IAlmacenDesechoRepository
    {
        private readonly DataContext context;
        private readonly IInformacionFaseRepository informacionFaseRepository;
        private readonly IUserHelper userHelper;
        private readonly IEmpleadoRepository empleadoRepository;

        public AlmacenDesechoRepository(DataContext context, IInformacionFaseRepository informacionFaseRepository, IUserHelper userHelper, IEmpleadoRepository empleadoRepository) : base(context)
        {
            this.context = context;
            this.informacionFaseRepository = informacionFaseRepository;
            this.userHelper = userHelper;
            this.empleadoRepository = empleadoRepository;
        }


        public async Task AddAlmacenDesechoAsync(AlmacenDesechoViewModel model)
        {
            //TODO: validar que todo esto exista
            var desecho = await this.informacionFaseRepository.GetDesechoAsync(model.DesechoId);
            var user = await this.userHelper.GetUserByIdAsync(model.UserId);
            var empleado = await this.empleadoRepository.GetEmpleadoPorCarnet(user.Ci);
            var almacendesecho = new AlmacenDesecho
            {
                Cantidad = model.Cantidad,
                Fecha = model.Fecha,
                Id = model.AlmacenDesechoId,
                Desecho = desecho,
                Observaciones = model.Observaciones,
                Empleado = empleado
            };
            this.context.AlmacenesDesechos.Update(almacendesecho);
            await this.context.SaveChangesAsync();
        }

        public IQueryable GetAlmacenDesechoAll()
        {
            return this.context.AlmacenesDesechos
            .Include(d => d.Desecho)
            .OrderBy(c => c.Fecha);
        }






    }
}
