

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Data.Repositories;
    using PruebasWebNetCore.Web.Helpers;
    using PruebasWebNetCore.Web.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository empleadoRepository;
        private readonly ICountryRepository countryRepository;

        public EmpleadosController(IEmpleadoRepository empleadoRepository, ICountryRepository countryRepository)
        {
            this.empleadoRepository = empleadoRepository;
            this.countryRepository = countryRepository;
        }


        ///Telefono
        public async Task<IActionResult> DeleteTelefono(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await this.empleadoRepository.GetTelefonoAsync(id.Value);
            if (telefono == null)
            {
                return NotFound();
            }

            var empleadoId = await this.empleadoRepository.DeleteTelefonoAsync(telefono);
            //TODO: arreglar
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> EditTelefono(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await this.empleadoRepository.GetTelefonoAsync(id.Value);
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
                var empleadoId = await this.empleadoRepository.UpdateTelefonoAsync(telefono);
                if (empleadoId != 0)
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

            var empleado = await this.empleadoRepository.GetByIdAsync(id.Value);
            if (empleado == null)
            {
                return NotFound();
            }

            var model = new TelefonoViewModel { PoseedorId = empleado.Id };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTelefono(TelefonoViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.empleadoRepository.AddTelefonoAsync(model);
                //TODO: revisar por que esta cosa me da error
                return this.RedirectToAction("Index");
            }

            return this.View(model); 
        }




        //Direcciones
        //para cascade dropdown list
        public async Task<JsonResult> GetCitiesAsync(int countryId)
        {
            var country = await this.countryRepository.GetCountryWithCitiesAsync(countryId);
            return this.Json(country.Cities.OrderBy(c => c.Name));
        }

        public async Task<IActionResult> DeleteDireccion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await this.empleadoRepository.GetDireccionAsync(id.Value);
            if (direccion == null)
            {
                return NotFound();
            }

            var empleadoId = await this.empleadoRepository.DeleteDireccionAsync(direccion);
            //TODO: arreglar
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> EditDireccion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await this.empleadoRepository.GetDireccionAsync(id.Value);
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
                var empleadoId = await this.empleadoRepository.UpdateDireccionAsync(direccion);
                if (empleadoId != 0)
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

            var empleado = await this.empleadoRepository.GetByIdAsync(id.Value);
            if (empleado == null)
            {
                return NotFound();
            }

            var model = new DireccionViewModel {
                PoseedorId = empleado.Id,
                Countries = this.countryRepository.GetComboCountries(),
                Cities=this.countryRepository.GetComboCities(0)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDireccion(DireccionViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                
                await this.empleadoRepository.AddDireccionAsync(model);
                //TODO: revisar por que esta cosa me da error
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }




        public IActionResult Index()
        {
            return View(this.empleadoRepository.GetEmpleadosConDireccionesYTelefonos());
        }

        // GET: 
        //TODO: hacer que salga el nombre de la ciudad y no solo el id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("EmpleadoNotFound");
            }

            var empleado = await this.empleadoRepository.GetEmpleadoConDireccionYTelefonoAsync(id.Value);
            if (empleado == null)
            {
                return new NotFoundViewResult("EmpleadoNotFound");
            }

            return View(empleado);
        }



        // GET: 
        public IActionResult Create()
        {
            return View();
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpleadoViewModel view)
        {
            if (ModelState.IsValid)
            {
                //para la imagen
                var path = string.Empty;

                if (view.ImagenFile != null && view.ImagenFile.Length > 0)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Empleados",
                        view.ImagenFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImagenFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Empleados/{view.ImagenFile.FileName}";
                }


                var empleado = this.ToEmpleado(view, path);

                await this.empleadoRepository.CreateAsync(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Empleado ToEmpleado(EmpleadoViewModel view, string path)
        {
            return new Empleado
            {
                Id = view.Id,
                ImagenUrl = path,
                Nombre = view.Nombre,
                ApellidoPaterno = view.ApellidoPaterno,
                ApellidoMaterno = view.ApellidoMaterno,
                Ci = view.Ci,
                FechaNacimiento = view.FechaNacimiento,
                Cargo = view.Cargo,
                FechaContrato = view.FechaContrato,
                HoraEntrada = view.HoraEntrada,
                Estado = view.Estado
            };
        }

        // GET: 
        //TODO: hacer que que traiga el dato de fecha de nacimineto y fecha de contratacion
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await this.empleadoRepository.GetByIdAsync(id.Value);
            if (empleado == null)
            {
                return NotFound();
            }

            var view = this.ToEmpleadoViewModel(empleado);

            return View(view);
        }

        private EmpleadoViewModel ToEmpleadoViewModel(Empleado empleado)
        {
            return new EmpleadoViewModel
            {
                Id = empleado.Id,
                ImagenUrl = empleado.ImagenUrl,
                Nombre = empleado.Nombre,
                ApellidoPaterno = empleado.ApellidoPaterno,
                ApellidoMaterno = empleado.ApellidoMaterno,
                Ci = empleado.Ci,
                FechaNacimiento = empleado.FechaNacimiento,
                Cargo = empleado.Cargo,
                FechaContrato = empleado.FechaContrato,
                HoraEntrada = empleado.HoraEntrada,
                Estado = empleado.Estado
            };
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmpleadoViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImagenUrl;

                    if (view.ImagenFile != null && view.ImagenFile.Length > 0)
                    {
                        path = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Empleados",
                            view.ImagenFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImagenFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Empleados/{view.ImagenFile.FileName}";
                    }


                    var color = this.ToEmpleado(view, path);
                    await this.empleadoRepository.UpdateAsync(color);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.empleadoRepository.ExistAsync(view.Id))
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
            return View(view);
        }

        // GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await this.empleadoRepository.GetByIdAsync(id.Value);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var color = await this.empleadoRepository.GetByIdAsync(id);
            await this.empleadoRepository.DeleteAsync(color);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EmpleadoNotFound()
        {
            return this.View();
        }


    }
}
