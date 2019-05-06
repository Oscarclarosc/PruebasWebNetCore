

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Data.Entities;
    using Data.Repositories;
    using Helpers;
    using System.Threading.Tasks;

    public class EmpresasController : Controller
    {
        private readonly IEmpresaRepository empresaRepository;

        public EmpresasController(IEmpresaRepository empresaRepository)
        {
            this.empresaRepository = empresaRepository;
        }

        // GET: Colores
        public IActionResult Index()
        {
            return View(this.empresaRepository.GetAll());
        }

        // GET: Colores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("EmpresaNotFound");
            }

            var empresa = await this.empresaRepository.GetByIdAsync(id.Value);
            if (empresa == null)
            {
                return new NotFoundViewResult("EmpresaNotFound");
            }

            return View(empresa);
        }

        // GET: Impresiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Impresiones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                await this.empresaRepository.CreateAsync(empresa);
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        // GET: Impresiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await this.empresaRepository.GetByIdAsync(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        // POST: Impresiones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.empresaRepository.UpdateAsync(empresa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.empresaRepository.ExistAsync(empresa.Id))
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
            return View(empresa);
        }

        // GET: Impresiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await this.empresaRepository.GetByIdAsync(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Impresiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await this.empresaRepository.GetByIdAsync(id);
            await this.empresaRepository.DeleteAsync(empresa);
            return RedirectToAction(nameof(Index));
        }



    }
}
