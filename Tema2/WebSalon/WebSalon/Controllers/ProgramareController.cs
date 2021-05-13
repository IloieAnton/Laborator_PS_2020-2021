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
    [Authorize]
    public class ProgramareController : Controller
    {
        private readonly IProgramareService _programareService;


        public ProgramareController(WebSalonContext context)
        {
            this._programareService = new ProgramareService(context);
        }

        // GET: Programare
        public async Task<IActionResult> Index(string numeClient, DateTime pdataI, DateTime pdataF)
        {
            ProgramareDataViewModel programareDataViewModel = new ProgramareDataViewModel();
            var programari = _programareService.GetProgramari();
            programareDataViewModel.programari = programari.ToList();
            programareDataViewModel = _programareService.GetProgramareDataInceputFinal(pdataI, pdataF);
            if (pdataF == DateTime.Parse("1/1/0001") && pdataI == DateTime.Parse("1/1/0001"))
            {
                programareDataViewModel.programari = programari.ToList();
            }
            if (!String.IsNullOrEmpty(numeClient))
            {
                programari = _programareService.GetProgramareClient(numeClient);
                programareDataViewModel.programari = programari.ToList();
            }

            return View(programareDataViewModel);
        }

        // GET: Programare/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProgramareViewModel programareViewModel = _programareService.costTotal(id.GetValueOrDefault());
            if (programareViewModel == null)
            {
                return NotFound();
            }

            return View(programareViewModel);
        }

        // GET: Programare/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Programare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramareId,numeClient,telefon,dataOra")] Programare programare)
        {
            if (ModelState.IsValid)
            {
                _programareService.AdaugareProgramare(programare);
                return RedirectToAction(nameof(Index));
            }
            return View(programare);
        }

        // GET: Programare/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programare programare = _programareService.GetProgramare(id.GetValueOrDefault());
            if (programare == null)
            {
                return NotFound();
            }
            return View(programare);
        }

        // POST: Programare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramareId,numeClient,telefon,dataOra")] Programare programare)
        {
            if (id != programare.ProgramareId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _programareService.UpdateProgramare(programare);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramareExists(programare.ProgramareId))
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
            return View(programare);
        }

        // GET: Programare/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programare programare = _programareService.GetProgramare(id.GetValueOrDefault());
            if (programare == null)
            {
                return NotFound();
            }

            return View(programare);
        }

        // POST: Programare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Programare programare = _programareService.GetProgramare(id);
            _programareService.StergereProgramare(programare);
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramareExists(int id)
        {
            return (_programareService.GetProgramare(id) != null);
        }
    }
}
