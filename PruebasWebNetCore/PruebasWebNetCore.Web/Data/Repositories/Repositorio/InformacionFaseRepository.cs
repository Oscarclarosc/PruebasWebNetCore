

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

    public class InformacionFaseRepository :GenericRepository <InformacionFase>, IInformacionFaseRepository
    {
        private readonly DataContext context;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IEmpleadoRepository empleadoRepository;
        private readonly IUserHelper userHelper;

        public InformacionFaseRepository(DataContext context, IPedidoRepository pedidoRepository, IEmpleadoRepository empleadoRepository, IUserHelper userHelper) : base(context)
        {
            this.context = context;
            this.pedidoRepository = pedidoRepository;
            this.empleadoRepository = empleadoRepository;
            this.userHelper = userHelper;
        }

        public async Task AddInformacionFaseAsync(InformacionFaseViewModel model)
        {
            //TODO: validar que todo esto exista
            var pedido = await this.pedidoRepository.GetByIdAsync(model.PedidoId);
            var user = await this.userHelper.GetUserByIdAsync(model.UserId);
            var empleado = await this.empleadoRepository.GetEmpleadoPorCarnet(user.Ci);
            var informacionfase = new InformacionFase
            {
                CantidaEntrada = model.CantidaEntrada,
                Fecha = model.Fecha,
                Id = model.InformacionFaseId,
                Pedido = pedido,
                Observaciones = model.Observaciones,
                Fase = empleado.Cargo,
                Empleado = empleado
            };
            await this.userHelper.CambiarEstadoNoDisponible(user);
            this.context.InformacionesFases.Update(informacionfase);
            await this.context.SaveChangesAsync();
        }

        //muestra la informacion fase actual en la que esta trabajando un empleado con desechos y producto terminado
        public async Task<InformacionFase> GetInformacionFasePorEmpleadoAsync(User user)
        {
            var empleado = await this.empleadoRepository.GetEmpleadoPorCarnet(user.Ci);

            return await this.context.InformacionesFases
            .Include(c => c.Pedido)
            .Include(d => d.Desecho)
            .Include(pt => pt.ProductoTerminado)
            .Where(c => c.Empleado.Id == empleado.Id)
            .LastOrDefaultAsync();
        }

        public async Task<InformacionFase> GetInformacionFaseDetalle(int id)
        {
            return await this.context.InformacionesFases
            .Include(c => c.Pedido)
            .Include(d => d.Desecho)
            .Include(pt => pt.ProductoTerminado)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

        //Desecho

        public async Task AddDesechoAsync(DesechoViewModel model)
        {
            var informacion = await this.GetByIdAsync(model.InformacionFaseId);
            if (informacion == null)
            {
                return;
            }

            var desecho = new Desecho
            {
                Cantidad = model.Cantidad,
                Fecha = model.Fecha,
                Observaciones = model.Observaciones,
                InformacionFaseId = model.InformacionFaseId
            };
            this.context.Desechos.Update(desecho);
            await this.context.SaveChangesAsync();
        }

        public async Task<Desecho> GetDesechoAsync(int id)
        {
            return await this.context.Desechos.FindAsync(id);
        }

        //Producto Terminado

        public async Task AddProductoTerminadoAsync(ProductoTerminadoViewModel model)
        {
            var informacion = await this.GetByIdAsync(model.InformacionFaseId);
            if (informacion == null)
            {
                return;
            }

            var productoterminado = new ProductoTerminado
            {
                Cantidad = model.Cantidad,
                Fecha = model.Fecha,
                Observaciones = model.Observaciones,
                InformacionFaseId = model.InformacionFaseId
            };
            this.context.ProductosTerminados.Update(productoterminado);
            await this.context.SaveChangesAsync();
        }

        public async Task<ProductoTerminado> GetProductoTerminadoAsync(int id)
        {
            return await this.context.ProductosTerminados.FindAsync(id);
        }

        public IQueryable GetInformacionFasePorPedido(int idpedido)
        {
            return this.context.InformacionesFases
                .Include(e => e.Empleado)
                .Where(pe => pe.Pedido.Id == idpedido)
                .OrderBy(pe => pe.Fecha);
        }



    }
}
