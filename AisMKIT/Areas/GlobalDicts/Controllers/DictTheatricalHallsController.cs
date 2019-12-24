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
    public class DictTheatricalHallsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictTheatricalHallsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictTheatricalHalls
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictTheatricalHall.ToListAsync());
        }

        // GET: GlobalDicts/DictTheatricalHalls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictTheatricalHall = await _context.DictTheatricalHall
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictTheatricalHall == null)
            {
                return NotFound();
            }

            return View(dictTheatricalHall);
        }

        // GET: GlobalDicts/DictTheatricalHalls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictTheatricalHalls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus")] DictTheatricalHall dictTheatricalHall)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictTheatricalHall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictTheatricalHall);
        }

        // GET: GlobalDicts/DictTheatricalHalls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictTheatricalHall = await _context.DictTheatricalHall.FindAsync(id);
            if (dictTheatricalHall == null)
            {
                return NotFound();
            }
            return View(dictTheatricalHall);
        }

        // POST: GlobalDicts/DictTheatricalHalls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus")] DictTheatricalHall dictTheatricalHall)
        {
            if (id != dictTheatricalHall.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictTheatricalHall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictTheatricalHallExists(dictTheatricalHall.Id))
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
            return View(dictTheatricalHall);
        }

        // GET: GlobalDicts/DictTheatricalHalls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictTheatricalHall = await _context.DictTheatricalHall
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictTheatricalHall == null)
            {
                return NotFound();
            }

            return View(dictTheatricalHall);
        }

        // POST: GlobalDicts/DictTheatricalHalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictTheatricalHall = await _context.DictTheatricalHall.FindAsync(id);
            _context.DictTheatricalHall.Remove(dictTheatricalHall);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictTheatricalHallExists(int id)
        {
            return _context.DictTheatricalHall.Any(e => e.Id == id);
        }
    }
}
