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
    public class DictCinematographyServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictCinematographyServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictCinematographyServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictCinematographyServices.ToListAsync());
        }

        // GET: GlobalDicts/DictCinematographyServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinematographyServices = await _context.DictCinematographyServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCinematographyServices == null)
            {
                return NotFound();
            }

            return View(dictCinematographyServices);
        }

        // GET: GlobalDicts/DictCinematographyServices/Create
        public IActionResult Create()
        {
            DictCinematographyServices model = new DictCinematographyServices();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            return View(model);
        }

        // POST: GlobalDicts/DictCinematographyServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,CreateDate")] DictCinematographyServices dictCinematographyServices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictCinematographyServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictCinematographyServices);
        }

        // GET: GlobalDicts/DictCinematographyServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinematographyServices = await _context.DictCinematographyServices.FindAsync(id);
            if (dictCinematographyServices == null)
            {
                return NotFound();
            }
            return View(dictCinematographyServices);
        }

        // POST: GlobalDicts/DictCinematographyServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,CreateDate")] DictCinematographyServices dictCinematographyServices)
        {
            if (id != dictCinematographyServices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictCinematographyServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictCinematographyServicesExists(dictCinematographyServices.Id))
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
            return View(dictCinematographyServices);
        }

        // GET: GlobalDicts/DictCinematographyServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinematographyServices = await _context.DictCinematographyServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCinematographyServices == null)
            {
                return NotFound();
            }

            return View(dictCinematographyServices);
        }

        // POST: GlobalDicts/DictCinematographyServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictCinematographyServices = await _context.DictCinematographyServices.FindAsync(id);
            _context.DictCinematographyServices.Remove(dictCinematographyServices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictCinematographyServicesExists(int id)
        {
            return _context.DictCinematographyServices.Any(e => e.Id == id);
        }
    }
}
