using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionMouvementCarte.DBcontextSQL;
using GestionMouvementCarte.Models;

namespace GestionMouvementCarte.Controllers
{
    public class UniteDeProductionsController : Controller
    {
        private readonly DataDBContext _context;

        public UniteDeProductionsController(DataDBContext context)
        {
            _context = context;
        }

        // GET: UniteDeProductions
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnitesDeProductions.ToListAsync());
        }

        // GET: UniteDeProductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uniteDeProduction = await _context.UnitesDeProductions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uniteDeProduction == null)
            {
                return NotFound();
            }

            return View(uniteDeProduction);
        }

        // GET: UniteDeProductions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UniteDeProductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,NomResponsable")] UniteDeProduction uniteDeProduction)
        {
           
                _context.Add(uniteDeProduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(uniteDeProduction);
        }

        // GET: UniteDeProductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uniteDeProduction = await _context.UnitesDeProductions.FindAsync(id);
            if (uniteDeProduction == null)
            {
                return NotFound();
            }
            return View(uniteDeProduction);
        }

        // POST: UniteDeProductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,NomResponsable")] UniteDeProduction uniteDeProduction)
        {
            if (id != uniteDeProduction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uniteDeProduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniteDeProductionExists(uniteDeProduction.Id))
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
            return View(uniteDeProduction);
        }

        // GET: UniteDeProductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uniteDeProduction = await _context.UnitesDeProductions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uniteDeProduction == null)
            {
                return NotFound();
            }

            return View(uniteDeProduction);
        }

        // POST: UniteDeProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uniteDeProduction = await _context.UnitesDeProductions.FindAsync(id);
            if (uniteDeProduction != null)
            {
                _context.UnitesDeProductions.Remove(uniteDeProduction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniteDeProductionExists(int id)
        {
            return _context.UnitesDeProductions.Any(e => e.Id == id);
        }
    }
}
