

namespace PruebasWebNetCore.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        private readonly DataContext context;
        private readonly IColorRepository colorRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IProductoRepository productoRepository;

        public PedidoRepository(DataContext context, IColorRepository colorRepository, IEmpresaRepository empresaRepository, IProductoRepository productoRepository) : base(context)
        {
            this.context = context;
            this.colorRepository = colorRepository;
            this.empresaRepository = empresaRepository;
            this.productoRepository = productoRepository;
        }

        //Impresion

        public async Task AddImpresionAsync(ImpresionPedidoViewModel model)
        {
            var pedido = await this.GetPedidoConImpresionAsync(model.PedidoId);
            var color = await this.colorRepository.GetByIdAsync(model.ColorId);
            if (pedido == null || color == null)
            {
                return;
            }
            var impresion = new ImpresionPedido
            {
                CarasImpresas = model.CarasImpresas,
                DimensionRodillo = model.DimensionRodillo,
                Texto = model.Texto,
                Color = color,
                PedidoId = pedido.Id
            };

            this.context.Impresiones.Update(impresion);
            await this.context.SaveChangesAsync();
            /*
            pedido.Impresion = impresion;
            this.context.Pedidos.Update(pedido);
            await this.context.SaveChangesAsync();
            */
        }

        public async Task<ImpresionPedido> GetImpresionAsync(int id)
        {
            return await this.context.Impresiones.FindAsync(id);
        }

        public IQueryable GetPedidoConImpresion()
        {
            return this.context.Pedidos
                .Include(c => c.Impresion)
                .OrderBy(c => c.Fecha);
        }

        public async Task<Pedido> GetPedidoConImpresionAsync(int id)
        {
            return await this.context.Pedidos
            .Include(e => e.Empresa)
            .Include(p => p.Producto)
            .Include(c => c.Impresion)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }


        /*
        public async Task<int> DeleteImpresionAsync(ImpresionPedido impresion)
        {
            
        }*/

        /*
        public async Task<int> UpdateImpresionAsync(ImpresionPedido impresion)
        {
            var pedido = await this.context.Pedidos.Where(c => c.Impresion.Id == impresion.Id);
            if (pedido == null)
            {
                return 0;
            }

            this.context.Impresiones.Update(impresion);
            await this.context.SaveChangesAsync();
            return pedido.Id;
        }*/

        public async Task AddPedidoAsync(PedidoViewModel model)
        {
            var empresa = await this.empresaRepository.GetByIdAsync(model.EmpresaId);
            var producto = await this.productoRepository.GetByIdAsync(model.ProductoId);
            var pedido = new Pedido
            {
                CantidadExtruir = model.CantidadExtruir,
                CantidadPedido = model.CantidadExtruir,
                EstadoPedido = model.EstadoPedido,
                Fecha = model.Fecha,
                Empresa = empresa,
                Producto = producto,
            };
            this.context.Pedidos.Update(pedido);
            await this.context.SaveChangesAsync();

        }

        //Para el index
        public IQueryable GetPedidoWithAll()
        {
            return this.context.Pedidos
                .Include(e => e.Empresa)
                .Include(p => p.Producto)
                .OrderBy(pe => pe.Fecha);
        }
    }
}
