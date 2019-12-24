using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.Media.Controllers
{
    [Area("Media")]
    public class ListOfControlMediasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListOfControlMediasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Media/ListOfControlMedias
        public async Task<IActionResult> Index(int id=0)
        {
            HttpContext.Response.Cookies.Append("ListOfMediaId", id.ToString());
            var applicationDbContext = _context.ListOfControlMedia.Where(x=>x.ListOfMediaId==id).Include(l => l.DictControlType).Include(l => l.DictMediaControlResult).Include(l => l.DictMediaSuitPerm).Include(l => l.ListOfMedia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Media/ListOfControlMedias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfControlMedia = await _context.ListOfControlMedia
                .Include(l => l.DictControlType)
                .Include(l => l.DictMediaControlResult)
                .Include(l => l.DictMediaSuitPerm)
                .Include(l => l.ListOfMedia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfControlMedia == null)
            {
                return NotFound();
            }

            return View(listOfControlMedia);
        }

        // GET: Media/ListOfControlMedias/Create
        public IActionResult Create()
        {
            ViewData["DictControlTypeId"] = new SelectList(_context.DictControlType, "Id", "NameRus");
            ViewData["DictMediaControlResultId"] = new SelectList(_context.DictMediaControlResult, "Id", "NameRus");
            ViewData["DictMediaSuitPermId"] = new SelectList(_context.DictMediaSuitPerm, "Id", "NameRus");
            ViewData["ListOfMediaId"] = new SelectList(_context.ListOfMedia, "Id", "Name");
            string name = "0";
            if (HttpContext.Request.Cookies.ContainsKey("ListOfMediaId"))
                name = HttpContext.Request.Cookies["ListOfMediaId"];
            ListOfControlMedia model = new ListOfControlMedia();
            model.ListOfMediaId = int.Parse(name);
            model.CreateDate = DateTime.Now;
            return View(model);
            
        }

        // POST: Media/ListOfControlMedias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListOfMediaId,DictControlTypeId,StartDate,EndDate,StartDatePeriod,EndDatePeriod,LastName,FirstName,PatronicName,ActDateControl,NumberOfAct,DictMediaControlResultId,NumberOfWarning,WarningDate,WarningEndDate,WarningRemovalDate,DateOfPenalty,DocNumPenalty,PenaltySum,DateOfPenaltyPay,AnulmentDate,NumberOfAnulment,DateOfSuit,NumberOfSuit,DateOfSuitPerm,NumberOfSuitPerm,DictMediaSuitPermId")] ListOfControlMedia listOfControlMedia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfControlMedia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = listOfControlMedia.ListOfMediaId });
            }
            ViewData["DictControlTypeId"] = new SelectList(_context.DictControlType, "Id", "NameRus", listOfControlMedia.DictControlTypeId);
            ViewData["DictMediaControlResultId"] = new SelectList(_context.DictMediaControlResult, "Id", "NameRus", listOfControlMedia.DictMediaControlResultId);
            ViewData["DictMediaSuitPermId"] = new SelectList(_context.DictMediaSuitPerm, "Id", "NameRus", listOfControlMedia.DictMediaSuitPermId);
            ViewData["ListOfMediaId"] = new SelectList(_context.ListOfMedia, "Id", "Name", listOfControlMedia.ListOfMediaId);
            return View(listOfControlMedia);
        }

        // GET: Media/ListOfControlMedias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfControlMedia = await _context.ListOfControlMedia.FindAsync(id);
            if (listOfControlMedia == null)
            {
                return NotFound();
            }
            ViewData["DictControlTypeId"] = new SelectList(_context.DictControlType, "Id", "NameRus", listOfControlMedia.DictControlTypeId);
            ViewData["DictMediaControlResultId"] = new SelectList(_context.DictMediaControlResult, "Id", "NameRus", listOfControlMedia.DictMediaControlResultId);
            ViewData["DictMediaSuitPermId"] = new SelectList(_context.DictMediaSuitPerm, "Id", "NameRus", listOfControlMedia.DictMediaSuitPermId);
            ViewData["ListOfMediaId"] = new SelectList(_context.ListOfMedia, "Id", "Name", listOfControlMedia.ListOfMediaId);
            return View(listOfControlMedia);
        }

        // POST: Media/ListOfControlMedias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListOfMediaId,DictControlTypeId,StartDate,EndDate,StartDatePeriod,EndDatePeriod,LastName,FirstName,PatronicName,ActDateControl,NumberOfAct,DictMediaControlResultId,NumberOfWarning,WarningDate,WarningEndDate,WarningRemovalDate,DateOfPenalty,DocNumPenalty,PenaltySum,DateOfPenaltyPay,AnulmentDate,NumberOfAnulment,DateOfSuit,NumberOfSuit,DateOfSuitPerm,NumberOfSuitPerm,DictMediaSuitPermId")] ListOfControlMedia listOfControlMedia)
        {
            if (id != listOfControlMedia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfControlMedia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfControlMediaExists(listOfControlMedia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = listOfControlMedia.ListOfMediaId });
            }
            ViewData["DictControlTypeId"] = new SelectList(_context.DictControlType, "Id", "NameRus", listOfControlMedia.DictControlTypeId);
            ViewData["DictMediaControlResultId"] = new SelectList(_context.DictMediaControlResult, "Id", "NameRus", listOfControlMedia.DictMediaControlResultId);
            ViewData["DictMediaSuitPermId"] = new SelectList(_context.DictMediaSuitPerm, "Id", "NameRus", listOfControlMedia.DictMediaSuitPermId);
            ViewData["ListOfMediaId"] = new SelectList(_context.ListOfMedia, "Id", "Name", listOfControlMedia.ListOfMediaId);
            return View(listOfControlMedia);
        }

        // GET: Media/ListOfControlMedias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfControlMedia = await _context.ListOfControlMedia
                .Include(l => l.DictControlType)
                .Include(l => l.DictMediaControlResult)
                .Include(l => l.DictMediaSuitPerm)
                .Include(l => l.ListOfMedia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfControlMedia == null)
            {
                return NotFound();
            }

            return View(listOfControlMedia);
        }

        // POST: Media/ListOfControlMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfControlMedia = await _context.ListOfControlMedia.FindAsync(id);
            _context.ListOfControlMedia.Remove(listOfControlMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfControlMediaExists(int id)
        {
            return _context.ListOfControlMedia.Any(e => e.Id == id);
        }
    }
}
