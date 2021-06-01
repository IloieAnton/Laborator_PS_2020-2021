using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSalon.Data;
using WebSalon.Models;
using WebSalon.Services;

namespace WebSalon.Controllers
{
    [Authorize(Roles = "User")]
    public class ServiciuController : Controller
    {
        private readonly IServiciuService _serviciuService;

        public ServiciuController(WebSalonContext context)
        {
            _serviciuService = new ServiciuService(context);
        }

        // GET: Serviciu
        public async Task<IActionResult> Index()
        {
            var servicii = _serviciuService.GetServicii();
            return View(servicii.ToList());
        }

        // GET: Serviciu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Serviciu serviciu = _serviciuService.GetServiciu(id.GetValueOrDefault());
            if (serviciu == null)
            {
                return NotFound();
            }

            return View(serviciu);
        }

        // GET: Serviciu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Serviciu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiciuId,numeServiciu,pret")] Serviciu serviciu)
        {
            if (ModelState.IsValid)
            {
                _serviciuService.AdaugareServiciu(serviciu);
                return RedirectToAction(nameof(Index));
            }
            return View(serviciu);
        }

        // GET: Serviciu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Serviciu serviciu = _serviciuService.GetServiciu(id.GetValueOrDefault());
            if (serviciu == null)
            {
                return NotFound();
            }
            return View(serviciu);
        }

        // POST: Serviciu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiciuId,numeServiciu,pret")] Serviciu serviciu)
        {
            if (id != serviciu.ServiciuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _serviciuService.UpdateServiciu(serviciu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiciuExists(serviciu.ServiciuId))
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
            return View(serviciu);
        }

        // GET: Serviciu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Serviciu serviciu = _serviciuService.GetServiciu(id.GetValueOrDefault());
            if (serviciu == null)
            {
                return NotFound();
            }

            return View(serviciu);
        }

        // POST: Serviciu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Serviciu serviciu = _serviciuService.GetServiciu(id);
            _serviciuService.StergereServiciu(serviciu);
            return RedirectToAction(nameof(Index));
        }

        private bool ServiciuExists(int id)
        {
            return (_serviciuService.GetServiciu(id) != null);
        }
    }
}
