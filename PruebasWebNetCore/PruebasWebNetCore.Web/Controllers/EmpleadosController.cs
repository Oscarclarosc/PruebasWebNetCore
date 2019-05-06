

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
    using System.Threading.Tasks;

    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository empleadoRepository;

        public EmpleadosController(IEmpleadoRepository empleadoRepository)
        {
            this.empleadoRepository = empleadoRepository;
        }

        //GET
        public IActionResult Index()
        {
            return View(this.empleadoRepository.GetAll());
        }

        // GET: Colores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("EmpleadoNotFound");
            }

            var empleado = await this.empleadoRepository.GetByIdAsync(id.Value);
            if (empleado == null)
            {
                return new NotFoundViewResult("EmpleadoNotFound");
            }

            return View(empleado);
        }


        // GET: Colores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colores/Create
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

        // GET: Colores/Edit/5
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

        // POST: Colores/Edit/5
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

        // GET: Colores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await this.empleadoRepository.GetByIdAsync(id.Value);
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
            var color = await this.empleadoRepository.GetByIdAsync(id);
            await this.empleadoRepository.DeleteAsync(color);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ColorNotFound()
        {
            return this.View();
        }


    }
}
