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

namespace AisMKIT.Areas.CultAndArt.Controllers
{
    [Area("CultAndArt")]
    public class ListOfCultAndArtsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListOfCultAndArtsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: CultAndArt/ListOfCultAndArts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfCultAndArt.Include(l => l.ApplicationUser).Include(l => l.DictCultAndArtType).Include(l => l.DictDistrict).Include(l => l.DictFinSource).Include(l => l.DictLegalForm);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CultAndArt/ListOfCultAndArts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCultAndArt = await _context.ListOfCultAndArt
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictCultAndArtType)
                .Include(l => l.DictDistrict)
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCultAndArt == null)
            {
                return NotFound();
            }

            return View(listOfCultAndArt);
        }

        // GET: CultAndArt/ListOfCultAndArts/Create
        public IActionResult Create()
        {
            ViewData["DictCultAndArtTypeId"] = new SelectList(_context.DictCultAndArtType, "Id", "NameRus");
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus");
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus");
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus");
            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ListOfMonuments model = new ListOfMonuments();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            model.ApplicationUserId = uid;

            return View(model);
        }

        // POST: CultAndArt/ListOfCultAndArts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DictCultAndArtTypeId,NameRus,NameKyrg,DictLegalFormId,INN,LastNameDirector,FirstNameDirector,PatronicNameDirector,DictFinSourceId,DictDistrictId,LegalAddress,RegistrationDate,ReregistrationDate,DeactiveDate,CreateDate,ApplicationUserId")] ListOfCultAndArt listOfCultAndArt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfCultAndArt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["DictCultAndArtTypeId"] = new SelectList(_context.DictCultAndArtType, "Id", "NameRus", listOfCultAndArt.DictCultAndArtTypeId);
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfCultAndArt.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfCultAndArt.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfCultAndArt.DictLegalFormId);
            return View(listOfCultAndArt);
        }

        // GET: CultAndArt/ListOfCultAndArts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCultAndArt = await _context.ListOfCultAndArt.FindAsync(id);
            if (listOfCultAndArt == null)
            {
                return NotFound();
            }
            ViewData["DictCultAndArtTypeId"] = new SelectList(_context.DictCultAndArtType, "Id", "NameRus", listOfCultAndArt.DictCultAndArtTypeId);
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfCultAndArt.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfCultAndArt.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfCultAndArt.DictLegalFormId);
            return View(listOfCultAndArt);
        }

        // POST: CultAndArt/ListOfCultAndArts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DictCultAndArtTypeId,NameRus,NameKyrg,DictLegalFormId,INN,LastNameDirector,FirstNameDirector,PatronicNameDirector,DictFinSourceId,DictDistrictId,LegalAddress,RegistrationDate,ReregistrationDate,DeactiveDate,CreateDate,ApplicationUserId")] ListOfCultAndArt listOfCultAndArt)
        {
            if (id != listOfCultAndArt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfCultAndArt.ApplicationUserId = uid;
                    _context.Update(listOfCultAndArt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfCultAndArtExists(listOfCultAndArt.Id))
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
             ViewData["DictCultAndArtTypeId"] = new SelectList(_context.DictCultAndArtType, "Id", "NameRus", listOfCultAndArt.DictCultAndArtTypeId);
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfCultAndArt.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfCultAndArt.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfCultAndArt.DictLegalFormId);
            return View(listOfCultAndArt);
        }

        // GET: CultAndArt/ListOfCultAndArts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCultAndArt = await _context.ListOfCultAndArt
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictCultAndArtType)
                .Include(l => l.DictDistrict)
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCultAndArt == null)
            {
                return NotFound();
            }

            return View(listOfCultAndArt);
        }

        // POST: CultAndArt/ListOfCultAndArts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfCultAndArt = await _context.ListOfCultAndArt.FindAsync(id);
            _context.ListOfCultAndArt.Remove(listOfCultAndArt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfCultAndArtExists(int id)
        {
            return _context.ListOfCultAndArt.Any(e => e.Id == id);
        }
    }
}
