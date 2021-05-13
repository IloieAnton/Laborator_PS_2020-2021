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

namespace WebSalon.Controllers
{
    [Authorize]
    public class ProgramareServiciuController : Controller
    {
        private readonly WebSalonContext _context;

        public ProgramareServiciuController(WebSalonContext context)
        {
            _context = context;
        }

        // GET: ProgramareServiciu
        public async Task<IActionResult> Index()
        {
            var webSalonContext = _context.ProgramareServiciu.Include(p => p.Programare).Include(p => p.Serviciu);
            return View(await webSalonContext.ToListAsync());
        }

      
        // GET: ProgramareServiciu/Create
        public IActionResult Create()
        {
            ViewData["ProgramareId"] = new SelectList(_context.Programare, "ProgramareId", "dataOra");
            ViewData["ServiciuId"] = new SelectList(_context.Serviciu, "ServiciuId", "numeServiciu");
            return View();
        }

        // POST: ProgramareServiciu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramareId,ServiciuId")] ProgramareServiciu programareServiciu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programareServiciu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProgramareId"] = new SelectList(_context.Programare, "ProgramareId", "ProgramareId", programareServiciu.ProgramareId);
            ViewData["ServiciuId"] = new SelectList(_context.Serviciu, "ServiciuId", "ServiciuId", programareServiciu.ServiciuId);
            return View(programareServiciu);
        }

       
    }
}
