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
    public class CarteElectroniquesController : Controller
    {
        private readonly DataDBContext _context;

        public CarteElectroniquesController(DataDBContext context)
        {
            _context = context;
        }

        // GET: CarteElectroniques
        public async Task<IActionResult> Index()
        {
            return View(await _context.CartesElectroniques.ToListAsync());
        }

        // GET: CarteElectroniques/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteElectronique = await _context.CartesElectroniques
                .FirstOrDefaultAsync(m => m.Reference == id);
            if (carteElectronique == null)
            {
                return NotFound();
            }

            return View(carteElectronique);
        }

        // GET: CarteElectroniques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarteElectroniques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Statut,TypeMouvement,DateAjout,DerniereUtilisation")] CarteElectronique carteElectronique)
        {
           
                _context.Add(carteElectronique);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
            return View(carteElectronique);
        }

        // GET: CarteElectroniques/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteElectronique = await _context.CartesElectroniques.FindAsync(id);
            if (carteElectronique == null)
            {
                return NotFound();
            }
            return View(carteElectronique);
        }

        // POST: CarteElectroniques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Reference,Statut,TypeMouvement,DateAjout,DerniereUtilisation")] CarteElectronique carteElectronique)
        {
            if (id != carteElectronique.Reference)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carteElectronique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarteElectroniqueExists(carteElectronique.Reference))
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
            return View(carteElectronique);
        }

        // GET: CarteElectroniques/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteElectronique = await _context.CartesElectroniques
                .FirstOrDefaultAsync(m => m.Reference == id);
            if (carteElectronique == null)
            {
                return NotFound();
            }

            return View(carteElectronique);
        }

        // POST: CarteElectroniques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var carteElectronique = await _context.CartesElectroniques.FindAsync(id);
            if (carteElectronique != null)
            {
                _context.CartesElectroniques.Remove(carteElectronique);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarteElectroniqueExists(string id)
        {
            return _context.CartesElectroniques.Any(e => e.Reference == id);
        }
    }
}
