using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.GlobalDicts.Controllers
{
    [Area("GlobalDicts")]
    public class DictTourismServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictTourismServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictTourismServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictTourismServices.ToListAsync());
        }

        // GET: GlobalDicts/DictTourismServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictTourismServices = await _context.DictTourismServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictTourismServices == null)
            {
                return NotFound();
            }

            return View(dictTourismServices);
        }

        // GET: GlobalDicts/DictTourismServices/Create
        public IActionResult Create()
        {
            DictTourismServices model = new DictTourismServices();
            model.CreateDate = DateTime.Now;
            return View(model);
        }

        // POST: GlobalDicts/DictTourismServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus")] DictTourismServices dictTourismServices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictTourismServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictTourismServices);
        }

        // GET: GlobalDicts/DictTourismServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictTourismServices = await _context.DictTourismServices.FindAsync(id);
            if (dictTourismServices == null)
            {
                return NotFound();
            }
            return View(dictTourismServices);
        }

        // POST: GlobalDicts/DictTourismServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus")] DictTourismServices dictTourismServices)
        {
            if (id != dictTourismServices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictTourismServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictTourismServicesExists(dictTourismServices.Id))
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
            return View(dictTourismServices);
        }

        // GET: GlobalDicts/DictTourismServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictTourismServices = await _context.DictTourismServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictTourismServices == null)
            {
                return NotFound();
            }

            return View(dictTourismServices);
        }

        // POST: GlobalDicts/DictTourismServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictTourismServices = await _context.DictTourismServices.FindAsync(id);
            _context.DictTourismServices.Remove(dictTourismServices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictTourismServicesExists(int id)
        {
            return _context.DictTourismServices.Any(e => e.Id == id);
        }
    }
}
