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
    public class ListOfRentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListOfRentsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Rents/ListOfRents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfRents.Include(l => l.ApplicationUser).Include(l => l.DictRentObjectType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rents/ListOfRents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfRents = await _context.ListOfRents
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictRentObjectType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfRents == null)
            {
                return NotFound();
            }

            return View(listOfRents);
        }

        // GET: Rents/ListOfRents/Create
        public IActionResult Create()
        {
              ViewData["DictRentObjectTypeId"] = new SelectList(_context.DictRentObjectType, "Id", "NameRus");

            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ListOfRents model = new ListOfRents();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            model.ApplicationUserId = uid;

            return View(model);
        }

        // POST: Rents/ListOfRents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameRus,NameKyrg,DictRentObjectTypeId,CreateDate,ApplicationUserId")] ListOfRents listOfRents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfRents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
              ViewData["DictRentObjectTypeId"] = new SelectList(_context.DictRentObjectType, "Id", "NameRus", listOfRents.DictRentObjectTypeId);
            return View(listOfRents);
        }

        // GET: Rents/ListOfRents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfRents = await _context.ListOfRents.FindAsync(id);
            if (listOfRents == null)
            {
                return NotFound();
            }
             ViewData["DictRentObjectTypeId"] = new SelectList(_context.DictRentObjectType, "Id", "NameRus", listOfRents.DictRentObjectTypeId);
            return View(listOfRents);
        }

        // POST: Rents/ListOfRents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameRus,NameKyrg,DictRentObjectTypeId,CreateDate,ApplicationUserId")] ListOfRents listOfRents)
        {
            if (id != listOfRents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfRents.ApplicationUserId = uid;

                    _context.Update(listOfRents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfRentsExists(listOfRents.Id))
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
             ViewData["DictRentObjectTypeId"] = new SelectList(_context.DictRentObjectType, "Id", "NameRus", listOfRents.DictRentObjectTypeId);
            return View(listOfRents);
        }

        // GET: Rents/ListOfRents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfRents = await _context.ListOfRents
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictRentObjectType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfRents == null)
            {
                return NotFound();
            }

            return View(listOfRents);
        }

        // POST: Rents/ListOfRents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfRents = await _context.ListOfRents.FindAsync(id);
            _context.ListOfRents.Remove(listOfRents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfRentsExists(int id)
        {
            return _context.ListOfRents.Any(e => e.Id == id);
        }
    }
}
