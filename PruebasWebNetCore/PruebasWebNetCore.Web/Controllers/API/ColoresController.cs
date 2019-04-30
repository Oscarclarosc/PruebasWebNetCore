

namespace PruebasWebNetCore.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using PruebasWebNetCore.Web.Data.Repositories;

    [Route("api/[Controller]")]
    public class ColoresController : Controller
    {
        private readonly IColorRepository colorRepository;

        public ColoresController(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        [HttpGet]
        public IActionResult GetColores()
        {
            return Ok(this.colorRepository.GetAll());
        }


    }
}
