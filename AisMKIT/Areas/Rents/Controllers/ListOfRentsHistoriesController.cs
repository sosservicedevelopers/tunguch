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

namespace AisMKIT.Areas.Rents.Controllers
{
    [Area("Rents")]
    public class ListOfRentsHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListOfRentsHistoriesController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Rents/ListOfRentsHistories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfRentsHistory.Include(l => l.ApplicationUser).Include(l => l.ListOfRents);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rents/ListOfRentsHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfRentsHistory = await _context.ListOfRentsHistory
                .Include(l => l.ApplicationUser)
                .Include(l => l.ListOfRents)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfRentsHistory == null)
            {
                return NotFound();
            }

            return View(listOfRentsHistory);
        }

        // GET: Rents/ListOfRentsHistories/Create
        public IActionResult Create()
        {
            ViewData["ListOfRentsId"] = new SelectList(_context.ListOfRents, "Id", "NameRus");
            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ListOfRentsHistory model = new ListOfRentsHistory();
            model.CreateDate = DateTime.Now;
            model.ApplicationUserId = uid;

            return View(model);
        }

        // POST: Rents/ListOfRentsHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListOfRentsId,StartDate,EndDate,Cost,CreateDate,ApplicationUserId")] ListOfRentsHistory listOfRentsHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfRentsHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
             ViewData["ListOfRentsId"] = new SelectList(_context.ListOfRents, "Id", "NameRus", listOfRentsHistory.ListOfRentsId);
            return View(listOfRentsHistory);
        }

        // GET: Rents/ListOfRentsHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfRentsHistory = await _context.ListOfRentsHistory.FindAsync(id);
            if (listOfRentsHistory == null)
            {
                return NotFound();
            }
             ViewData["ListOfRentsId"] = new SelectList(_context.ListOfRents, "Id", "NameRus", listOfRentsHistory.ListOfRentsId);
            return View(listOfRentsHistory);
        }

        // POST: Rents/ListOfRentsHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListOfRentsId,StartDate,EndDate,Cost,CreateDate,ApplicationUserId")] ListOfRentsHistory listOfRentsHistory)
        {
            if (id != listOfRentsHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfRentsHistory.ApplicationUserId = uid;
                    _context.Update(listOfRentsHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfRentsHistoryExists(listOfRentsHistory.Id))
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
              ViewData["ListOfRentsId"] = new SelectList(_context.ListOfRents, "Id", "NameRus", listOfRentsHistory.ListOfRentsId);
            return View(listOfRentsHistory);
        }

        // GET: Rents/ListOfRentsHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfRentsHistory = await _context.ListOfRentsHistory
                .Include(l => l.ApplicationUser)
                .Include(l => l.ListOfRents)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfRentsHistory == null)
            {
                return NotFound();
            }

            return View(listOfRentsHistory);
        }

        // POST: Rents/ListOfRentsHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfRentsHistory = await _context.ListOfRentsHistory.FindAsync(id);
            _context.ListOfRentsHistory.Remove(listOfRentsHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfRentsHistoryExists(int id)
        {
            return _context.ListOfRentsHistory.Any(e => e.Id == id);
        }
    }
}
