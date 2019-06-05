

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

    public class AbastecimientoMateriaPrimaRespository :GenericRepository<AbastecimientoMateriaPrima> , IAbastecimientoMateriaPrimaRepository
    {
        private readonly DataContext context;
        private readonly IMateriaPrimaRepository materiaPrimaRepository;
        private readonly IAlmacenMateriaPrimaRepository almacenMateriaPrimaRepository;
        private readonly IUserHelper userHelper;
        private readonly IEmpleadoRepository empleadoRepository;
        private readonly IProveedorRepository proveedorRepository;

        public AbastecimientoMateriaPrimaRespository(DataContext context , IMateriaPrimaRepository materiaPrimaRepository, IAlmacenMateriaPrimaRepository almacenMateriaPrimaRepository, IUserHelper userHelper, IEmpleadoRepository empleadoRepository, IProveedorRepository proveedorRepository) : base(context)
        {
            this.context = context;
            this.materiaPrimaRepository = materiaPrimaRepository;
            this.almacenMateriaPrimaRepository = almacenMateriaPrimaRepository;
            this.userHelper = userHelper;
            this.empleadoRepository = empleadoRepository;
            this.proveedorRepository = proveedorRepository;
        }


        public async Task AddAbastecimientoDeMateriaPrimaAsync(AbastecimientoMateriaPrimaViewModel model)
        {
            var materiaprima = await this.materiaPrimaRepository.GetByIdAsync(model.MateriaPrimaId);
            var almacenmateriaprima = await this.almacenMateriaPrimaRepository.GetAlmacenMateriaPrimaPorMateriaPrimaAsync(model.MateriaPrimaId);
            var user = await this.userHelper.GetUserByIdAsync(model.UserId);
            var empleado = await this.empleadoRepository.GetEmpleadoPorCarnet(user.Ci);
            var proveedor = await this.proveedorRepository.GetByIdAsync(model.ProveedorId);
            var abastecimiento = new AbastecimientoMateriaPrima
            {
                Cantidad = model.Cantidad,
                Empleado = empleado,
                Fecha = DateTime.Today,
                AlmacenMateriaPrima = almacenmateriaprima,
                MateriaPrima = materiaprima,
                Proveedor = proveedor,
                EstadoPedido = "Solicitud"
            };
            this.context.AbastecimientosMateriasPrimas.Update(abastecimiento);
            await this.context.SaveChangesAsync();
        }

        //Estados del pedido
        //Solicitud
        //Procesado
        //Recibido
        public IQueryable GetAbastecimientoMateriaPrimaSolicitud()
        {
            return this.context.AbastecimientosMateriasPrimas
                .Include(e => e.MateriaPrima)
                .Include(p => p.AlmacenMateriaPrima)
                .Where(pe => pe.EstadoPedido == "Solicitud")
                .OrderBy(pe => pe.Fecha);
        }

        public IQueryable GetAbastecimientoMateriaPrimaProcesado(Empleado empleado)
        {
            return this.context.PedidosMateriasPrimas
                .Include(e => e.MateriaPrima)
                .Include(p => p.AlmacenMateriaPrima)
                .Where(pe => pe.EstadoPedido == "Procesado" && pe.Empleado.Id == empleado.Id)
                .OrderBy(pe => pe.Fecha);
        }

        public IQueryable GetAbastecimientoMateriaPrimaAll()
        {
            return this.context.AbastecimientosMateriasPrimas
                .Include(e => e.MateriaPrima)
                .Include(p => p.AlmacenMateriaPrima)
                .OrderBy(pe => pe.Fecha);
        }

        public async Task<AbastecimientoMateriaPrima> GetAbastecimientoMateriaPrimaAllAsync(int id)
        {
            return await this.context.AbastecimientosMateriasPrimas
            .Include(e => e.MateriaPrima)
            .Include(p => p.AlmacenMateriaPrima)
            .Include(c => c.Empleado)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }



        public async Task CambiarEstadoAsync(AbastecimientoMateriaPrima abastecimiento, AlmacenMateriaPrima almacen)
        {
            if (abastecimiento.EstadoPedido == "Solicitud")
            {
                abastecimiento.EstadoPedido = "Procesado";
                await this.almacenMateriaPrimaRepository.ReducirStock(almacen, abastecimiento.Cantidad);
            }
            else if (abastecimiento.EstadoPedido == "Procesado")
            {
                abastecimiento.EstadoPedido = "Entregado";
            }
            this.context.AbastecimientosMateriasPrimas.Update(abastecimiento);
            await this.context.SaveChangesAsync();

        }


    }
}
