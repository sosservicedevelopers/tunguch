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
    public class ListOfEduInstitutsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListOfEduInstitutsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Theatrical/ListOfEduInstituts
        public async Task<IActionResult> Index(int id=0)
        {
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", id);
            var applicationDbContext = _context.ListOfEduInstituts.Include(l => l.DictEduInstType).Include(l => l.DictFinSource).Include(l => l.DictLegalForm);
            if (id != 0)
                applicationDbContext = _context.ListOfEduInstituts.Where(x => x.DictFinSourceId == id & x.DeactiveDate == null).Include(l => l.DictFinSource).Include(l => l.DictLegalForm);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Theatrical/ListOfEduInstituts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEduInstituts = await _context.ListOfEduInstituts
                .Include(l => l.DictEduInstType)
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfEduInstituts == null)
            {
                return NotFound();
            }

            return View(listOfEduInstituts);
        }

        // GET: Theatrical/ListOfEduInstituts/Create
        public IActionResult Create()
        {
            ViewData["DictEduInstTypeId"] = new SelectList(_context.DictEduInstType, "Id", "NameRus");
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus");
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus");
            
            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            ListOfEduInstituts model = new ListOfEduInstituts();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            model.ApplicationUserId = uid;

            return View(model);
        }

        // POST: Theatrical/ListOfEduInstituts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameRus,NameKyrg,DictLegalFormId,INN,LastNameDirector,FirstNameDirector,PatronicNameDirector,DictEduInstTypeId,DictFinSourceId,RegistrationDate,ReregistrationDate,DeactiveDate,CreateDate,ApplicationUserId,LegalDocuments")] ListOfEduInstituts listOfEduInstituts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfEduInstituts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictEduInstTypeId"] = new SelectList(_context.DictEduInstType, "Id", "NameRus", listOfEduInstituts.DictEduInstTypeId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfEduInstituts.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfEduInstituts.DictLegalFormId);
            return View(listOfEduInstituts);
        }

        // GET: Theatrical/ListOfEduInstituts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEduInstituts = await _context.ListOfEduInstituts.FindAsync(id);
            if (listOfEduInstituts == null)
            {
                return NotFound();
            }
            ViewData["DictEduInstTypeId"] = new SelectList(_context.DictEduInstType, "Id", "NameRus", listOfEduInstituts.DictEduInstTypeId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfEduInstituts.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfEduInstituts.DictLegalFormId);
            return View(listOfEduInstituts);
        }

        // POST: Theatrical/ListOfEduInstituts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameRus,NameKyrg,DictLegalFormId,INN,LastNameDirector,FirstNameDirector,PatronicNameDirector,DictEduInstTypeId,DictFinSourceId,RegistrationDate,ReregistrationDate,DeactiveDate,CreateDate,ApplicationUserId,LegalDocuments")] ListOfEduInstituts listOfEduInstituts)
        {
            if (id != listOfEduInstituts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfEduInstituts.ApplicationUserId = uid;

                    _context.Update(listOfEduInstituts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfEduInstitutsExists(listOfEduInstituts.Id))
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
            ViewData["DictEduInstTypeId"] = new SelectList(_context.DictEduInstType, "Id", "NameRus", listOfEduInstituts.DictEduInstTypeId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfEduInstituts.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfEduInstituts.DictLegalFormId);
            return View(listOfEduInstituts);
        }

        // GET: Theatrical/ListOfEduInstituts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEduInstituts = await _context.ListOfEduInstituts
                .Include(l => l.DictEduInstType)
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfEduInstituts == null)
            {
                return NotFound();
            }

            return View(listOfEduInstituts);
        }

        // POST: Theatrical/ListOfEduInstituts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfEduInstituts = await _context.ListOfEduInstituts.FindAsync(id);
            _context.ListOfEduInstituts.Remove(listOfEduInstituts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfEduInstitutsExists(int id)
        {
            return _context.ListOfEduInstituts.Any(e => e.Id == id);
        }
    }
}
