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
using Microsoft.AspNetCore.Authorization;

namespace AisMKIT.Areas.Library.Controllers
{
    [Area("Library")]
    [Authorize(Roles = "Администратор,Администратор-Библиотека")]
    public class ListOfLibraryIndicatorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ListOfLibraryIndicatorsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Library/ListOfLibraryIndicators
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfLibraryIndicators.Include(l => l.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Library/ListOfLibraryIndicators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfLibraryIndicators = await _context.ListOfLibraryIndicators
                .Include(l => l.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfLibraryIndicators == null)
            {
                return NotFound();
            }

            return View(listOfLibraryIndicators);
        }

        // GET: Library/ListOfLibraryIndicators/Create
        public IActionResult Create()
        {

            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ListOfLibraryIndicators model = new ListOfLibraryIndicators();
            model.CreateDate = DateTime.Now;            
            model.ApplicationUserId = uid;

            return View(model);
        }

        // POST: Library/ListOfLibraryIndicators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LibraryName,DataSozdania,CountOfBook,CountOfReaders,CountOfEmp,Knigovydacha,AddressData,TotalArea,SeatLanding,EmerCapLib,SpecAdapLib,OverhaulMade,Redecorated,Computers,InternetConnection,ComputersForUsers,UserConnection,UsersLib,RecRetTotal,TotalNumOfEx,CopKyrg,EventsLib,Librarians,DegEducation,ApplicationUserId,PravaUstanavDoc,CreateDate")] ListOfLibraryIndicators listOfLibraryIndicators)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfLibraryIndicators);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listOfLibraryIndicators);
        }

        // GET: Library/ListOfLibraryIndicators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfLibraryIndicators = await _context.ListOfLibraryIndicators.FindAsync(id);
            if (listOfLibraryIndicators == null)
            {
                return NotFound();
            }
            return View(listOfLibraryIndicators);
        }

        // POST: Library/ListOfLibraryIndicators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LibraryName,DataSozdania,CountOfBook,CountOfReaders,CountOfEmp,Knigovydacha,AddressData,TotalArea,SeatLanding,EmerCapLib,SpecAdapLib,OverhaulMade,Redecorated,Computers,InternetConnection,ComputersForUsers,UserConnection,UsersLib,RecRetTotal,TotalNumOfEx,CopKyrg,EventsLib,Librarians,DegEducation,ApplicationUserId,PravaUstanavDoc")] ListOfLibraryIndicators listOfLibraryIndicators)
        {
            if (id != listOfLibraryIndicators.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfLibraryIndicators.ApplicationUserId = uid;
                    _context.Update(listOfLibraryIndicators);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfLibraryIndicatorsExists(listOfLibraryIndicators.Id))
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
            return View(listOfLibraryIndicators);
        }

        // GET: Library/ListOfLibraryIndicators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfLibraryIndicators = await _context.ListOfLibraryIndicators
                .Include(l => l.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfLibraryIndicators == null)
            {
                return NotFound();
            }

            return View(listOfLibraryIndicators);
        }

        // POST: Library/ListOfLibraryIndicators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfLibraryIndicators = await _context.ListOfLibraryIndicators.FindAsync(id);
            _context.ListOfLibraryIndicators.Remove(listOfLibraryIndicators);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfLibraryIndicatorsExists(int id)
        {
            return _context.ListOfLibraryIndicators.Any(e => e.Id == id);
        }
    }
}
