using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.CultAndArt.Controllers
{
    [Area("CultAndArt")]

    public class ListOfCultEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListOfCultEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CultAndArt/ListOfCultEvents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfCultEvents.Include(l => l.DictInitiatorOfProj).Include(l => l.DictTypeOfKMM).Include(l => l.DistLoc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CultAndArt/ListOfCultEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCultEvents = await _context.ListOfCultEvents
                .Include(l => l.DictInitiatorOfProj)
                .Include(l => l.DictTypeOfKMM)
                .Include(l => l.DistLoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCultEvents == null)
            {
                return NotFound();
            }

            return View(listOfCultEvents);
        }

        // GET: CultAndArt/ListOfCultEvents/Create
        public IActionResult Create()
        {
            ViewData["DictInitiatorOfProjId"] = new SelectList(_context.DictInitiatorOfProj, "Id", "Name");
            ViewData["DictTypeOfKMMId"] = new SelectList(_context.DictTypeOfKMM, "Id", "Name");
            ViewData["DistLocId"] = new SelectList(_context.DictLoc, "Id", "Name");
            return View();
        }

        // POST: CultAndArt/ListOfCultEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DictTypeOfKMMId,DistLocId,EventTopic,StartDateTime,EndDateTime,DictInitiatorOfProjId")] ListOfCultEvents listOfCultEvents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfCultEvents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictInitiatorOfProjId"] = new SelectList(_context.DictInitiatorOfProj, "Id", "Name", listOfCultEvents.DictInitiatorOfProjId);
            ViewData["DictTypeOfKMMId"] = new SelectList(_context.DictTypeOfKMM, "Id", "Name", listOfCultEvents.DictTypeOfKMMId);
            ViewData["DistLocId"] = new SelectList(_context.DictLoc, "Id", "Name", listOfCultEvents.DistLocId);
            return View(listOfCultEvents);
        }

        // GET: CultAndArt/ListOfCultEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCultEvents = await _context.ListOfCultEvents.FindAsync(id);
            if (listOfCultEvents == null)
            {
                return NotFound();
            }
            ViewData["DictInitiatorOfProjId"] = new SelectList(_context.DictInitiatorOfProj, "Id", "Name", listOfCultEvents.DictInitiatorOfProjId);
            ViewData["DictTypeOfKMMId"] = new SelectList(_context.DictTypeOfKMM, "Id", "Name", listOfCultEvents.DictTypeOfKMMId);
            ViewData["DistLocId"] = new SelectList(_context.DictLoc, "Id", "Name", listOfCultEvents.DistLocId);
            return View(listOfCultEvents);
        }

        // POST: CultAndArt/ListOfCultEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DictTypeOfKMMId,DistLocId,EventTopic,StartDateTime,EndDateTime,DictInitiatorOfProjId")] ListOfCultEvents listOfCultEvents)
        {
            if (id != listOfCultEvents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfCultEvents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfCultEventsExists(listOfCultEvents.Id))
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
            ViewData["DictInitiatorOfProjId"] = new SelectList(_context.DictInitiatorOfProj, "Id", "Name", listOfCultEvents.DictInitiatorOfProjId);
            ViewData["DictTypeOfKMMId"] = new SelectList(_context.DictTypeOfKMM, "Id", "Name", listOfCultEvents.DictTypeOfKMMId);
            ViewData["DistLocId"] = new SelectList(_context.DictLoc, "Id", "Name", listOfCultEvents.DistLocId);
            return View(listOfCultEvents);
        }

        // GET: CultAndArt/ListOfCultEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCultEvents = await _context.ListOfCultEvents
                .Include(l => l.DictInitiatorOfProj)
                .Include(l => l.DictTypeOfKMM)
                .Include(l => l.DistLoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCultEvents == null)
            {
                return NotFound();
            }

            return View(listOfCultEvents);
        }

        // POST: CultAndArt/ListOfCultEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfCultEvents = await _context.ListOfCultEvents.FindAsync(id);
            _context.ListOfCultEvents.Remove(listOfCultEvents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfCultEventsExists(int id)
        {
            return _context.ListOfCultEvents.Any(e => e.Id == id);
        }
    }
}
