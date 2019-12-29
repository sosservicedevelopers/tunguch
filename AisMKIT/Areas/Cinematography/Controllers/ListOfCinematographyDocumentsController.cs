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

namespace AisMKIT.Areas.Cinematography.Controllers
{
    [Area("Cinematography")]
    public class ListOfCinematographyDocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ListOfCinematographyDocumentsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: Cinematography/ListOfCinematographyDocuments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfCinematographyDocuments.Include(l => l.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cinematography/ListOfCinematographyDocuments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyDocuments = await _context.ListOfCinematographyDocuments
                .Include(l => l.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCinematographyDocuments == null)
            {
                return NotFound();
            }

            return View(listOfCinematographyDocuments);
        }

        // GET: Cinematography/ListOfCinematographyDocuments/Create
        public IActionResult Create()
        {
            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ListOfCinematographyDocuments model = new ListOfCinematographyDocuments();
            model.CreateDate = DateTime.Now;
            model.ApplicationUserId = uid;
            return View(model);
        }

        // POST: Cinematography/ListOfCinematographyDocuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameRus,RegistrationDate,CreateDate,ApplicationUserId")] ListOfCinematographyDocuments listOfCinematographyDocuments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfCinematographyDocuments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
             return View(listOfCinematographyDocuments);
        }

        // GET: Cinematography/ListOfCinematographyDocuments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyDocuments = await _context.ListOfCinematographyDocuments.FindAsync(id);
            if (listOfCinematographyDocuments == null)
            {
                return NotFound();
            }
             return View(listOfCinematographyDocuments);
        }

        // POST: Cinematography/ListOfCinematographyDocuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameRus,RegistrationDate,CreateDate,ApplicationUserId")] ListOfCinematographyDocuments listOfCinematographyDocuments)
        {
            if (id != listOfCinematographyDocuments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfCinematographyDocuments.ApplicationUserId = uid;
                    _context.Update(listOfCinematographyDocuments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfCinematographyDocumentsExists(listOfCinematographyDocuments.Id))
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
            return View(listOfCinematographyDocuments);
        }

        // GET: Cinematography/ListOfCinematographyDocuments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyDocuments = await _context.ListOfCinematographyDocuments
                .Include(l => l.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCinematographyDocuments == null)
            {
                return NotFound();
            }

            return View(listOfCinematographyDocuments);
        }

        // POST: Cinematography/ListOfCinematographyDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfCinematographyDocuments = await _context.ListOfCinematographyDocuments.FindAsync(id);
            _context.ListOfCinematographyDocuments.Remove(listOfCinematographyDocuments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfCinematographyDocumentsExists(int id)
        {
            return _context.ListOfCinematographyDocuments.Any(e => e.Id == id);
        }
    }
}
