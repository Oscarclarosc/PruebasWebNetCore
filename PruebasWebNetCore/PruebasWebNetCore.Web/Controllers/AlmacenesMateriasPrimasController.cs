

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

    public class AlmacenesMateriasPrimasController:Controller
    {
        private readonly IAlmacenMateriaPrimaRepository almacenMateriaPrimaRepository;
        private readonly IMateriaPrimaRepository materiaPrimaRepository;
        private readonly IUserHelper userHelper;

        public AlmacenesMateriasPrimasController(IAlmacenMateriaPrimaRepository almacenMateriaPrimaRepository, IMateriaPrimaRepository materiaPrimaRepository, IUserHelper userHelper)
        {
            this.almacenMateriaPrimaRepository = almacenMateriaPrimaRepository;
            this.materiaPrimaRepository = materiaPrimaRepository;
            this.userHelper = userHelper;
        }


        //GET
        public async Task<IActionResult> Create()
        {

            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);

            var model = new AlmacenMateriaPrimaViewModel
            {
                UserId = user.Id,
                MateriasPrimas = this.materiaPrimaRepository.GetComboMateriasPrimas(),
            };

            return View(model);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(AlmacenMateriaPrimaViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.almacenMateriaPrimaRepository.AddAlmacenMateriaPrimaAsync(model);

                //hacer funcion para que envie al index de desechos almacen
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        
         public IActionResult Index()
         {
            return View(this.almacenMateriaPrimaRepository.GetAlmacenMaterialPrimaAll());
         }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("AlmacenMateriaPrimaNotFound");
            }

            var almacen = await this.almacenMateriaPrimaRepository.GetAlmacenMateriaPrimaAllAsync(id.Value);
            if (almacen == null)
            {
                return new NotFoundViewResult("AlmacenMateriaPrimaNotFound");
            }

            return View(almacen);
        }


        public IActionResult AlmacenMateriaPrimaNotFound()
        {
            return this.View();
        }


    }
}
