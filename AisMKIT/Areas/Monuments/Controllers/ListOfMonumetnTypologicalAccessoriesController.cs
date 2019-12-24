using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.Monuments.Controllers
{
    [Area("Monuments")]
    public class ListOfMonumetnTypologicalAccessoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListOfMonumetnTypologicalAccessoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Monuments/ListOfMonumetnTypologicalAccessories
        public async Task<IActionResult> Index(int id = 0)
        {
            HttpContext.Response.Cookies.Append("ListTheatricalsId", id.ToString());
            
            var applicationDbContext = _context.ListOfMonumetnTypologicalAccessory.Where(x=>x.ListOfMonumentsId==id).Include(l => l.DictMonumentTypologicalType).Include(l => l.ListOfMonuments);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Monuments/ListOfMonumetnTypologicalAccessories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMonumetnTypologicalAccessory = await _context.ListOfMonumetnTypologicalAccessory
                .Include(l => l.DictMonumentTypologicalType)
                .Include(l => l.ListOfMonuments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfMonumetnTypologicalAccessory == null)
            {
                return NotFound();
            }

            return View(listOfMonumetnTypologicalAccessory);
        }

        // GET: Monuments/ListOfMonumetnTypologicalAccessories/Create
        public IActionResult Create()
        {
            ViewData["DictMonumentTypologicalTypeId"] = new SelectList(_context.DictMonumentTypologicalType, "Id", "NameRus");
            ViewData["ListOfMonumentsId"] = new SelectList(_context.ListOfMonuments, "Id", "Id");
            string name = "0";
            if (HttpContext.Request.Cookies.ContainsKey("ListTheatricalsId"))
                name = HttpContext.Request.Cookies["ListTheatricalsId"];
            ListOfMonumetnTypologicalAccessory model = new ListOfMonumetnTypologicalAccessory();
            model.CreateDate = DateTime.Now;
            model.ListOfMonumentsId = int.Parse(name);
            return View(model);
        }

        // POST: Monuments/ListOfMonumetnTypologicalAccessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListOfMonumentsId,DictMonumentTypologicalTypeId,CreateDate")] ListOfMonumetnTypologicalAccessory listOfMonumetnTypologicalAccessory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfMonumetnTypologicalAccessory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = listOfMonumetnTypologicalAccessory.ListOfMonumentsId });
            }
            ViewData["DictMonumentTypologicalTypeId"] = new SelectList(_context.DictMonumentTypologicalType, "Id", "NameRus", listOfMonumetnTypologicalAccessory.DictMonumentTypologicalTypeId);
            ViewData["ListOfMonumentsId"] = new SelectList(_context.ListOfMonuments, "Id", "Id", listOfMonumetnTypologicalAccessory.ListOfMonumentsId);
            return View(listOfMonumetnTypologicalAccessory);
        }

        // GET: Monuments/ListOfMonumetnTypologicalAccessories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMonumetnTypologicalAccessory = await _context.ListOfMonumetnTypologicalAccessory.FindAsync(id);
            if (listOfMonumetnTypologicalAccessory == null)
            {
                return NotFound();
            }
            ViewData["DictMonumentTypologicalTypeId"] = new SelectList(_context.DictMonumentTypologicalType, "Id", "NameRus", listOfMonumetnTypologicalAccessory.DictMonumentTypologicalTypeId);
            ViewData["ListOfMonumentsId"] = new SelectList(_context.ListOfMonuments, "Id", "Id", listOfMonumetnTypologicalAccessory.ListOfMonumentsId);
            return View(listOfMonumetnTypologicalAccessory);
        }

        // POST: Monuments/ListOfMonumetnTypologicalAccessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListOfMonumentsId,DictMonumentTypologicalTypeId,CreateDate")] ListOfMonumetnTypologicalAccessory listOfMonumetnTypologicalAccessory)
        {
            if (id != listOfMonumetnTypologicalAccessory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfMonumetnTypologicalAccessory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfMonumetnTypologicalAccessoryExists(listOfMonumetnTypologicalAccessory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = listOfMonumetnTypologicalAccessory.ListOfMonumentsId });
            }
            ViewData["DictMonumentTypologicalTypeId"] = new SelectList(_context.DictMonumentTypologicalType, "Id", "NameRus", listOfMonumetnTypologicalAccessory.DictMonumentTypologicalTypeId);
            ViewData["ListOfMonumentsId"] = new SelectList(_context.ListOfMonuments, "Id", "Id", listOfMonumetnTypologicalAccessory.ListOfMonumentsId);
            return View(listOfMonumetnTypologicalAccessory);
        }

        // GET: Monuments/ListOfMonumetnTypologicalAccessories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMonumetnTypologicalAccessory = await _context.ListOfMonumetnTypologicalAccessory
                .Include(l => l.DictMonumentTypologicalType)
                .Include(l => l.ListOfMonuments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfMonumetnTypologicalAccessory == null)
            {
                return NotFound();
            }

            return View(listOfMonumetnTypologicalAccessory);
        }

        // POST: Monuments/ListOfMonumetnTypologicalAccessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfMonumetnTypologicalAccessory = await _context.ListOfMonumetnTypologicalAccessory.FindAsync(id);
            _context.ListOfMonumetnTypologicalAccessory.Remove(listOfMonumetnTypologicalAccessory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = listOfMonumetnTypologicalAccessory.ListOfMonumentsId });
        }

        private bool ListOfMonumetnTypologicalAccessoryExists(int id)
        {
            return _context.ListOfMonumetnTypologicalAccessory.Any(e => e.Id == id);
        }
    }
}
