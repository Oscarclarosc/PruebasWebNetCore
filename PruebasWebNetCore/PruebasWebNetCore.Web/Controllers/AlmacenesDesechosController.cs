
namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PruebasWebNetCore.Web.Data.Repositories;
    using PruebasWebNetCore.Web.Helpers;
    using PruebasWebNetCore.Web.Models;
    using System.Threading.Tasks;

    public class AlmacenesDesechosController : Controller
    {
        private readonly IAlmacenDesechoRepository almacenDesechoRepository;
        private readonly IInformacionFaseRepository informacionFaseRepository;
        private readonly IUserHelper userHelper;

        public AlmacenesDesechosController(IAlmacenDesechoRepository almacenDesechoRepository, IInformacionFaseRepository informacionFaseRepository, IUserHelper userHelper)
        {
            this.almacenDesechoRepository = almacenDesechoRepository;
            this.informacionFaseRepository = informacionFaseRepository;
            this.userHelper = userHelper;
        }

        //GET
        public async Task<IActionResult> Create(int? id)
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


            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            await this.informacionFaseRepository.CambiarEstadoEnAlmacen(desecho);

            var model = new AlmacenDesechoViewModel
            {
                DesechoId = desecho.Id,
                UserId = user.Id
            };

            return View(model);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(AlmacenDesechoViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.almacenDesechoRepository.AddAlmacenDesechoAsync(model);
                
                //hacer funcion para que envie al index de desechos almacen
                return this.RedirectToAction("InformacionFaseActual");
            }

            return this.View(model);
        }

        public IActionResult Index()
        {
            return View(this.almacenDesechoRepository.GetAlmacenDesechoAll());
        }





    }
}
