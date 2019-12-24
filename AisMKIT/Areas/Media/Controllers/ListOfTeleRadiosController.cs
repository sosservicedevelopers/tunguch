using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.Media.Controllers
{
    [Area("Media")]
    public class ListOfTeleRadiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListOfTeleRadiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Media/ListOfTeleRadios
        public async Task<IActionResult> Index(int id=0)
        {
            HttpContext.Response.Cookies.Append("ListOfMediaId", id.ToString());

            var applicationDbContext = _context.ListOfTeleRadio.Where(x=>x.ListOfMediaId== id).Include(l => l.DictAgencyPerm).Include(l => l.ListOfMedia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Media/ListOfTeleRadios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTeleRadio = await _context.ListOfTeleRadio
                .Include(l => l.DictAgencyPerm)
                .Include(l => l.ListOfMedia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfTeleRadio == null)
            {
                return NotFound();
            }

            return View(listOfTeleRadio);
        }

        // GET: Media/ListOfTeleRadios/Create
        public IActionResult Create()
        {
            ViewData["DictAgencyPermId"] = new SelectList(_context.DictAgencyPerm, "Id", "NameRus");
            string name = "0";
            if (HttpContext.Request.Cookies.ContainsKey("ListOfMediaId"))
                name = HttpContext.Request.Cookies["ListOfMediaId"];
            ListOfTeleRadio model = new ListOfTeleRadio();
            model.ListOfMediaId = int.Parse(name);
            model.CreateDate = DateTime.Now;
            return View(model);
        }

        // POST: Media/ListOfTeleRadios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListOfMediaId,CreateDate,NumberOfPermission,PermissionDate,DictAgencyPermId,DateOfPay,NumOfPermGas,PermGASDate,PermElimGASDate")] ListOfTeleRadio listOfTeleRadio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfTeleRadio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),new { id=listOfTeleRadio.ListOfMediaId });
            }
            ViewData["DictAgencyPermId"] = new SelectList(_context.DictAgencyPerm, "Id", "NameRus", listOfTeleRadio.DictAgencyPermId);
            return View(listOfTeleRadio);
        }

        // GET: Media/ListOfTeleRadios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTeleRadio = await _context.ListOfTeleRadio.FindAsync(id);
            if (listOfTeleRadio == null)
            {
                return NotFound();
            }
            ViewData["DictAgencyPermId"] = new SelectList(_context.DictAgencyPerm, "Id", "NameRus", listOfTeleRadio.DictAgencyPermId);
            return View(listOfTeleRadio);
        }

        // POST: Media/ListOfTeleRadios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListOfMediaId,CreateDate,NumberOfPermission,PermissionDate,DictAgencyPermId,DateOfPay,NumOfPermGas,PermGASDate,PermElimGASDate")] ListOfTeleRadio listOfTeleRadio)
        {
            if (id != listOfTeleRadio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfTeleRadio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfTeleRadioExists(listOfTeleRadio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {id=listOfTeleRadio.ListOfMediaId });
            }
            ViewData["DictAgencyPermId"] = new SelectList(_context.DictAgencyPerm, "Id", "NameRus", listOfTeleRadio.DictAgencyPermId);
            return View(listOfTeleRadio);
        }

        // GET: Media/ListOfTeleRadios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTeleRadio = await _context.ListOfTeleRadio
                .Include(l => l.DictAgencyPerm)
                .Include(l => l.ListOfMedia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfTeleRadio == null)
            {
                return NotFound();
            }

            return View(listOfTeleRadio);
        }

        // POST: Media/ListOfTeleRadios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfTeleRadio = await _context.ListOfTeleRadio.FindAsync(id);
            _context.ListOfTeleRadio.Remove(listOfTeleRadio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfTeleRadioExists(int id)
        {
            return _context.ListOfTeleRadio.Any(e => e.Id == id);
        }
    }
}
