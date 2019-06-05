

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Data.Repositories;
    using PruebasWebNetCore.Web.Helpers;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProveedoresController:Controller
    {
        private readonly IProveedorRepository proveedorRepository;

        public ProveedoresController(IProveedorRepository proveedorRepository)
        {
            this.proveedorRepository = proveedorRepository;
        }

        ///Telefono
        public async Task<IActionResult> DeleteTelefono(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await this.proveedorRepository.GetTelefonoAsync(id.Value);
            if (telefono == null)
            {
                return NotFound();
            }

            var empresaId = await this.proveedorRepository.DeleteTelefonoAsync(telefono);
            //TODO: arreglar
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> EditTelefono(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await this.proveedorRepository.GetTelefonoAsync(id.Value);
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
                var empresaId = await this.proveedorRepository.UpdateTelefonoAsync(telefono);
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

            var empresa = await this.proveedorRepository.GetByIdAsync(id.Value);
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
                await this.proveedorRepository.AddTelefonoAsync(model);
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

            var direccion = await this.proveedorRepository.GetDireccionAsync(id.Value);
            if (direccion == null)
            {
                return NotFound();
            }

            var empresaId = await this.proveedorRepository.DeleteDireccionAsync(direccion);
            //TODO: arreglar
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> EditDireccion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await this.proveedorRepository.GetDireccionAsync(id.Value);
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
                var empresaId = await this.proveedorRepository.UpdateDireccionAsync(direccion);
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

            var empresa = await this.proveedorRepository.GetByIdAsync(id.Value);
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
                await this.proveedorRepository.AddDireccionAsync(model);
                //TODO: revisar por que esta cosa me da error
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }


        // GET
        public IActionResult Index()
        {
            return View(this.proveedorRepository.GetProveedorConDireccionesYTelefonos());
        }

        // GET
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProveedorNotFound");
            }

            var empresa = await this.proveedorRepository.GetProveedorConDireccionYTelefonoAsync(id.Value);
            if (empresa == null)
            {
                return new NotFoundViewResult("ProveedorNotFound");
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
        public async Task<IActionResult> Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                await this.proveedorRepository.CreateAsync(proveedor);
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }

        // GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await this.proveedorRepository.GetByIdAsync(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.proveedorRepository.UpdateAsync(proveedor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.proveedorRepository.ExistAsync(proveedor.Id))
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
            return View(proveedor);
        }

        // GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await this.proveedorRepository.GetByIdAsync(id.Value);
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
            var empresa = await this.proveedorRepository.GetByIdAsync(id);
            await this.proveedorRepository.DeleteAsync(empresa);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProveedorNotFound()
        {
            return this.View();
        }





    }
}
