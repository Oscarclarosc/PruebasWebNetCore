
namespace PruebasWebNetCore.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Data.Repositories;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class ProductosController:Controller
    {
        private readonly IProductoRepository productoRepository;
        private readonly IColorRepository colorRepository;

        public ProductosController(IProductoRepository productoRepository, IColorRepository colorRepository)
        {
            this.productoRepository = productoRepository;
            this.colorRepository = colorRepository;
        }

        public IActionResult Index()
        {
            return View(this.productoRepository.GetProductoWithColor());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await this.productoRepository.GetByIdAsync(id.Value);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        public IActionResult Create()
        {
            var model = new ProductoViewModel
            {
                Colores = this.colorRepository.GetComboColors()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this.productoRepository.AddProductoAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await this.productoRepository.GetByIdAsync(id.Value);
            if (producto == null)
            {
                return NotFound();
            }

            var model = this.ToProductoViewModel(producto);

            return View(model);
        }

        private ProductoViewModel ToProductoViewModel(Producto producto)
        {
            return new ProductoViewModel
            {
                ProductoId = producto.Id,
                Ancho = producto.Ancho,
                Espesor = producto.Espesor,
                Largo = producto.Largo,
                Material = producto.Material,
                TipoAcabado = producto.TipoAcabado,
                TipoCorte = producto.TipoCorte,
                Codigo = producto.Codigo,
                Estado = producto.Estado,
                ColorId = producto.ColorId,
                Colores = this.colorRepository.GetComboColors()
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductoViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this.productoRepository.UpdateProductoAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await this.productoRepository.GetByIdAsync(id.Value);
            if (producto == null)
            {
                return NotFound();
            }

            await this.productoRepository.DeleteAsync(producto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductoNotFound()
        {
            return this.View();
        }







    }
}
