using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace AisMKIT.Areas.Cinematography.Controllers
{
    [Area("Cinematography")]
    [Authorize(Roles = "Администратор-Кинематография")]
    public class ListOfCinematographyCertificatesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListOfCinematographyCertificatesController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Cinematography/ListOfCinematographyCertificates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfCinematographyCertificates.Include(l => l.ApplicationUser).Include(l => l.DictAgeRestrictions).Include(l => l.DictCountry).Include(l => l.DictDuration).Include(l => l.DictRegiser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cinematography/ListOfCinematographyCertificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyCertificates = await _context.ListOfCinematographyCertificates
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictAgeRestrictions)
                .Include(l => l.DictCountry)
                .Include(l => l.DictDuration)
                .Include(l => l.DictRegiser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCinematographyCertificates == null)
            {
                return NotFound();
            }

            return View(listOfCinematographyCertificates);
        }

        // GET: Cinematography/ListOfCinematographyCertificates/Create
        //[Authorize]
        public IActionResult Create()
        {
            ViewData["DictAgeRestrictionsId"] = new SelectList(_context.DictAgeRestrictions, "Id", "Name");
            ViewData["DictCountryId"] = new SelectList(_context.DictCountry, "Id", "Name");
            ViewData["DictDurationId"] = new SelectList(_context.DictDuration, "Id", "Name");
            ViewData["DictRegiserId"] = new SelectList(_context.DictRegiser, "Id", "FullName");

            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ListOfCinematographyCertificates model = new ListOfCinematographyCertificates();
            model.NameKyrg = "NULL";
            model.CreateDate = DateTime.Now;
            model.ApplicationUserId = uid;

            return View(model);
        }

        // POST: Cinematography/ListOfCinematographyCertificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameRus,NameKyrg,DictCountryId,Years,DictRegiserId,DictDurationId,DictAgeRestrictionsId,RegistrationDate,CreateDate,ApplicationUserId,ApplicationUserId")] ListOfCinematographyCertificates listOfCinematographyCertificates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfCinematographyCertificates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DictAgeRestrictionsId"] = new SelectList(_context.DictAgeRestrictions, "Id", "Name", listOfCinematographyCertificates.DictAgeRestrictionsId);
            ViewData["DictCountryId"] = new SelectList(_context.DictCountry, "Id", "Name", listOfCinematographyCertificates.DictCountryId);
            ViewData["DictDurationId"] = new SelectList(_context.DictDuration, "Id", "Name", listOfCinematographyCertificates.DictDurationId);
            ViewData["DictRegiserId"] = new SelectList(_context.DictRegiser, "Id", "FullName", listOfCinematographyCertificates.DictRegiserId);
            
            return View(listOfCinematographyCertificates);
        }

        // GET: Cinematography/ListOfCinematographyCertificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyCertificates = await _context.ListOfCinematographyCertificates.FindAsync(id);
            if (listOfCinematographyCertificates == null)
            {
                return NotFound();
            }

            ViewData["DictAgeRestrictionsId"] = new SelectList(_context.DictAgeRestrictions, "Id", "Name", listOfCinematographyCertificates.DictAgeRestrictionsId);
            ViewData["DictCountryId"] = new SelectList(_context.DictCountry, "Id", "Name", listOfCinematographyCertificates.DictCountryId);
            ViewData["DictDurationId"] = new SelectList(_context.DictDuration, "Id", "Name", listOfCinematographyCertificates.DictDurationId);
            ViewData["DictRegiserId"] = new SelectList(_context.DictRegiser, "Id", "FullName", listOfCinematographyCertificates.DictRegiserId);
            
            return View(listOfCinematographyCertificates);
        }

        // POST: Cinematography/ListOfCinematographyCertificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameRus,NameKyrg,DictCountryId,Years,DictRegiserId,DictDurationId,DictAgeRestrictionsId,RegistrationDate,CreateDate,ApplicationUserId")] ListOfCinematographyCertificates listOfCinematographyCertificates)
        {
            if (id != listOfCinematographyCertificates.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfCinematographyCertificates.ApplicationUserId = uid;
                    _context.Update(listOfCinematographyCertificates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfCinematographyCertificatesExists(listOfCinematographyCertificates.Id))
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

            ViewData["DictAgeRestrictionsId"] = new SelectList(_context.DictAgeRestrictions, "Id", "Name", listOfCinematographyCertificates.DictAgeRestrictionsId);
            ViewData["DictCountryId"] = new SelectList(_context.DictCountry, "Id", "Name", listOfCinematographyCertificates.DictCountryId);
            ViewData["DictDurationId"] = new SelectList(_context.DictDuration, "Id", "Name", listOfCinematographyCertificates.DictDurationId);
            ViewData["DictRegiserId"] = new SelectList(_context.DictRegiser, "Id", "FullName", listOfCinematographyCertificates.DictRegiserId);
            
            return View(listOfCinematographyCertificates);
        }

        // GET: Cinematography/ListOfCinematographyCertificates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyCertificates = await _context.ListOfCinematographyCertificates
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictAgeRestrictions)
                .Include(l => l.DictCountry)
                .Include(l => l.DictDuration)
                .Include(l => l.DictRegiser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCinematographyCertificates == null)
            {
                return NotFound();
            }

            return View(listOfCinematographyCertificates);
        }

        // POST: Cinematography/ListOfCinematographyCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfCinematographyCertificates = await _context.ListOfCinematographyCertificates.FindAsync(id);
            _context.ListOfCinematographyCertificates.Remove(listOfCinematographyCertificates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfCinematographyCertificatesExists(int id)
        {
            return _context.ListOfCinematographyCertificates.Any(e => e.Id == id);
        }
    }
}
