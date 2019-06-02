

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Data.Repositories;
    using PruebasWebNetCore.Web.Models;
    using System.Threading.Tasks;

    public class MateriasPrimasController : Controller
    {
        private readonly IMateriaPrimaRepository materiaPrimaRepository;
        private readonly IColorRepository colorRepository;

        public MateriasPrimasController(IMateriaPrimaRepository materiaPrimaRepository, IColorRepository colorRepository)
        {
            this.materiaPrimaRepository = materiaPrimaRepository;
            this.colorRepository = colorRepository;
        }

        public IActionResult Index()
        {
            return View(this.materiaPrimaRepository.GetMateriaPrimaWithColor());
        }




        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrima = await this.materiaPrimaRepository.GetByIdAsync(id.Value);
            if (materiaPrima == null)
            {
                return NotFound();
            }

            return View(materiaPrima);
        }

        public IActionResult Create()
        {
            var model = new MateriaPrimaViewModel
            {
                Colores = this.colorRepository.GetComboColors()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MateriaPrimaViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this.materiaPrimaRepository.AddMateriaPrimaAsync(model);
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

            var materiaPrima = await this.materiaPrimaRepository.GetByIdAsync(id.Value);
            if (materiaPrima == null)
            {
                return NotFound();
            }

            var model = this.ToMateriaPimaViewModel(materiaPrima);

            return View(model);
        }

        private MateriaPrimaViewModel ToMateriaPimaViewModel(MateriaPrima materiaPrima)
        {
            return new MateriaPrimaViewModel
            {
                MateriaPrimaId = materiaPrima.Id,
                Clase = materiaPrima.Clase,
                Estado = materiaPrima.Estado,
                Nombre = materiaPrima.Nombre,
                Tipo = materiaPrima.Tipo,
                Observaciones = materiaPrima.Observaciones,
                ColorId = materiaPrima.ColorId,
                Colores = this.colorRepository.GetComboColors()
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MateriaPrimaViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this.materiaPrimaRepository.UpdateMateriaPrimaAsync(model);
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

            var materiaprima = await this.materiaPrimaRepository.GetByIdAsync(id.Value);
            if (materiaprima == null)
            {
                return NotFound();
            }

            await this.materiaPrimaRepository.DeleteAsync(materiaprima);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult MateriaPrimaNotFound()
        {
            return this.View();
        }


    }
}
