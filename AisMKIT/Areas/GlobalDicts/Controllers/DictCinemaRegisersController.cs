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
    public class DictCinemaRegisersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictCinemaRegisersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictCinemaRegisers
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictCinemaRegiser.ToListAsync());
        }

        // GET: GlobalDicts/DictCinemaRegisers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinemaRegiser = await _context.DictCinemaRegiser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCinemaRegiser == null)
            {
                return NotFound();
            }

            return View(dictCinemaRegiser);
        }

        // GET: GlobalDicts/DictCinemaRegisers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictCinemaRegisers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,Patronic,FullName")] DictCinemaRegiser dictCinemaRegiser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictCinemaRegiser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictCinemaRegiser);
        }

        // GET: GlobalDicts/DictCinemaRegisers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinemaRegiser = await _context.DictCinemaRegiser.FindAsync(id);
            if (dictCinemaRegiser == null)
            {
                return NotFound();
            }
            return View(dictCinemaRegiser);
        }

        // POST: GlobalDicts/DictCinemaRegisers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,Patronic,FullName")] DictCinemaRegiser dictCinemaRegiser)
        {
            if (id != dictCinemaRegiser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictCinemaRegiser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictCinemaRegiserExists(dictCinemaRegiser.Id))
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
            return View(dictCinemaRegiser);
        }

        // GET: GlobalDicts/DictCinemaRegisers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinemaRegiser = await _context.DictCinemaRegiser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCinemaRegiser == null)
            {
                return NotFound();
            }

            return View(dictCinemaRegiser);
        }

        // POST: GlobalDicts/DictCinemaRegisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictCinemaRegiser = await _context.DictCinemaRegiser.FindAsync(id);
            _context.DictCinemaRegiser.Remove(dictCinemaRegiser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictCinemaRegiserExists(int id)
        {
            return _context.DictCinemaRegiser.Any(e => e.Id == id);
        }
    }
}
