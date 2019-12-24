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
    public class DictMonumemtSignOfLossesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictMonumemtSignOfLossesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictMonumemtSignOfLosses
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictMonumemtSignOfLoss.ToListAsync());
        }

        // GET: GlobalDicts/DictMonumemtSignOfLosses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMonumemtSignOfLoss = await _context.DictMonumemtSignOfLoss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMonumemtSignOfLoss == null)
            {
                return NotFound();
            }

            return View(dictMonumemtSignOfLoss);
        }

        // GET: GlobalDicts/DictMonumemtSignOfLosses/Create
        public IActionResult Create()
        {
            DictMonumemtSignOfLoss model = new DictMonumemtSignOfLoss();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            return View(model);
        }

        // POST: GlobalDicts/DictMonumemtSignOfLosses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,CreateDate")] DictMonumemtSignOfLoss dictMonumemtSignOfLoss)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictMonumemtSignOfLoss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictMonumemtSignOfLoss);
        }

        // GET: GlobalDicts/DictMonumemtSignOfLosses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMonumemtSignOfLoss = await _context.DictMonumemtSignOfLoss.FindAsync(id);
            if (dictMonumemtSignOfLoss == null)
            {
                return NotFound();
            }
            return View(dictMonumemtSignOfLoss);
        }

        // POST: GlobalDicts/DictMonumemtSignOfLosses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,CreateDate")] DictMonumemtSignOfLoss dictMonumemtSignOfLoss)
        {
            if (id != dictMonumemtSignOfLoss.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictMonumemtSignOfLoss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictMonumemtSignOfLossExists(dictMonumemtSignOfLoss.Id))
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
            return View(dictMonumemtSignOfLoss);
        }

        // GET: GlobalDicts/DictMonumemtSignOfLosses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMonumemtSignOfLoss = await _context.DictMonumemtSignOfLoss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMonumemtSignOfLoss == null)
            {
                return NotFound();
            }

            return View(dictMonumemtSignOfLoss);
        }

        // POST: GlobalDicts/DictMonumemtSignOfLosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictMonumemtSignOfLoss = await _context.DictMonumemtSignOfLoss.FindAsync(id);
            _context.DictMonumemtSignOfLoss.Remove(dictMonumemtSignOfLoss);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictMonumemtSignOfLossExists(int id)
        {
            return _context.DictMonumemtSignOfLoss.Any(e => e.Id == id);
        }
    }
}
