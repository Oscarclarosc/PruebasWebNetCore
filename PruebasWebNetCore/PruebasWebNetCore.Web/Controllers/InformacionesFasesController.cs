﻿

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Data.Repositories;
    using PruebasWebNetCore.Web.Helpers;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class InformacionesFasesController : Controller
    {
        private readonly IInformacionFaseRepository informacionFaseRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IUserHelper userHelper;
        private readonly IEmpleadoRepository empleadoRepository;

        public InformacionesFasesController(IInformacionFaseRepository informacionFaseRepository, IPedidoRepository pedidoRepository, IUserHelper userHelper,IEmpleadoRepository empleadoRepository)
        {
            this.informacionFaseRepository = informacionFaseRepository;
            this.pedidoRepository = pedidoRepository;
            this.userHelper = userHelper;
            this.empleadoRepository = empleadoRepository;
        }

        //Desecho
        public async Task<IActionResult> AddDesecho(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informacion = await this.informacionFaseRepository.GetByIdAsync(id.Value);
            if (informacion == null)
            {
                return NotFound();
            }

            var model = new DesechoViewModel
            {
                InformacionFaseId = informacion.Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDesecho(DesechoViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.informacionFaseRepository.AddDesechoAsync(model);
                //TODO: revisar por que esta cosa me da error
                return this.RedirectToAction("InformacionFaseActual");
            }

            return this.View(model);
        }

        public async Task<IActionResult> CambiarEstadoDesecho(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desecho = await this.informacionFaseRepository.GetDesechoAsync(id.Value);
            if (desecho == null)
            {
                return NotFound();
            }

            await this.informacionFaseRepository.CambiarEstadoEnAlmacen(desecho);
            return new NotFoundViewResult("DesechoEnAlmacen");
        }

        public IActionResult DesechosIndex()
        {
            return View(this.informacionFaseRepository.GetDesechosAll());
        }


        //ProductoTerminado
        public async Task<IActionResult> AddProductoTerminado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informacion = await this.informacionFaseRepository.GetByIdAsync(id.Value);
            if (informacion == null)
            {
                return NotFound();
            }

            var model = new ProductoTerminadoViewModel
            {
                InformacionFaseId = informacion.Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductoTerminado(ProductoTerminadoViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.informacionFaseRepository.AddProductoTerminadoAsync(model);
                //TODO: revisar por que esta cosa me da error
                return this.RedirectToAction("InformacionFaseActual");
            }

            return this.View(model);
        }



        //GET
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await this.pedidoRepository.GetByIdAsync(id.Value);
            if (pedido == null)
            {
                return NotFound();
            }

            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);

            var model = new InformacionFaseViewModel
            {
                PedidoId = pedido.Id,
                UserId = user.Id,
            };

            return View(model);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(InformacionFaseViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.informacionFaseRepository.AddInformacionFaseAsync(model);
                //TODO: revisar por que esta cosa me da error
                return this.RedirectToAction("InformacionFaseActual");
            }

            return this.View(model);
        }

        public async Task<IActionResult> InformacionFaseActual()
        {

            var user = await this.userHelper.GetUserByEmailAsync(User.Identity.Name);
            var informacion = await this.informacionFaseRepository.GetInformacionFasePorEmpleadoAsync(user);


            if (user.Disponible == false && informacion !=null) {
                return View(informacion);
            }
            else
            {
                return new NotFoundViewResult("NoEnProceso");
            }
            
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var informacion = await this.informacionFaseRepository.GetInformacionFaseDetalle(id.Value);
            if (informacion == null)
            {
                return NotFound();
            }

            return View(informacion);

        }


        public async Task<IActionResult> InformacionFasePorPedido(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var pedido = await this.pedidoRepository.GetByIdAsync(id.Value);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(this.informacionFaseRepository.GetInformacionFasePorPedido(pedido.Id));

        }

        //cambia el estado del pedido a la proxima fase y el usuario a disponible
        //esto deberia estar en pedido controller no aqui gg
        public async Task<IActionResult> CambiarEstadoPedidoUsuario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await this.pedidoRepository.GetByIdAsync(id.Value);
            if (pedido == null)
            {
                return NotFound();
            }

            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            await this.pedidoRepository.CabiarEstadoAsync(pedido);
            await this.userHelper.CambiarEstadoDisponible(user);
            return new NotFoundViewResult("FaseFinalizada");
        }


        public IActionResult NoEnProceso()
        {
            return this.View();
        }

        public IActionResult FaseFinalizada()
        {
            return this.View();
        }

        public IActionResult DesechoEnAlmacen()
        {
            return this.View();
        }



    }
}
