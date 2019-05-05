

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PruebasWebNetCore.Web.Data.Repositories;

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

        public IActionResult Create()
        {
            

            return View();
        }



    }
}
