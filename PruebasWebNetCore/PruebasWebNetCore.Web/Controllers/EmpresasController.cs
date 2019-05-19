

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Data.Entities;
    using Data.Repositories;
    using Helpers;
    using System.Threading.Tasks;
    using PruebasWebNetCore.Web.Models;

    public class EmpresasController : Controller
    {
        private readonly IEmpresaRepository empresaRepository;

        public EmpresasController(IEmpresaRepository empresaRepository)
        {
            this.empresaRepository = empresaRepository;
        }

        ///Telefono
        public async Task<IActionResult> DeleteTelefono(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await this.empresaRepository.GetTelefonoAsync(id.Value);
            if (telefono == null)
            {
                return NotFound();
            }

            var empresaId = await this.empresaRepository.DeleteTelefonoAsync(telefono);
            //TODO: arreglar
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> EditTelefono(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await this.empresaRepository.GetTelefonoAsync(id.Value);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        [HttpPost]
        public async Task<IActionResult> EditTelefono(Telefono telefono)
        {
            if (this.ModelState.IsValid)
            {
                var empresaId = await this.empresaRepository.UpdateTelefonoAsync(telefono);
                if (empresaId != 0)
                {
                    //TODO: revisar por que esta cosa me da error
                    return this.RedirectToAction("Index");
                }
            }

            return this.View(telefono);
        }

        public async Task<IActionResult> AddTelefono(int? id)
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

            var model = new TelefonoViewModel { PoseedorId = empresa.Id };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTelefono(TelefonoViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.empresaRepository.AddTelefonoAsync(model);
                //TODO: revisar por que esta cosa me da error
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        //Direcciones
        public async Task<IActionResult> DeleteDireccion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await this.empresaRepository.GetDireccionAsync(id.Value);
            if (direccion == null)
            {
                return NotFound();
            }

            var empresaId = await this.empresaRepository.DeleteDireccionAsync(direccion);
            //TODO: arreglar
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> EditDireccion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await this.empresaRepository.GetDireccionAsync(id.Value);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        [HttpPost]
        public async Task<IActionResult> EditDireccion(Direccion direccion)
        {
            if (this.ModelState.IsValid)
            {
                var empresaId = await this.empresaRepository.UpdateDireccionAsync(direccion);
                if (empresaId != 0)
                {
                    //TODO: revisar por que esta cosa me da error
                    return this.RedirectToAction("Index");
                }
            }

            return this.View(direccion);
        }

        public async Task<IActionResult> AddDireccion(int? id)
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

            var model = new DireccionViewModel { PoseedorId = empresa.Id };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDireccion(DireccionViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.empresaRepository.AddDireccionAsync(model);
                //TODO: revisar por que esta cosa me da error
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }


        // GET
        public IActionResult Index()
        {
            return View(this.empresaRepository.GetEmpresasConDireccionesYTelefonos());
        }

        // GET
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("EmpresaNotFound");
            }

            var empresa = await this.empresaRepository.GetEmpresaConDireccionYTelefonoAsync(id.Value);
            if (empresa == null)
            {
                return new NotFoundViewResult("EmpresaNotFound");
            }

            return View(empresa);
        }




        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
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

        // GET
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

        // POST
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

        // GET
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

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await this.empresaRepository.GetByIdAsync(id);
            await this.empresaRepository.DeleteAsync(empresa);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EmpresaNotFound()
        {
            return this.View();
        }

    }
}
