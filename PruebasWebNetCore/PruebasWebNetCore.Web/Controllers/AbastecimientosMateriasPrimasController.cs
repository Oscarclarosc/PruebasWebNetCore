

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PruebasWebNetCore.Web.Data.Repositories;
    using PruebasWebNetCore.Web.Helpers;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AbastecimientosMateriasPrimasController:Controller
    {
        private readonly IAbastecimientoMateriaPrimaRepository abastecimientoMateriaPrimaRepository;
        private readonly IUserHelper userHelper;
        private readonly IMateriaPrimaRepository materiaPrimaRepository;
        private readonly IProveedorRepository proveedorRepository;
        private readonly IAlmacenMateriaPrimaRepository almacenMateriaPrimaRepository;
        private readonly IEmpleadoRepository empleadoRepository;

        public AbastecimientosMateriasPrimasController(IAbastecimientoMateriaPrimaRepository abastecimientoMateriaPrimaRepository, IUserHelper userHelper, IMateriaPrimaRepository materiaPrimaRepository, IProveedorRepository proveedorRepository, IAlmacenMateriaPrimaRepository  almacenMateriaPrimaRepository,IEmpleadoRepository empleadoRepository)
        {
            this.abastecimientoMateriaPrimaRepository = abastecimientoMateriaPrimaRepository;
            this.userHelper = userHelper;
            this.materiaPrimaRepository = materiaPrimaRepository;
            this.proveedorRepository = proveedorRepository;
            this.almacenMateriaPrimaRepository = almacenMateriaPrimaRepository;
            this.empleadoRepository = empleadoRepository;
        }

        //TODO: hacer vista que muestre las solicitudes de un trabajador
        public async Task<IActionResult> Create()
        {

            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);

            var model = new AbastecimientoMateriaPrimaViewModel
            {
                UserId = user.Id,
                MateriasPrimas = this.materiaPrimaRepository.GetComboMateriasPrimas(),
                Proveedores = this.proveedorRepository.GetComboProveedor()
            };

            return View(model);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(AbastecimientoMateriaPrimaViewModel model)
        {


            if (this.ModelState.IsValid)
            {

                await this.abastecimientoMateriaPrimaRepository.AddAbastecimientoDeMateriaPrimaAsync(model);

                //hacer funcion para que envie al index de desechos almacen
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        public IActionResult Index()
        {
            return View(this.abastecimientoMateriaPrimaRepository.GetAbastecimientoMateriaPrimaAll());

        }

        public IActionResult AbastecimientoDeMateriaPrimaEnSolicitud()
        {
            return View(this.abastecimientoMateriaPrimaRepository.GetAbastecimientoMateriaPrimaSolicitud());

        }

        //para mostrar los pedidos procesados de un empleado 
        public async Task<IActionResult> AbastecimientoDeMateriaProcesado()
        {
            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            var empleado = await this.empleadoRepository.GetEmpleadoPorCarnet(user.Ci);
            if (empleado == null)
            {
                return NotFound();

            }
            return View(this.abastecimientoMateriaPrimaRepository.GetAbastecimientoMateriaPrimaProcesado(empleado));
        }

        public async Task<IActionResult> CambiarEstadoAbastecimiento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await this.abastecimientoMateriaPrimaRepository.GetAbastecimientoMateriaPrimaAllAsync(id.Value);
            if (pedido == null)
            {
                return NotFound();
            }

            var almacen = await this.almacenMateriaPrimaRepository.GetAlmacenMateriaPrimaPorMateriaPrimaAsync(pedido.MateriaPrima.Id);
            if (almacen == null)
            {
                return NotFound();
            }

            await this.abastecimientoMateriaPrimaRepository.CambiarEstadoAsync(pedido, almacen);
            return this.RedirectToAction("ConfirmarCambioDeEstadoPedido");
        }

        public IActionResult ConfirmarCambioDeEstadoPedido()
        {
            return this.View();
        }




    }
}
