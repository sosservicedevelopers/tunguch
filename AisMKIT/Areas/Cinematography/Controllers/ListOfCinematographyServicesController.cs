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

namespace AisMKIT.Areas.Cinematography.Controllers
{
    [Area("Cinematography")]
    public class ListOfCinematographyServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ListOfCinematographyServicesController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Cinematography/ListOfCinematographyServices
        public async Task<IActionResult> Index(int id = 0)
        {
            HttpContext.Response.Cookies.Append("ListOfCinemotograpy", id.ToString());
            var applicationDbContext = _context.ListOfCinematographyServices.Include(l => l.DictCinematographyServices).Include(l => l.DictStatus).Include(l => l.ListOfCinematography);
            if (id != 0)
                applicationDbContext = _context.ListOfCinematographyServices.Where(x => x.ListOfCinematographyId == id & x.DeactivateStatus == null).Include(l => l.DictCinematographyServices).Include(l => l.DictStatus).Include(l => l.ListOfCinematography);
            
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cinematography/ListOfCinematographyServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyServices = await _context.ListOfCinematographyServices
                .Include(l => l.DictCinematographyServices)
                .Include(l => l.DictStatus)
                .Include(l => l.ListOfCinematography)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCinematographyServices == null)
            {
                return NotFound();
            }

            return View(listOfCinematographyServices);
        }

        // GET: Cinematography/ListOfCinematographyServices/Create
        public IActionResult Create()
        {
            ViewData["DictCinematographyServicesId"] = new SelectList(_context.DictCinematographyServices, "Id", "NameRus");
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            ViewData["ListOfCinematographyId"] = new SelectList(_context.ListOfCinematography, "Id", "NameRus");
            string name = "0";
            if (HttpContext.Request.Cookies.ContainsKey("ListOfCinemotograpy"))
                name = HttpContext.Request.Cookies["ListOfCinemotograpy"];
            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ListOfCinematographyServices model = new ListOfCinematographyServices();
            model.ListOfCinematographyId = int.Parse(name);
            model.CreateDate = DateTime.Now;
            model.ApplicationUserId = uid;
            return View(model);
            
        }

        // POST: Cinematography/ListOfCinematographyServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DictCinematographyServicesId,ListOfCinematographyId,DictStatusId,DeactivateStatus,CreateDate,ApplicationUserId")] ListOfCinematographyServices listOfCinematographyServices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfCinematographyServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictCinematographyServicesId"] = new SelectList(_context.DictCinematographyServices, "Id", "NameRus", listOfCinematographyServices.DictCinematographyServicesId);
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", listOfCinematographyServices.DictStatusId);
            ViewData["ListOfCinematographyId"] = new SelectList(_context.ListOfCinematography, "Id", "NameRus", listOfCinematographyServices.ListOfCinematographyId);
            return View(listOfCinematographyServices);
        }

        // GET: Cinematography/ListOfCinematographyServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyServices = await _context.ListOfCinematographyServices.FindAsync(id);
            if (listOfCinematographyServices == null)
            {
                return NotFound();
            }
            ViewData["DictCinematographyServicesId"] = new SelectList(_context.DictCinematographyServices, "Id", "NameRus", listOfCinematographyServices.DictCinematographyServicesId);
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", listOfCinematographyServices.DictStatusId);
            ViewData["ListOfCinematographyId"] = new SelectList(_context.ListOfCinematography, "Id", "NameRus", listOfCinematographyServices.ListOfCinematographyId);
            return View(listOfCinematographyServices);
        }

        // POST: Cinematography/ListOfCinematographyServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DictCinematographyServicesId,ListOfCinematographyId,DictStatusId,DeactivateStatus,CreateDate,ApplicationUserId")] ListOfCinematographyServices listOfCinematographyServices)
        {
            if (id != listOfCinematographyServices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfCinematographyServices.ApplicationUserId = uid;
                    _context.Update(listOfCinematographyServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfCinematographyServicesExists(listOfCinematographyServices.Id))
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
            ViewData["DictCinematographyServicesId"] = new SelectList(_context.DictCinematographyServices, "Id", "NameRus", listOfCinematographyServices.DictCinematographyServicesId);
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", listOfCinematographyServices.DictStatusId);
            ViewData["ListOfCinematographyId"] = new SelectList(_context.ListOfCinematography, "Id", "NameRus", listOfCinematographyServices.ListOfCinematographyId);
            return View(listOfCinematographyServices);
        }

        // GET: Cinematography/ListOfCinematographyServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyServices = await _context.ListOfCinematographyServices
                .Include(l => l.DictCinematographyServices)
                .Include(l => l.DictStatus)
                .Include(l => l.ListOfCinematography)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCinematographyServices == null)
            {
                return NotFound();
            }

            return View(listOfCinematographyServices);
        }

        // POST: Cinematography/ListOfCinematographyServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfCinematographyServices = await _context.ListOfCinematographyServices.FindAsync(id);
            _context.ListOfCinematographyServices.Remove(listOfCinematographyServices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfCinematographyServicesExists(int id)
        {
            return _context.ListOfCinematographyServices.Any(e => e.Id == id);
        }
    }
}
