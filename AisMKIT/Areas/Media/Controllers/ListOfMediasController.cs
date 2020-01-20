using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;
using AisMKIT.Areas.Media.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AisMKIT.Areas.Media.Controllers
{
    [Area("Media")]
    public class ListOfMediasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListOfMediasController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> History(int id=0)
        {
            ListOfMedia lm = _context.ListOfMedia.Find(id);
            ViewBag.SMI = lm.NameRus + " - история перерегистрации";
            var applicationDbContext = _context.ListOfMediaHistory.Where(x=>x.ListOfMediaId==id).Include(l => l.DictFinSource).Include(l => l.DictLegalForm).Include(l => l.DictMediaFreqRelease).Include(l => l.DictMediaLangType).Include(l => l.DictMediaType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Media/ListOfMedias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfMedia.Include(l => l.DictFinSource).Include(l => l.DictLegalForm).Include(l => l.DictMediaFreqRelease).Include(l => l.DictMediaLangType).Include(l => l.DictMediaType);
            return View(await applicationDbContext.ToListAsync());
        }

        #region Reports
        public async Task<IActionResult> PermissionsMedia()
        {
            var q = from l in _context.ListOfMedia
                    join lf in _context.DictLegalForm on l.DictLegalFormId equals lf.Id
                    join mt in _context.DictMediaType on l.DictMediaTypeId equals mt.Id
                    join ltr in _context.ListOfTeleRadio on l.Id equals ltr.ListOfMediaId
                    join ag in _context.DictAgencyPerm on ltr.DictAgencyPermId equals ag.Id
                    join lcm in _context.ListOfControlMedia on l.Id equals lcm.ListOfMediaId into gj
                    from subpet in gj.Where(lcm => lcm.WarningDate != null & lcm.WarningRemovalDate == null & lcm.AnulmentDate == null).DefaultIfEmpty()
                    where mt.Id > 2 & l.EliminationDate == null //& gj.AnulmentDate==null & lcm.WarningEndDate!=null
                    select new
                    {
                        Name = l.NameRus,
                        LegalForm = lf.NameRus,
                        INN = l.INN,
                        RegisterDate = l.RegistrationDate,
                        MediaType = mt.NameRus,
                        PermisionNo = ltr.NumberOfPermission,
                        PermisionDate = ltr.PermissionDate,
                        DepPermGive = ag.NameRus,
                        WarningDate = subpet.WarningDate == null ? null : subpet.WarningDate,
                        WarningEndDate = subpet.WarningEndDate == null ? null : subpet.WarningEndDate
                        //WarningEndDate = subpet.WarningEndDate

                    };
            List<PermissionMediaModel> lst = new List<PermissionMediaModel>();
            //  var qq = await q ;
            int id = 1;
            foreach (var item in await q.ToListAsync())
            {
                lst.Add(new PermissionMediaModel { DepPermGive = item.DepPermGive, INN = item.INN, LegalForm = item.LegalForm, MediaType = item.MediaType, Name = item.Name, PermissionDate = item.PermisionDate, PermissionNo = item.PermisionNo, RegisterDate = item.RegisterDate, WarningEndDate = item.WarningEndDate, WarningDate = item.WarningDate });
                id++;
            }
            return View(lst);
        }

        public async Task<IActionResult> PermissionsDepartment()
        {
            //l.DictFinSourceId==1 & l.EliminationDate == null
            var q = from l in _context.ListOfMedia
                    join lf in _context.DictLegalForm on l.DictLegalFormId equals lf.Id
                    join mt in _context.DictMediaType on l.DictMediaTypeId equals mt.Id
                    join ltr in _context.ListOfTeleRadio on l.Id equals ltr.ListOfMediaId
                    join ag in _context.DictAgencyPerm on ltr.DictAgencyPermId equals ag.Id
                    //join lcm in _context.ListOfControlMedia on l.Id equals lcm.ListOfMediaId into gj
                    //from subpet in gj.Where(lcm => lcm.WarningDate != null & lcm.WarningRemovalDate == null & lcm.AnulmentDate == null).DefaultIfEmpty()
                    where l.DictFinSourceId == 1 & l.EliminationDate == null //& gj.AnulmentDate==null & lcm.WarningEndDate!=null
                    select new
                    {
                        Name = l.NameRus,
                        LegalForm = lf.NameRus,
                        INN = l.INN,
                        RegisterDate = l.RegistrationDate,
                        MediaType = mt.NameRus,
                        PermisionNo = ltr.NumberOfPermission,
                        PermisionDate = ltr.PermissionDate,
                        DepPermGive = ag.NameRus,
                        WarningDate = " ",// subpet.WarningDate == null ? null : subpet.WarningDate,
                        WarningEndDate = " " //subpet.WarningEndDate == null ? null : subpet.WarningEndDate
                        //WarningEndDate = subpet.WarningEndDate

                    };
            List<PermissionMediaModel> lst = new List<PermissionMediaModel>();
            //  var qq = await q ;
            int id = 1;
            foreach (var item in await q.ToListAsync())
            {
                //lst.Add(new PermissionMediaModel { DepPermGive = item.DepPermGive, INN = item.INN, LegalForm = item.LegalForm, MediaType = item.MediaType, Name = item.Name, PermissionDate = item.PermisionDate, PermissionNo = item.PermisionNo, RegisterDate = item.RegisterDate, WarningEndDate = item.WarningEndDate, WarningDate = item.WarningDate });
                lst.Add(new PermissionMediaModel { DepPermGive = item.DepPermGive, INN = item.INN, LegalForm = item.LegalForm, MediaType = item.MediaType, Name = item.Name, PermissionDate = item.PermisionDate, PermissionNo = item.PermisionNo, RegisterDate = item.RegisterDate, WarningEndDate = null, WarningDate = null });
                id++;
            }
            return View(lst);
        }


        #endregion


        #region CRUD

        // GET: Media/ListOfMedias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMedia = await _context.ListOfMedia
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .Include(l => l.DictMediaFreqRelease)
                .Include(l => l.DictMediaLangType)
                .Include(l => l.DictMediaType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (listOfMedia == null)
            {
                return NotFound();
            }

            return View(listOfMedia);
        }

        // GET: Media/ListOfMedias/Create
        public IActionResult Create()
        {
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus");
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus");
            ViewData["DictMediaFreqReleaseId"] = new SelectList(_context.DictMediaFreqRelease, "Id", "NameRus");
            ViewData["DictMediaLangTypeId"] = new SelectList(_context.DictMediaLangType, "Id", "NameRus");
            ViewData["DictMediaTypeId"] = new SelectList(_context.DictMediaType, "Id", "NameRus");

            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ListOfMedia model = new ListOfMedia();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            model.AddressKyrg = "NULL";
            model.ApplicationUserId = uid;


            return View(model);
        }

        // POST: Media/ListOfMedias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameRus,NameKyrg,DictLegalFormId,INN,RegistrationDate,Name,Territoryy,DictMediaLangTypeId,DictMediaTypeId,AddressRus,AddressKyrg,DictMediaFreqReleaseId,DictFinSourceId,ReregistrationDate,EliminationDate,CreateDate,ApplicationUserId")] ListOfMedia listOfMedia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfMedia);
                await _context.SaveChangesAsync();
                HistoryInsert(listOfMedia);
                return RedirectToAction(nameof(Index));
            }

            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfMedia.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfMedia.DictLegalFormId);
            ViewData["DictMediaFreqReleaseId"] = new SelectList(_context.DictMediaFreqRelease, "Id", "NameRus", listOfMedia.DictMediaFreqReleaseId);
            ViewData["DictMediaLangTypeId"] = new SelectList(_context.DictMediaLangType, "Id", "NameRus", listOfMedia.DictMediaLangTypeId);
            ViewData["DictMediaTypeId"] = new SelectList(_context.DictMediaType, "Id", "NameRus", listOfMedia.DictMediaTypeId);
            
            return View(listOfMedia);
        }

        // GET: Media/ListOfMedias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMedia = await _context.ListOfMedia.FindAsync(id);
            if (listOfMedia == null)
            {
                return NotFound();
            }
            
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfMedia.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfMedia.DictLegalFormId);
            ViewData["DictMediaFreqReleaseId"] = new SelectList(_context.DictMediaFreqRelease, "Id", "NameRus", listOfMedia.DictMediaFreqReleaseId);
            ViewData["DictMediaLangTypeId"] = new SelectList(_context.DictMediaLangType, "Id", "NameRus", listOfMedia.DictMediaLangTypeId);
            ViewData["DictMediaTypeId"] = new SelectList(_context.DictMediaType, "Id", "NameRus", listOfMedia.DictMediaTypeId);
            
            return View(listOfMedia);
        }

        // POST: Media/ListOfMedias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameRus,NameKyrg,DictLegalFormId,INN,RegistrationDate,Name,Territoryy,DictMediaLangTypeId,DictMediaTypeId,AddressRus,AddressKyrg,DictMediaFreqReleaseId,DictFinSourceId,ReregistrationDate,EliminationDate,CreateDate, ApplicationUserId")] ListOfMedia listOfMedia, string SubmitButton="")
        {
            if (id != listOfMedia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfMedia.ApplicationUserId = uid;

                    if (SubmitButton == "Перерегистрация")
                    {
                        HistoryInsert(listOfMedia);

                    }
                    _context.Update(listOfMedia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfMediaExists(listOfMedia.Id))
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
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfMedia.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfMedia.DictLegalFormId);
            ViewData["DictMediaFreqReleaseId"] = new SelectList(_context.DictMediaFreqRelease, "Id", "NameRus", listOfMedia.DictMediaFreqReleaseId);
            ViewData["DictMediaLangTypeId"] = new SelectList(_context.DictMediaLangType, "Id", "NameRus", listOfMedia.DictMediaLangTypeId);
            ViewData["DictMediaTypeId"] = new SelectList(_context.DictMediaType, "Id", "NameRus", listOfMedia.DictMediaTypeId);
            return View(listOfMedia);
        }

        private void HistoryInsert(ListOfMedia listOfMedia)
        {
            ListOfMediaHistory lh = new ListOfMediaHistory();
            lh.AddressKyrg = listOfMedia.AddressKyrg;
            lh.AddressRus = listOfMedia.AddressRus;
            lh.CreateDate = DateTime.Now;
            lh.DictMediaFinSourceId = listOfMedia.DictFinSourceId;
            lh.DictMediaFreqReleaseId = listOfMedia.DictMediaFreqReleaseId;
            lh.DictMediaLangTypeId = listOfMedia.DictMediaLangTypeId;
            lh.DictMediaTypeId = listOfMedia.DictMediaTypeId;
            lh.EliminationDate = listOfMedia.EliminationDate;
            lh.INN = listOfMedia.INN;
            lh.ListOfMediaId = listOfMedia.Id;
            lh.Name = listOfMedia.Name;
            lh.NameKyrg = listOfMedia.NameKyrg;
            lh.NameRus = listOfMedia.NameRus;
            lh.RegistrationDate = listOfMedia.RegistrationDate;
            lh.ReregistrationDate = listOfMedia.ReregistrationDate;
            lh.Territoryy = listOfMedia.Territoryy;
            _context.ListOfMediaHistory.Add(lh);
            _context.SaveChanges();
        }

        // GET: Media/ListOfMedias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMedia = await _context.ListOfMedia
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .Include(l => l.DictMediaFreqRelease)
                .Include(l => l.DictMediaLangType)
                .Include(l => l.DictMediaType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfMedia == null)
            {
                return NotFound();
            }

            return View(listOfMedia);
        }

        // POST: Media/ListOfMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfMedia = await _context.ListOfMedia.FindAsync(id);
            _context.ListOfMedia.Remove(listOfMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfMediaExists(int id)
        {
            return _context.ListOfMedia.Any(e => e.Id == id);
        }
        
        #endregion

    }
}
