﻿

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PruebasWebNetCore.Web.Data.Repositories;
    using PruebasWebNetCore.Web.Helpers;
    using PruebasWebNetCore.Web.Models;
    using System.Threading.Tasks;

    public class PedidosController : Controller
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IProductoRepository productoRepository;
        private readonly IColorRepository colorRepository;

        public PedidosController(IPedidoRepository pedidoRepository, IEmpresaRepository empresaRepository, IProductoRepository productoRepository, IColorRepository colorRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.empresaRepository = empresaRepository;
            this.productoRepository = productoRepository;
            this.colorRepository = colorRepository;
        }


        public async Task<IActionResult> AddImpresion(int? id)
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

            var model = new ImpresionPedidoViewModel {
                PedidoId = pedido.Id,
                Colores = this.colorRepository.GetComboColors()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddImpresion(ImpresionPedidoViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.pedidoRepository.AddImpresionAsync(model);
                //TODO: revisar por que esta cosa me da error
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }






        public IActionResult Index()
        {
            return View(this.pedidoRepository.GetPedidoWithAll());

        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("PedidoNotFound");
            }

            var pedido = await this.pedidoRepository.GetPedidoConImpresionAsync(id.Value);
            if (pedido == null)
            {
                return new NotFoundViewResult("PedidoNotFound");
            }

            return View(pedido);
        }


        //GET
        public IActionResult Create()
        {
            var model = new PedidoViewModel
            {
                //
                Empresas = this.empresaRepository.GetComboEmpresas(),
                Productos = this.productoRepository.GetComboProductos(),
            };
            return View(model);
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoViewModel view)
        {
            if (ModelState.IsValid)
            {
                await this.pedidoRepository.AddPedidoAsync(view);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        public IActionResult PedidoNotFound()
        {
            return this.View();
        }



    }
}
