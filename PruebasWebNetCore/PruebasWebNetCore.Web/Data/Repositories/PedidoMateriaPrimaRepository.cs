

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

    public class PedidoMateriaPrimaRepository : GenericRepository<PedidoMateriaPrima>, IPedidoMateriaPrimaRepository
    {
        private readonly DataContext context;
        private readonly IMateriaPrimaRepository materiaPrimaRepository;
        private readonly IUserHelper userHelper;
        private readonly IEmpleadoRepository empleadoRepository;
        private readonly IAlmacenMateriaPrimaRepository almacenMateriaPrimaRepository;

        public PedidoMateriaPrimaRepository(DataContext context, IMateriaPrimaRepository materiaPrimaRepository, IUserHelper userHelper, IEmpleadoRepository empleadoRepository, IAlmacenMateriaPrimaRepository almacenMateriaPrimaRepository) : base(context)
        {
            this.context = context;
            this.materiaPrimaRepository = materiaPrimaRepository;
            this.userHelper = userHelper;
            this.empleadoRepository = empleadoRepository;
            this.almacenMateriaPrimaRepository = almacenMateriaPrimaRepository;
        }

        public async Task AddPedidoDeMateriaPrimaAsync(PedidoMateriaPrimaViewModel model)
        {
            var materiaprima = await this.materiaPrimaRepository.GetByIdAsync(model.MateriaPrimaId);
            var almacenmateriaprima = await this.almacenMateriaPrimaRepository.GetAlmacenMateriaPrimaPorMateriaPrimaAsync(model.MateriaPrimaId);
            var user = await this.userHelper.GetUserByIdAsync(model.UserId);
            var empleado = await this.empleadoRepository.GetEmpleadoPorCarnet(user.Ci);


            var pedidomateriaprima = new PedidoMateriaPrima
            {
                Cantidad = model.Cantidad,
                Empleado = empleado,
                Fecha = DateTime.Today,
                AlmacenMateriaPrima = almacenmateriaprima,
                MateriaPrima = materiaprima,
                EstadoPedido = "Solicitud"
            };
            this.context.PedidosMateriasPrimas.Update(pedidomateriaprima);
            await this.context.SaveChangesAsync();
        }

        //Estados del pedido
        //Solicitud
        //Procesado
        //Recibido
        public IQueryable GetPedidoMateriaPrimaSolicitud()
        {
            return this.context.PedidosMateriasPrimas
                .Include(e => e.MateriaPrima)
                .Include(p => p.AlmacenMateriaPrima)
                .Where(pe => pe.EstadoPedido == "Solicitud")
                .OrderBy(pe => pe.Fecha);
        }

        public IQueryable GetPedidoMateriaPrimaProcesado(Empleado empleado)
        {
            return this.context.PedidosMateriasPrimas
                .Include(e => e.MateriaPrima)
                .Include(p => p.AlmacenMateriaPrima)
                .Where(pe => pe.EstadoPedido == "Procesado" && pe.Empleado.Id == empleado.Id)
                .OrderBy(pe => pe.Fecha);
        }

        public IQueryable GetPedidoMateriaPrimaAll()
        {
            return this.context.PedidosMateriasPrimas
                .Include(e => e.MateriaPrima)
                .Include(p => p.AlmacenMateriaPrima)
                .OrderBy(pe => pe.Fecha);
        }

        public async Task<PedidoMateriaPrima> GetPedidoMateriaPrimaAllAsync(int id)
        {
            return await this.context.PedidosMateriasPrimas
            .Include(e => e.MateriaPrima)
            .Include(p => p.AlmacenMateriaPrima)
            .Include(c => c.Empleado)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }



        public async Task CambiarEstadoAsync(PedidoMateriaPrima pedido, AlmacenMateriaPrima almacen)
        {
            if (pedido.EstadoPedido == "Solicitud")
            {
                pedido.EstadoPedido = "Procesado";
                await this.almacenMateriaPrimaRepository.ReducirStock(almacen, pedido.Cantidad);
            }
            else if(pedido.EstadoPedido == "Procesado")
            {
                pedido.EstadoPedido = "Entregado";
            }
            this.context.PedidosMateriasPrimas.Update(pedido);
            await this.context.SaveChangesAsync();

        }






    }
}
