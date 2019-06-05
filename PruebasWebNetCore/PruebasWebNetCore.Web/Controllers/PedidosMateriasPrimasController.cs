

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PruebasWebNetCore.Web.Data;
    using PruebasWebNetCore.Web.Data.Repositories;
    using PruebasWebNetCore.Web.Helpers;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PedidosMateriasPrimasController : Controller
    {
        private readonly IPedidoMateriaPrimaRepository pedidoMateriaPrimaRepository;
        private readonly IUserHelper userHelper;
        private readonly IMateriaPrimaRepository materiaPrimaRepository;
        private readonly IAlmacenMateriaPrimaRepository almacenMateriaPrimaRepository;

        public IEmpleadoRepository EmpleadoRepository { get; }

        public PedidosMateriasPrimasController(IPedidoMateriaPrimaRepository pedidoMateriaPrimaRepository, IUserHelper userHelper, IMateriaPrimaRepository materiaPrimaRepository, IAlmacenMateriaPrimaRepository almacenMateriaPrimaRepository, IEmpleadoRepository empleadoRepository)
        {
            this.pedidoMateriaPrimaRepository = pedidoMateriaPrimaRepository;
            this.userHelper = userHelper;
            this.materiaPrimaRepository = materiaPrimaRepository;
            this.almacenMateriaPrimaRepository = almacenMateriaPrimaRepository;
            EmpleadoRepository = empleadoRepository;
        }

        //TODO: hacer vista que muestre las solicitudes de un trabajador
        public async Task<IActionResult> Create()
        {

            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);

            var model = new PedidoMateriaPrimaViewModel
            {
                UserId = user.Id,
                MateriasPrimas = this.materiaPrimaRepository.GetComboMateriasPrimas(),
            };

            return View(model);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(PedidoMateriaPrimaViewModel model)
        {


            if (this.ModelState.IsValid)
            {

                var almacenmateriaprima = await this.almacenMateriaPrimaRepository.GetAlmacenMateriaPrimaPorMateriaPrimaAsync(model.MateriaPrimaId);
                if(almacenmateriaprima.Cantidad < model.Cantidad)
                {
                    return this.RedirectToAction("InventarioInsuficiente");
                }

                await this.pedidoMateriaPrimaRepository.AddPedidoDeMateriaPrimaAsync(model);

                //hacer funcion para que envie al index de desechos almacen
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        public IActionResult Index()
        {
            return View(this.pedidoMateriaPrimaRepository.GetPedidoMateriaPrimaAll());

        }

        public IActionResult PedidosDeMateriaPrimaEnSolicitud()
        {
            return View(this.pedidoMateriaPrimaRepository.GetPedidoMateriaPrimaSolicitud());

        }

        //para mostrar los pedidos procesados de un empleado 
        public async Task<IActionResult> PedidosDeMateriaProcesado()
        {
            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            var empleado = await this.EmpleadoRepository.GetEmpleadoPorCarnet(user.Ci);
            if(empleado == null)
            {
                return NotFound();

            }
            return View(this.pedidoMateriaPrimaRepository.GetPedidoMateriaPrimaProcesado(empleado));
        }

        public async Task<IActionResult> CambiarEstadoPedido(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await this.pedidoMateriaPrimaRepository.GetPedidoMateriaPrimaAllAsync(id.Value);
            if (pedido == null)
            {
                return NotFound();
            }

            var almacen = await this.almacenMateriaPrimaRepository.GetAlmacenMateriaPrimaPorMateriaPrimaAsync(pedido.MateriaPrima.Id);
            if(almacen == null)
            {
                return NotFound();
            }

            await this.pedidoMateriaPrimaRepository.CambiarEstadoAsync(pedido,almacen);
            return this.RedirectToAction("ConfirmarCambioDeEstadoPedido");
        }


        public IActionResult ConfirmarCambioDeEstadoPedido()
        {
            return this.View();
        }



        public IActionResult InventarioInsuficiente()
        {
            return this.View();
        }


    }
}
