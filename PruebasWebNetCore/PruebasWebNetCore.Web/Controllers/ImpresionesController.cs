using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebasWebNetCore.Web.Data;
using PruebasWebNetCore.Web.Data.Entities;
using PruebasWebNetCore.Web.Data.Repositories;

namespace PruebasWebNetCore.Web.Controllers
{
    public class ImpresionesController : Controller
    {
        private readonly IImpresionRepository impresionRepository;

        public ImpresionesController(IImpresionRepository impresionRepository)
        {
            this.impresionRepository = impresionRepository;
        }

        // GET: Impresiones
        public IActionResult Index()
        {
            return View(this.impresionRepository.GetAll());
        }

        // GET: Impresiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impresionPedido = await this.impresionRepository.GetByIdAsync(id.Value);
            if (impresionPedido == null)
            {
                return NotFound();
            }

            return View(impresionPedido);
        }

        // GET: Impresiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Impresiones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImpresionPedido impresionPedido)
        {
            if (ModelState.IsValid)
            {
                await this.impresionRepository.CreateAsync(impresionPedido);
                return RedirectToAction(nameof(Index));
            }
            return View(impresionPedido);
        }

        // GET: Impresiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impresionPedido = await this.impresionRepository.GetByIdAsync(id.Value);
            if (impresionPedido == null)
            {
                return NotFound();
            }
            return View(impresionPedido);
        }

        // POST: Impresiones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ImpresionPedido impresionPedido)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.impresionRepository.UpdateAsync(impresionPedido);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.impresionRepository.ExistAsync(impresionPedido.Id))
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
            return View(impresionPedido);
        }

        // GET: Impresiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impresionPedido = await this.impresionRepository.GetByIdAsync(id.Value);
            if (impresionPedido == null)
            {
                return NotFound();
            }

            return View(impresionPedido);
        }

        // POST: Impresiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var impresionPedido = await this.impresionRepository.GetByIdAsync(id);
            await this.impresionRepository.DeleteAsync(impresionPedido);
            return RedirectToAction(nameof(Index));
        }

    }
}
