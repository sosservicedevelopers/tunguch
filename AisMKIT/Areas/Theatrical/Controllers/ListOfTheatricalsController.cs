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
    public class ListOfTheatricalsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListOfTheatricalsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Theatrical/ListOfTheatricals
        public async Task<IActionResult> Index(int Id=0)
        {
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", Id);
            var applicationDbContext = _context.ListOfTheatrical.Include(l => l.DictFinSource).Include(l => l.DictLegalForm);
            if (Id!=0)
            applicationDbContext = _context.ListOfTheatrical.Where(x=>x.DictFinSourceId == Id & x.DeactiveDate==null).Include(l => l.DictFinSource).Include(l => l.DictLegalForm);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Theatrical/ListOfTheatricals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTheatrical = await _context.ListOfTheatrical
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfTheatrical == null)
            {
                return NotFound();
            }

            return View(listOfTheatrical);
        }

        // GET: Theatrical/ListOfTheatricals/Create
        public IActionResult Create()
        {
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus");
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus");

            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ListOfTheatrical model = new ListOfTheatrical();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            model.ApplicationUserId = uid;


            return View(model);
        }

        // POST: Theatrical/ListOfTheatricals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameRus,NameKyrg,DictLegalFormId,INN,LastNameDirector,FirstNameDirector,PatronicNameDirector,LastNameOfArtsDirector,FirstNameOfArtsDirector,PatronicNameOfArtsDirector,NumEmployees,DictFinSourceId,ReregistrationDate,DeactiveDate,CreateDate,ApplicationUserId")] ListOfTheatrical listOfTheatrical)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfTheatrical);
                await _context.SaveChangesAsync();
                HistorySaved(listOfTheatrical);

                return RedirectToAction(nameof(Index));
            }
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfTheatrical.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfTheatrical.DictLegalFormId);
            return View(listOfTheatrical);
        }

        private void HistorySaved(ListOfTheatrical listOfTheatrical)
        {
            ListOfTheatricalHistory lh = new ListOfTheatricalHistory();
            lh.CreateDate = DateTime.Now;
            lh.DeactiveDate = listOfTheatrical.DeactiveDate;
            lh.DictFinSourceId = listOfTheatrical.DictFinSourceId;
            lh.DictLegalFormId = listOfTheatrical.DictLegalFormId;
            lh.FirstNameDirector = listOfTheatrical.FirstNameDirector;
            lh.FirstNameOfArtsDirector = lh.FirstNameOfArtsDirector;
            lh.INN = listOfTheatrical.INN;
            lh.LastNameDirector = listOfTheatrical.LastNameDirector;
            lh.LastNameOfArtsDirector = listOfTheatrical.LastNameOfArtsDirector;
            lh.ListOfTheatricalId = listOfTheatrical.Id;
            lh.NameKyrg = listOfTheatrical.NameKyrg;
            lh.NameRus = listOfTheatrical.NameRus;
            lh.NumEmployees = listOfTheatrical.NumEmployees;
            lh.PatronicNameDirector = listOfTheatrical.PatronicNameDirector;
            lh.PatronicNameOfArtsDirector = listOfTheatrical.PatronicNameOfArtsDirector;
            lh.ReregistrationDate = listOfTheatrical.ReregistrationDate;
            _context.ListOfTheatricalHistory.Add(lh);
            _context.SaveChanges();
        }

        // GET: Theatrical/ListOfTheatricals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTheatrical = await _context.ListOfTheatrical.FindAsync(id);
            if (listOfTheatrical == null)
            {
                return NotFound();
            }
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfTheatrical.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfTheatrical.DictLegalFormId);
            return View(listOfTheatrical);
        }

        // POST: Theatrical/ListOfTheatricals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameRus,NameKyrg,DictLegalFormId,INN,LastNameDirector,FirstNameDirector,PatronicNameDirector,LastNameOfArtsDirector,FirstNameOfArtsDirector,PatronicNameOfArtsDirector,NumEmployees,DictFinSourceId,ReregistrationDate,DeactiveDate,CreateDate,ApplicationUserId")] ListOfTheatrical listOfTheatrical, string SubmitButton="")
        {
            if (id != listOfTheatrical.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfTheatrical.ApplicationUserId = uid;

                    _context.Update(listOfTheatrical);
                    await _context.SaveChangesAsync();
                    if (SubmitButton == "Перерегистрировать") HistorySaved(listOfTheatrical);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfTheatricalExists(listOfTheatrical.Id))
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
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfTheatrical.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfTheatrical.DictLegalFormId);
            return View(listOfTheatrical);
        }

        // GET: Theatrical/ListOfTheatricals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTheatrical = await _context.ListOfTheatrical
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfTheatrical == null)
            {
                return NotFound();
            }

            return View(listOfTheatrical);
        }

        // POST: Theatrical/ListOfTheatricals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfTheatrical = await _context.ListOfTheatrical.FindAsync(id);
            _context.ListOfTheatrical.Remove(listOfTheatrical);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfTheatricalExists(int id)
        {
            return _context.ListOfTheatrical.Any(e => e.Id == id);
        }
    }
}
