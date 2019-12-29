using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AisMKIT.Areas.CulturalEvents.Controllers
{
    [Area("CulturalEvents")]
    public class ListOfEventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ListOfEventsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        // GET: CulturalEvents/ListOfEvents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfEvents.Include(l => l.ApplicationUser).Include(l => l.DictInitiatorOfProj).Include(l => l.DictTypeOfKMM).Include(l => l.DistLoc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CulturalEvents/ListOfEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEvents = await _context.ListOfEvents
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictInitiatorOfProj)
                .Include(l => l.DictTypeOfKMM)
                .Include(l => l.DistLoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfEvents == null)
            {
                return NotFound();
            }

            return View(listOfEvents);
        }

        // GET: CulturalEvents/ListOfEvents/Create
        public IActionResult Create()
        {
            ViewData["DictInitiatorOfProjId"] = new SelectList(_context.DictInitiatorOfProj, "Id", "Name");
            ViewData["DictTypeOfKMMId"] = new SelectList(_context.DictTypeOfKMM, "Id", "Name");
            ViewData["DistLocId"] = new SelectList(_context.DictLoc, "Id", "Name");
            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ListOfEvents model = new ListOfEvents();
            model.CreateDate = DateTime.Now;
            model.ApplicationUserId = uid;

            return View(model);
        }

        // POST: CulturalEvents/ListOfEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DictTypeOfKMMId,DistLocId,EventTopic,StartDateTime,EndDateTime,DictInitiatorOfProjId,CreateDate,ApplicationUserId")] ListOfEvents listOfEvents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfEvents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
             ViewData["DictInitiatorOfProjId"] = new SelectList(_context.DictInitiatorOfProj, "Id", "Name", listOfEvents.DictInitiatorOfProjId);
            ViewData["DictTypeOfKMMId"] = new SelectList(_context.DictTypeOfKMM, "Id", "Name", listOfEvents.DictTypeOfKMMId);
            ViewData["DistLocId"] = new SelectList(_context.DictLoc, "Id", "Name", listOfEvents.DistLocId);
            return View(listOfEvents);
        }

        // GET: CulturalEvents/ListOfEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEvents = await _context.ListOfEvents.FindAsync(id);
            if (listOfEvents == null)
            {
                return NotFound();
            }
             ViewData["DictInitiatorOfProjId"] = new SelectList(_context.DictInitiatorOfProj, "Id", "Name", listOfEvents.DictInitiatorOfProjId);
            ViewData["DictTypeOfKMMId"] = new SelectList(_context.DictTypeOfKMM, "Id", "Name", listOfEvents.DictTypeOfKMMId);
            ViewData["DistLocId"] = new SelectList(_context.DictLoc, "Id", "Name", listOfEvents.DistLocId);
            return View(listOfEvents);
        }

        // POST: CulturalEvents/ListOfEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DictTypeOfKMMId,DistLocId,EventTopic,StartDateTime,EndDateTime,DictInitiatorOfProjId,CreateDate,ApplicationUserId")] ListOfEvents listOfEvents)
        {
            if (id != listOfEvents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfEvents.ApplicationUserId = uid;
                    _context.Update(listOfEvents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfEventsExists(listOfEvents.Id))
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
             ViewData["DictInitiatorOfProjId"] = new SelectList(_context.DictInitiatorOfProj, "Id", "Name", listOfEvents.DictInitiatorOfProjId);
            ViewData["DictTypeOfKMMId"] = new SelectList(_context.DictTypeOfKMM, "Id", "Name", listOfEvents.DictTypeOfKMMId);
            ViewData["DistLocId"] = new SelectList(_context.DictLoc, "Id", "Name", listOfEvents.DistLocId);
            return View(listOfEvents);
        }

        // GET: CulturalEvents/ListOfEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEvents = await _context.ListOfEvents
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictInitiatorOfProj)
                .Include(l => l.DictTypeOfKMM)
                .Include(l => l.DistLoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfEvents == null)
            {
                return NotFound();
            }

            return View(listOfEvents);
        }

        // POST: CulturalEvents/ListOfEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfEvents = await _context.ListOfEvents.FindAsync(id);
            _context.ListOfEvents.Remove(listOfEvents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfEventsExists(int id)
        {
            return _context.ListOfEvents.Any(e => e.Id == id);
        }
    }
}
