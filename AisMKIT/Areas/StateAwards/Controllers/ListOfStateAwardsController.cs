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

namespace AisMKIT.Areas.StateAwards.Controllers
{
    [Area("StateAwards")]
    public class ListOfStateAwardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ListOfStateAwardsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }



        // GET: StateAwards/ListOfStateAwards
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfStateAwards.Include(l => l.ApplicationUser).Include(l => l.DictAwardsPosition).Include(l => l.DictAwardsReason).Include(l => l.DictStateAwardsType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StateAwards/ListOfStateAwards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfStateAwards = await _context.ListOfStateAwards
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictAwardsPosition)
                .Include(l => l.DictAwardsReason)
                .Include(l => l.DictStateAwardsType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfStateAwards == null)
            {
                return NotFound();
            }

            return View(listOfStateAwards);
        }

        // GET: StateAwards/ListOfStateAwards/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["DictAwardsPositionId"] = new SelectList(_context.DictAwardsPosition, "Id", "NameRus");
            ViewData["DictAwardsReasonId"] = new SelectList(_context.DictAwardsReason, "Id", "NameRus");
            ViewData["DictStateAwardsTypeId"] = new SelectList(_context.DictStateAwardsType, "Id", "NameRus");

            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ListOfStateAwards model = new ListOfStateAwards();
            model.CreateDate = DateTime.Now;
            model.ApplicationUserId = uid;

            return View(model);
        }

        // POST: StateAwards/ListOfStateAwards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastNameDirector,FirstNameDirector,PatronicNameDirector,DictStateAwardsTypeId,DictAwardsPositionId,DictAwardsReasonId,RegistrationDate,CreateDate,ApplicationUserId")] ListOfStateAwards listOfStateAwards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfStateAwards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictAwardsPositionId"] = new SelectList(_context.DictAwardsPosition, "Id", "NameRus", listOfStateAwards.DictAwardsPositionId);
            ViewData["DictAwardsReasonId"] = new SelectList(_context.DictAwardsReason, "Id", "NameRus", listOfStateAwards.DictAwardsReasonId);
            ViewData["DictStateAwardsTypeId"] = new SelectList(_context.DictStateAwardsType, "Id", "NameRus", listOfStateAwards.DictStateAwardsTypeId);
            return View(listOfStateAwards);
        }

        // GET: StateAwards/ListOfStateAwards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfStateAwards = await _context.ListOfStateAwards.FindAsync(id);
            if (listOfStateAwards == null)
            {
                return NotFound();
            }
            ViewData["DictAwardsPositionId"] = new SelectList(_context.DictAwardsPosition, "Id", "NameRus", listOfStateAwards.DictAwardsPositionId);
            ViewData["DictAwardsReasonId"] = new SelectList(_context.DictAwardsReason, "Id", "NameRus", listOfStateAwards.DictAwardsReasonId);
            ViewData["DictStateAwardsTypeId"] = new SelectList(_context.DictStateAwardsType, "Id", "NameRus", listOfStateAwards.DictStateAwardsTypeId);
            return View(listOfStateAwards);
        }

        // POST: StateAwards/ListOfStateAwards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastNameDirector,FirstNameDirector,PatronicNameDirector,DictStateAwardsTypeId,DictAwardsPositionId,DictAwardsReasonId,RegistrationDate,CreateDate,ApplicationUserId")] ListOfStateAwards listOfStateAwards)
        {
            if (id != listOfStateAwards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfStateAwards.ApplicationUserId = uid;
                    _context.Update(listOfStateAwards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfStateAwardsExists(listOfStateAwards.Id))
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
            ViewData["DictAwardsPositionId"] = new SelectList(_context.DictAwardsPosition, "Id", "NameRus", listOfStateAwards.DictAwardsPositionId);
            ViewData["DictAwardsReasonId"] = new SelectList(_context.DictAwardsReason, "Id", "NameRus", listOfStateAwards.DictAwardsReasonId);
            ViewData["DictStateAwardsTypeId"] = new SelectList(_context.DictStateAwardsType, "Id", "NameRus", listOfStateAwards.DictStateAwardsTypeId);
            return View(listOfStateAwards);
        }

        // GET: StateAwards/ListOfStateAwards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfStateAwards = await _context.ListOfStateAwards
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictAwardsPosition)
                .Include(l => l.DictAwardsReason)
                .Include(l => l.DictStateAwardsType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfStateAwards == null)
            {
                return NotFound();
            }

            return View(listOfStateAwards);
        }

        // POST: StateAwards/ListOfStateAwards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfStateAwards = await _context.ListOfStateAwards.FindAsync(id);
            _context.ListOfStateAwards.Remove(listOfStateAwards);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfStateAwardsExists(int id)
        {
            return _context.ListOfStateAwards.Any(e => e.Id == id);
        }
    }
}
