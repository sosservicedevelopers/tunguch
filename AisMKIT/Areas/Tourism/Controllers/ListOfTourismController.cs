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

namespace AisMKIT.Areas.Tourism.Controllers
{
    [Area("Tourism")]
    public class ListOfTourismController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ListOfTourismController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Tourism/ListOfTourism
        public async Task<IActionResult> Index(int Id=0)
        {
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", Id);
            var applicationDbContext = _context.ListOfTourism.Include(l => l.DictDistrict).Include(l => l.DictFinSource).Include(l => l.DictLegalForm);
            if (Id != 0)
                applicationDbContext = _context.ListOfTourism.Where(x => x.DictFinSourceId == Id & x.DeactiveDate == null).Include(l => l.DictFinSource).Include(l => l.DictLegalForm);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tourism/ListOfTourism/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTourism = await _context.ListOfTourism
                .Include(l => l.DictDistrict)
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfTourism == null)
            {
                return NotFound();
            }

            return View(listOfTourism);
        }

        // GET: Tourism/ListOfTourism/Create
        public IActionResult Create()
        {
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus");
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus");
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus");
            ViewData["FactDistrictId"] = new SelectList(_context.DictDistrict, "NameRus", "NameRus");
            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ListOfTourism model = new ListOfTourism();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            model.ApplicationUserId = uid;
            return View(model);
        }

        // POST: Tourism/ListOfTourism/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameRus,NameKyrg,DictLegalFormId,INN,LastNameDirector,FirstNameDirector,PatronicNameDirector,DictFinSourceId,DictDistrictId,LegalAddress,FactDistrictId,LegalFactAddress,RegistrationDate,ReregistrationDate,DeactiveDate,CreateDate,ApplicationUserId")] ListOfTourism listOfTourism)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfTourism);
                await _context.SaveChangesAsync();

                HistorSaved(listOfTourism);

                return RedirectToAction(nameof(Index));
            }
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfTourism.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfTourism.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfTourism.DictLegalFormId);
            ViewData["FactDistrictId"] = new SelectList(_context.DictDistrict, "NameRus", "NameRus", listOfTourism.FactDistrictId);
            
            return View(listOfTourism);
        }

        private void HistorSaved(ListOfTourism listOfTourism)
        {
            ListOfTourismHistory lh = new ListOfTourismHistory();
            lh.CreateDate = listOfTourism.CreateDate;
            lh.DeactiveDate = listOfTourism.DeactiveDate;
            lh.DictDistrictId = listOfTourism.DictDistrictId;
            lh.DictFinSourceId = listOfTourism.DictFinSourceId;
            lh.DictLegalFormId = listOfTourism.DictLegalFormId;
            lh.FactDistrictId = listOfTourism.FactDistrictId;
            lh.FirstNameDirector = listOfTourism.FirstNameDirector;
            lh.INN = listOfTourism.INN;
            lh.LastNameDirector = listOfTourism.LastNameDirector;
            lh.LegalAddress = listOfTourism.LegalAddress;
            lh.LegalFactAddress = listOfTourism.LegalFactAddress;
            lh.ListOfTourismId = listOfTourism.Id;
            lh.NameKyrg = listOfTourism.NameKyrg;
            lh.NameRus = listOfTourism.NameRus;
            lh.PatronicNameDirector = listOfTourism.PatronicNameDirector;
            lh.RegistrationDate = listOfTourism.RegistrationDate;
            lh.ReregistrationDate = listOfTourism.ReregistrationDate;
            _context.ListOfTourismHistory.Add(lh);
            _context.SaveChanges();
        }

        // GET: Tourism/ListOfTourism/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTourism = await _context.ListOfTourism.FindAsync(id);
            if (listOfTourism == null)
            {
                return NotFound();
            }
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfTourism.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfTourism.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfTourism.DictLegalFormId);
            ViewData["FactDistrictId"] = new SelectList(_context.DictDistrict, "NameRus", "NameRus", listOfTourism.FactDistrictId);
            return View(listOfTourism);
        }

        // POST: Tourism/ListOfTourism/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameRus,NameKyrg,DictLegalFormId,INN,LastNameDirector,FirstNameDirector,PatronicNameDirector,DictFinSourceId,DictDistrictId,LegalAddress,FactDistrictId,LegalFactAddress,RegistrationDate,ReregistrationDate,DeactiveDate,CreateDate,ApplicationUserId")] ListOfTourism listOfTourism, string SubmitButton="")
        {
            if (id != listOfTourism.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfTourism.ApplicationUserId = uid;
                    _context.Update(listOfTourism);
                    await _context.SaveChangesAsync();
                    if (SubmitButton == "Перерегистрировать") HistorSaved(listOfTourism);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfTourismExists(listOfTourism.Id))
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
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfTourism.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfTourism.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfTourism.DictLegalFormId);
            ViewData["FactDistrictId"] = new SelectList(_context.DictDistrict, "NameRus", "NameRus", listOfTourism.FactDistrictId);
            return View(listOfTourism);
        }

        // GET: Tourism/ListOfTourism/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfTourism = await _context.ListOfTourism
                .Include(l => l.DictDistrict)
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfTourism == null)
            {
                return NotFound();
            }

            return View(listOfTourism);
        }

        // POST: Tourism/ListOfTourism/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfTourism = await _context.ListOfTourism.FindAsync(id);
            _context.ListOfTourism.Remove(listOfTourism);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfTourismExists(int id)
        {
            return _context.ListOfTourism.Any(e => e.Id == id);
        }
    }
}
