using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.Tourism.Controllers
{
    [Area("Tourism")]
    public class TourismIndicatorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TourismIndicatorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tourism/TourismIndicators
        public async Task<IActionResult> Index()
        {
            return View(await _context.TourismIndicator.ToListAsync());
        }

        // GET: Tourism/TourismIndicators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourismIndicator = await _context.TourismIndicator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tourismIndicator == null)
            {
                return NotFound();
            }

            return View(tourismIndicator);
        }

        // GET: Tourism/TourismIndicators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tourism/TourismIndicators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,GDP,InTurist,OutTurist,VolumeOfServicesForExport,VolumeOfServicesForImport,SummOfInvestFromBudget,SummOfPrivateDomesticInvest,SummOfForeignInvest,AverageMonthSalary")] TourismIndicator tourismIndicator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tourismIndicator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tourismIndicator);
        }

        // GET: Tourism/TourismIndicators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourismIndicator = await _context.TourismIndicator.FindAsync(id);
            if (tourismIndicator == null)
            {
                return NotFound();
            }
            return View(tourismIndicator);
        }

        // POST: Tourism/TourismIndicators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Year,GDP,InTurist,OutTurist,VolumeOfServicesForExport,VolumeOfServicesForImport,SummOfInvestFromBudget,SummOfPrivateDomesticInvest,SummOfForeignInvest,AverageMonthSalary")] TourismIndicator tourismIndicator)
        {
            if (id != tourismIndicator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tourismIndicator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourismIndicatorExists(tourismIndicator.Id))
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
            return View(tourismIndicator);
        }

        // GET: Tourism/TourismIndicators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourismIndicator = await _context.TourismIndicator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tourismIndicator == null)
            {
                return NotFound();
            }

            return View(tourismIndicator);
        }

        // POST: Tourism/TourismIndicators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tourismIndicator = await _context.TourismIndicator.FindAsync(id);
            _context.TourismIndicator.Remove(tourismIndicator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourismIndicatorExists(int id)
        {
            return _context.TourismIndicator.Any(e => e.Id == id);
        }
    }
}
