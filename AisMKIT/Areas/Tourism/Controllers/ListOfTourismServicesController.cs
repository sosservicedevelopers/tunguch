using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.Tourism.Controllers
{
    [Area("Tourism")]
    public class ListOfTourismServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListOfTourismServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tourism/ListOfTourismServices
        public async Task<IActionResult> Index(int id=0)
        {
            HttpContext.Response.Cookies.Append("ListOfTourism", id.ToString());
            var applicationDbContext = _context.ListOfTourismServices.Include(l => l.DictStatus).Include(l => l.DictTourismServices).Include(l => l.ListOfTourism);
            if (id != 0)
                applicationDbContext = _context.ListOfTourismServices.Where(x => x.ListOfTourismId == id & x.DeactivateStatus== null).Include(l => l.DictTourismServices).Include(l => l.ListOfTourism);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tourism/ListOfTourismServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTourismServices = await _context.ListOfTourismServices
                .Include(l => l.DictStatus)
                .Include(l => l.DictTourismServices)
                .Include(l => l.ListOfTourism)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfTourismServices == null)
            {
                return NotFound();
            }

            return View(listOfTourismServices);
        }

        // GET: Tourism/ListOfTourismServices/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            ViewData["DictTourismServicesId"] = new SelectList(_context.DictTourismServices, "Id", "NameRus");
            ViewData["ListOfTourismId"] = new SelectList(_context.ListOfTourism, "Id", "NameRus");
            string name = "0";
            if (HttpContext.Request.Cookies.ContainsKey("ListOfTourism"))
                name = HttpContext.Request.Cookies["ListOfTourism"];
            ListOfTourismServices model = new ListOfTourismServices();
            model.ListOfTourismId = int.Parse(name);
            model.CreateDate = DateTime.Now;
            return View(model);
        }

        // POST: Tourism/ListOfTourismServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DictTourismServicesId,ListOfTourismId,DictStatusId,DeactivateStatus,CreateDate")] ListOfTourismServices listOfTourismServices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfTourismServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", listOfTourismServices.DictStatusId);
            ViewData["DictTourismServicesId"] = new SelectList(_context.DictTourismServices, "Id", "NameRus", listOfTourismServices.DictTourismServicesId);
            ViewData["ListOfTourismId"] = new SelectList(_context.ListOfTourism, "Id", "NameRus", listOfTourismServices.ListOfTourismId);
            return View(listOfTourismServices);
        }

        // GET: Tourism/ListOfTourismServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTourismServices = await _context.ListOfTourismServices.FindAsync(id);
            if (listOfTourismServices == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", listOfTourismServices.DictStatusId);
            ViewData["DictTourismServicesId"] = new SelectList(_context.DictTourismServices, "Id", "NameRus", listOfTourismServices.DictTourismServicesId);
            ViewData["ListOfTourismId"] = new SelectList(_context.ListOfTourism, "Id", "NameRus", listOfTourismServices.ListOfTourismId);
            return View(listOfTourismServices);
        }

        // POST: Tourism/ListOfTourismServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DictTourismServicesId,ListOfTourismId,DictStatusId,DeactivateStatus,CreateDate")] ListOfTourismServices listOfTourismServices)
        {
            if (id != listOfTourismServices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfTourismServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfTourismServicesExists(listOfTourismServices.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", listOfTourismServices.DictStatusId);
            ViewData["DictTourismServicesId"] = new SelectList(_context.DictTourismServices, "Id", "NameRus", listOfTourismServices.DictTourismServicesId);
            ViewData["ListOfTourismId"] = new SelectList(_context.ListOfTourism, "Id", "NameRus", listOfTourismServices.ListOfTourismId);
            return View(listOfTourismServices);
        }

        // GET: Tourism/ListOfTourismServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTourismServices = await _context.ListOfTourismServices
                .Include(l => l.DictStatus)
                .Include(l => l.DictTourismServices)
                .Include(l => l.ListOfTourism)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfTourismServices == null)
            {
                return NotFound();
            }

            return View(listOfTourismServices);
        }

        // POST: Tourism/ListOfTourismServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfTourismServices = await _context.ListOfTourismServices.FindAsync(id);
            _context.ListOfTourismServices.Remove(listOfTourismServices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfTourismServicesExists(int id)
        {
            return _context.ListOfTourismServices.Any(e => e.Id == id);
        }
    }
}
