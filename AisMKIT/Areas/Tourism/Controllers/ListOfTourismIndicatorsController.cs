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
    public class ListOfTourismIndicatorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListOfTourismIndicatorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tourism/ListOfTourismIndicators
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListOfTourismIndicator.ToListAsync());
        }

        // GET: Tourism/ListOfTourismIndicators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTourismIndicator = await _context.ListOfTourismIndicator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfTourismIndicator == null)
            {
                return NotFound();
            }

            return View(listOfTourismIndicator);
        }

        // GET: Tourism/ListOfTourismIndicators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tourism/ListOfTourismIndicators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,GDP,InTurist,OutTurist,VolumeOfServicesForExport,VolumeOfServicesForImport,SummOfInvestFromBudget,SummOfPrivateDomesticInvest,SummOfForeignInvest,AverageMonthSalary")] ListOfTourismIndicator listOfTourismIndicator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfTourismIndicator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listOfTourismIndicator);
        }

        // GET: Tourism/ListOfTourismIndicators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTourismIndicator = await _context.ListOfTourismIndicator.FindAsync(id);
            if (listOfTourismIndicator == null)
            {
                return NotFound();
            }
            return View(listOfTourismIndicator);
        }

        // POST: Tourism/ListOfTourismIndicators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Year,GDP,InTurist,OutTurist,VolumeOfServicesForExport,VolumeOfServicesForImport,SummOfInvestFromBudget,SummOfPrivateDomesticInvest,SummOfForeignInvest,AverageMonthSalary")] ListOfTourismIndicator listOfTourismIndicator)
        {
            if (id != listOfTourismIndicator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfTourismIndicator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfTourismIndicatorExists(listOfTourismIndicator.Id))
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
            return View(listOfTourismIndicator);
        }

        // GET: Tourism/ListOfTourismIndicators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTourismIndicator = await _context.ListOfTourismIndicator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfTourismIndicator == null)
            {
                return NotFound();
            }

            return View(listOfTourismIndicator);
        }

        // POST: Tourism/ListOfTourismIndicators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfTourismIndicator = await _context.ListOfTourismIndicator.FindAsync(id);
            _context.ListOfTourismIndicator.Remove(listOfTourismIndicator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfTourismIndicatorExists(int id)
        {
            return _context.ListOfTourismIndicator.Any(e => e.Id == id);
        }
    }
}
