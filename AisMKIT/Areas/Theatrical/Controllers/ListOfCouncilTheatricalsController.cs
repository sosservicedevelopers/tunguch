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


namespace AisMKIT.Areas.Theatrical.Controllers
{
    [Area("Theatrical")]
    public class ListOfCouncilTheatricalsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListOfCouncilTheatricalsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Theatrical/ListOfCouncilTheatricals
        public async Task<IActionResult> Index(int id = 0)
        {
            HttpContext.Response.Cookies.Append("ListTheatricalsId", id.ToString());
            var applicationDbContext = _context.ListOfCouncilTheatrical.Where(x=>x.ListOfTheatricalId==id).Include(l => l.ListOfTheatrical);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Theatrical/ListOfCouncilTheatricals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCouncilTheatrical = await _context.ListOfCouncilTheatrical
                .Include(l => l.ListOfTheatrical)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCouncilTheatrical == null)
            {
                return NotFound();
            }

            return View(listOfCouncilTheatrical);
        }

        // GET: Theatrical/ListOfCouncilTheatricals/Create
        public IActionResult Create()
        {
            string name = "0";
            if (HttpContext.Request.Cookies.ContainsKey("ListTheatricalsId"))
                name = HttpContext.Request.Cookies["ListTheatricalsId"];

            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ListOfCouncilTheatrical model = new ListOfCouncilTheatrical();
            model.ListOfTheatricalId = int.Parse(name);
            model.CreateDate = DateTime.Now;
            model.ApplicationUserId = uid;


            ViewData["ListOfTheatricalId"] = new SelectList(_context.ListOfTheatrical, "Id", "NameRus");
            return View(model);
        }

        // POST: Theatrical/ListOfCouncilTheatricals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListOfTheatricalId,LastNameOfArts,FirstNameOfArts,PatronicNameOfArts,DateInArtCouncil,DateOutArtCouncil,CreateDate,ApplicationUserId")] ListOfCouncilTheatrical listOfCouncilTheatrical)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfCouncilTheatrical);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id=listOfCouncilTheatrical.ListOfTheatricalId});
            }
            ViewData["ListOfTheatricalId"] = new SelectList(_context.ListOfTheatrical, "Id", "NameRus", listOfCouncilTheatrical.ListOfTheatricalId);
            return View(listOfCouncilTheatrical);
        }

        // GET: Theatrical/ListOfCouncilTheatricals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCouncilTheatrical = await _context.ListOfCouncilTheatrical.FindAsync(id);
            if (listOfCouncilTheatrical == null)
            {
                return NotFound();
            }
            ViewData["ListOfTheatricalId"] = new SelectList(_context.ListOfTheatrical, "Id", "NameRus", listOfCouncilTheatrical.ListOfTheatricalId);
            return View(listOfCouncilTheatrical);
        }

        // POST: Theatrical/ListOfCouncilTheatricals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListOfTheatricalId,LastNameOfArts,FirstNameOfArts,PatronicNameOfArts,DateInArtCouncil,DateOutArtCouncil,CreateDate,ApplicationUserId")] ListOfCouncilTheatrical listOfCouncilTheatrical)
        {
            if (id != listOfCouncilTheatrical.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfCouncilTheatrical.ApplicationUserId = uid;

                    _context.Update(listOfCouncilTheatrical);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfCouncilTheatricalExists(listOfCouncilTheatrical.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = listOfCouncilTheatrical.ListOfTheatricalId });
            }
            ViewData["ListOfTheatricalId"] = new SelectList(_context.ListOfTheatrical, "Id", "NameRus", listOfCouncilTheatrical.ListOfTheatricalId);
            return View(listOfCouncilTheatrical);
        }

        // GET: Theatrical/ListOfCouncilTheatricals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCouncilTheatrical = await _context.ListOfCouncilTheatrical
                .Include(l => l.ListOfTheatrical)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCouncilTheatrical == null)
            {
                return NotFound();
            }

            return View(listOfCouncilTheatrical);
        }

        // POST: Theatrical/ListOfCouncilTheatricals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfCouncilTheatrical = await _context.ListOfCouncilTheatrical.FindAsync(id);
            _context.ListOfCouncilTheatrical.Remove(listOfCouncilTheatrical);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfCouncilTheatricalExists(int id)
        {
            return _context.ListOfCouncilTheatrical.Any(e => e.Id == id);
        }
    }
}
