

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Data.Entities;
    using Data.Repositories;
    using Models;
    using System.Threading.Tasks;

    [Authorize]
    public class ProductosController : Controller
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
            return View(this.productoRepository.GetAll());
        }

        //GET
        public IActionResult Create()
        {
            var model = new ProductoViewModel
            {
                Colores = this.colorRepository.GetComboColors()
            };

            return this.View(model);
        }

        //POST
        //TODO: validar que el color no exista
        [HttpPost]
        public async Task<IActionResult> Create(ProductoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var color = await this.colorRepository.GetByIdAsync(model.ColorId);
                
                var producto = new Producto
                {
                    Id = model.Id,
                    Ancho = model.Ancho,
                    Largo = model.Largo,
                    Espesor = model.Espesor,
                    Estado = model.Estado,
                    TipoCorte = model.TipoCorte,
                    TipoAcabado = model.TipoAcabado,
                    Material = model.Material,
                    Color=color
                };

                await this.productoRepository.CreateAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


    }
}
