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

namespace AisMKIT.Areas.Monuments.Controllers
{
    [Area("Monuments")]
    public class ListOfMonumentsProtObjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ListOfMonumentsProtObjectsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Monuments/ListOfMonumentsProtObjects
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfMonumentsProtObjects.Include(l => l.ApplicationUser).Include(l => l.DictDistrict).Include(l => l.DictFinSource);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Monuments/ListOfMonumentsProtObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMonumentsProtObjects = await _context.ListOfMonumentsProtObjects
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictDistrict)
                .Include(l => l.DictFinSource)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfMonumentsProtObjects == null)
            {
                return NotFound();
            }

            return View(listOfMonumentsProtObjects);
        }

        // GET: Monuments/ListOfMonumentsProtObjects/Create
        public IActionResult Create()
        {
             ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus");
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus");
            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ListOfMonumentsProtObjects model = new ListOfMonumentsProtObjects();
            model.CreateDate = DateTime.Now;
            model.ApplicationUserId = uid;

            return View(model);
        }

        // POST: Monuments/ListOfMonumentsProtObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameRus,NameKyrg,DictDistrictId,LegalAddress,DictFinSourceId,LastNameDirector,FirstNameDirector,PatronicNameDirector,Contacts,LegalDocs,Ploshad,CurrentStatus,CreateDate,ApplicationUserId")] ListOfMonumentsProtObjects listOfMonumentsProtObjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfMonumentsProtObjects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
              ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfMonumentsProtObjects.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfMonumentsProtObjects.DictFinSourceId);
            return View(listOfMonumentsProtObjects);
        }

        // GET: Monuments/ListOfMonumentsProtObjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMonumentsProtObjects = await _context.ListOfMonumentsProtObjects.FindAsync(id);
            if (listOfMonumentsProtObjects == null)
            {
                return NotFound();
            }
             ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfMonumentsProtObjects.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfMonumentsProtObjects.DictFinSourceId);
            return View(listOfMonumentsProtObjects);
        }

        // POST: Monuments/ListOfMonumentsProtObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameRus,NameKyrg,DictDistrictId,LegalAddress,DictFinSourceId,LastNameDirector,FirstNameDirector,PatronicNameDirector,Contacts,LegalDocs,Ploshad,CurrentStatus,CreateDate,ApplicationUserId")] ListOfMonumentsProtObjects listOfMonumentsProtObjects)
        {
            if (id != listOfMonumentsProtObjects.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfMonumentsProtObjects.ApplicationUserId = uid;
                    _context.Update(listOfMonumentsProtObjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfMonumentsProtObjectsExists(listOfMonumentsProtObjects.Id))
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
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfMonumentsProtObjects.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfMonumentsProtObjects.DictFinSourceId);
            return View(listOfMonumentsProtObjects);
        }

        // GET: Monuments/ListOfMonumentsProtObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMonumentsProtObjects = await _context.ListOfMonumentsProtObjects
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictDistrict)
                .Include(l => l.DictFinSource)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfMonumentsProtObjects == null)
            {
                return NotFound();
            }

            return View(listOfMonumentsProtObjects);
        }

        // POST: Monuments/ListOfMonumentsProtObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfMonumentsProtObjects = await _context.ListOfMonumentsProtObjects.FindAsync(id);
            _context.ListOfMonumentsProtObjects.Remove(listOfMonumentsProtObjects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfMonumentsProtObjectsExists(int id)
        {
            return _context.ListOfMonumentsProtObjects.Any(e => e.Id == id);
        }
    }
}
