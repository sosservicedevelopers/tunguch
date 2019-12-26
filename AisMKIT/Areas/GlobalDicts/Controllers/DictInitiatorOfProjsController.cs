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
    public class DictInitiatorOfProjsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictInitiatorOfProjsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictInitiatorOfProjs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictInitiatorOfProj.ToListAsync());
        }

        // GET: GlobalDicts/DictInitiatorOfProjs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictInitiatorOfProj = await _context.DictInitiatorOfProj
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictInitiatorOfProj == null)
            {
                return NotFound();
            }

            return View(dictInitiatorOfProj);
        }

        // GET: GlobalDicts/DictInitiatorOfProjs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictInitiatorOfProjs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DictInitiatorOfProj dictInitiatorOfProj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictInitiatorOfProj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictInitiatorOfProj);
        }

        // GET: GlobalDicts/DictInitiatorOfProjs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictInitiatorOfProj = await _context.DictInitiatorOfProj.FindAsync(id);
            if (dictInitiatorOfProj == null)
            {
                return NotFound();
            }
            return View(dictInitiatorOfProj);
        }

        // POST: GlobalDicts/DictInitiatorOfProjs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DictInitiatorOfProj dictInitiatorOfProj)
        {
            if (id != dictInitiatorOfProj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictInitiatorOfProj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictInitiatorOfProjExists(dictInitiatorOfProj.Id))
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
            return View(dictInitiatorOfProj);
        }

        // GET: GlobalDicts/DictInitiatorOfProjs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictInitiatorOfProj = await _context.DictInitiatorOfProj
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictInitiatorOfProj == null)
            {
                return NotFound();
            }

            return View(dictInitiatorOfProj);
        }

        // POST: GlobalDicts/DictInitiatorOfProjs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictInitiatorOfProj = await _context.DictInitiatorOfProj.FindAsync(id);
            _context.DictInitiatorOfProj.Remove(dictInitiatorOfProj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictInitiatorOfProjExists(int id)
        {
            return _context.DictInitiatorOfProj.Any(e => e.Id == id);
        }
    }
}
