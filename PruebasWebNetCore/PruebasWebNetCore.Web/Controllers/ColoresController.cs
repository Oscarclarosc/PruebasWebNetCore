

namespace PruebasWebNetCore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Data.Entities;
    using Data.Repositories;
    using System.Threading.Tasks;
    using PruebasWebNetCore.Web.Models;
    using System.IO;
    using System;
    using Microsoft.AspNetCore.Authorization;
    using PruebasWebNetCore.Web.Helpers;

    [Authorize]
    public class ColoresController : Controller
    {
        //private readonly DataContext _context;
        private readonly IColorRepository colorRepository;

        public ColoresController(IColorRepository colorRepository)
        {
            //_context = context;
            this.colorRepository = colorRepository;
        }

        // GET: Colores
        public IActionResult Index()
        {
            return View(this.colorRepository.GetAll());
        }

        //TODO:Falta agreagar mostrar la imagen en la vista de detalles
        // GET: Colores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ColorNotFound");
            }

            var color = await this.colorRepository.GetByIdAsync(id.Value);
            if (color == null)
            {
                return new NotFoundViewResult("ColorNotFound");
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
        public async Task<IActionResult> Create(ColorViewModel view)
        {
            if (ModelState.IsValid)
            {
                //para la imagen
                var path = string.Empty;

                if (view.ImagenFile != null && view.ImagenFile.Length > 0)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), 
                        "wwwroot\\images\\Colores", 
                        view.ImagenFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImagenFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Colores/{view.ImagenFile.FileName}";
                }


                var color = this.ToColor(view, path);

                await this.colorRepository.CreateAsync(color);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }


        //buscar otra forma de hacer esto
        private Color ToColor(ColorViewModel view, string path)
        {
            return new Color
            {
                Id=view.Id,
                ImagenUrl = path,
                Nombre = view.Nombre,
                Codigo = view.Codigo,
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

            var color = await this.colorRepository.GetByIdAsync(id.Value);
            if (color == null)
            {
                return NotFound();
            }

            var view = this.ToColorViewModel(color);

            return View(view);
        }

        private ColorViewModel ToColorViewModel(Color color)
        {
            return new ColorViewModel
            {
                Id = color.Id,
                ImagenUrl = color.ImagenUrl,
                Nombre = color.Nombre,
                Codigo = color.Codigo,
                Estado = color.Estado
            };
        }

        // POST: Colores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ColorViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImagenUrl;

                    if (view.ImagenFile != null && view.ImagenFile.Length > 0)
                    {
                        path = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Colores",
                            view.ImagenFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImagenFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Colores/{view.ImagenFile.FileName}";
                    }


                    var color = this.ToColor(view, path);
                    await this.colorRepository.UpdateAsync(color);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.colorRepository.ExistAsync(view.Id))
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

            var color = await this.colorRepository.GetByIdAsync(id.Value);
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
            var color = await this.colorRepository.GetByIdAsync(id);
            await this.colorRepository.DeleteAsync(color);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ColorNotFound()
        {
            return this.View();
        }

    }
}
