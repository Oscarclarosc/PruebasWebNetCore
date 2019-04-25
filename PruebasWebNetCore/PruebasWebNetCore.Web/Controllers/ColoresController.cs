

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Data.Entities;
    using Data.Repositories;
    using System.Threading.Tasks;

    public class ColoresController : Controller
    {
        private readonly IColoresRepository coloresRepository;

        public ColoresController(IColoresRepository coloresRepository)
        {
            this.coloresRepository = coloresRepository;
        }

        // GET: Colores
        public IActionResult Index()
        {
            return View(this.coloresRepository.GetAll());
        }

        // GET: Colores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await this.coloresRepository.GetByIdAsync(id.Value);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }


        // GET: Colores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Color color)
        {
            if (ModelState.IsValid)
            {
                await this.coloresRepository.CreateAsync(color);
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        // GET: Colores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await this.coloresRepository.GetByIdAsync(id.Value);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }

        // POST: Colores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Color color)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await this.coloresRepository.UpdateAsync(color);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.coloresRepository.ExistAsync(color.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        // GET: Colores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await this.coloresRepository.GetByIdAsync(id.Value);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // POST: Colores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var color = await this.coloresRepository.GetByIdAsync(id);
            await this.coloresRepository.DeleteAsync(color);
            return RedirectToAction(nameof(Index));
        }

    }
}
