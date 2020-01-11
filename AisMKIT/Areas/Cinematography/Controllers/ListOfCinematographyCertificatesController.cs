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
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace AisMKIT.Areas.Cinematography.Controllers
{
    [Area("Cinematography")]
    [Authorize(Roles = "Администратор-Кинематография")]
    public class ListOfCinematographyCertificatesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListOfCinematographyCertificatesController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Cinematography/ListOfCinematographyCertificates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfCinematographyCertificates.Include(l => l.ApplicationUser).Include(l => l.DictCinemaAgeRestrictions).Include(l => l.DictCinemaDuration);

            var list = await applicationDbContext.ToListAsync();

            foreach (var item in list)
            {
                int id = item.Id;

                // страны
                item.CinemaCountries = _context.CinemaCountries
                    .Include(c => c.ListOfCinematographyCertificates)
                    .Where(c => c.ListOfCinematographyCertificatesId == id)
                    .Include(c => c.DictCountry)
                    .ToList();

                // режиссеры
                item.CinemaRegisers = _context.CinemaRegisers
                    .Include(c => c.ListOfCinematographyCertificates)
                    .Where(c => c.ListOfCinematographyCertificatesId == id)
                    .Include(c => c.DictCinemaRegiser)
                    .ToList();

            }


            return View(list);
        }

        // GET: Cinematography/ListOfCinematographyCertificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyCertificates = await _context.ListOfCinematographyCertificates
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictCinemaAgeRestrictions)
                //.Include(l => l.DictCountry)
                .Include(l => l.DictCinemaDuration)
                //.Include(l => l.DictCinemaRegiser)
                .FirstOrDefaultAsync(m => m.Id == id);

            // страны
            listOfCinematographyCertificates.CinemaCountries = _context.CinemaCountries
                .Include(c => c.ListOfCinematographyCertificates)
                .Where(c => c.ListOfCinematographyCertificatesId == id)
                .Include(c => c.DictCountry)
                .ToList();

            // режиссеры
            listOfCinematographyCertificates.CinemaRegisers = _context.CinemaRegisers
                .Include(c => c.ListOfCinematographyCertificates)
                .Where(c => c.ListOfCinematographyCertificatesId == id)
                .Include(c => c.DictCinemaRegiser)
                .ToList();

            if (listOfCinematographyCertificates == null)
            {
                return NotFound();
            }

            return View(listOfCinematographyCertificates);
        }

        // GET: Cinematography/ListOfCinematographyCertificates/Create
        //[Authorize]
        public IActionResult Create()
        {
            ViewData["DictCinemaAgeRestrictionsId"] = new SelectList(_context.DictCinemaAgeRestrictions, "Id", "Name");
            ViewData["DictCountryId"] = new SelectList(_context.DictCountry, "Id", "Name");
            ViewData["DictCinemaDurationId"] = new SelectList(_context.DictCinemaDuration, "Id", "Name");
            ViewData["DictCinemaRegiserId"] = new SelectList(_context.DictCinemaRegiser, "Id", "FullName");

            string uid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ListOfCinematographyCertificates model = new ListOfCinematographyCertificates();
            model.NameKyrg = "NULL";
            model.CreateDate = DateTime.Now;
            model.ApplicationUserId = uid;

            return View(model);
        }

        // POST: Cinematography/ListOfCinematographyCertificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameRus,NameKyrg,DictCountryId,Years,DictCinemaRegiserId,DictCinemaDurationId,DictCinemaAgeRestrictionsId,RegistrationDate,CreateDate,ApplicationUserId,CountriesRegisersJson")] ListOfCinematographyCertificates listOfCinematographyCertificates, string CountriesRegisersJson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfCinematographyCertificates);

                await _context.SaveChangesAsync();

                JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(CountriesRegisersJson);

                // страны
                foreach (int CountryId in jsonData.countries)
                {
                    CinemaCountries cinemaC = new CinemaCountries
                    {
                        DictCountryId = CountryId,
                        ListOfCinematographyCertificatesId = listOfCinematographyCertificates.Id
                    };

                    _context.Add(cinemaC);
                    await _context.SaveChangesAsync();

                }

                // режиссеры
                foreach (int RegiserId in jsonData.regisers)
                {
                    CinemaRegisers cinemaR = new CinemaRegisers
                    {
                        DictCinemaRegiserId = RegiserId,
                        ListOfCinematographyCertificatesId = listOfCinematographyCertificates.Id
                    };

                    _context.Add(cinemaR);
                    await _context.SaveChangesAsync();
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["DictCinemaAgeRestrictionsId"] = new SelectList(_context.DictCinemaAgeRestrictions, "Id", "Name", listOfCinematographyCertificates.DictCinemaAgeRestrictionsId);
            ViewData["DictCountryId"] = new SelectList(_context.DictCountry, "Id", "Name");
            ViewData["DictCinemaDurationId"] = new SelectList(_context.DictCinemaDuration, "Id", "Name", listOfCinematographyCertificates.DictCinemaDurationId);
            ViewData["DictCinemaRegiserId"] = new SelectList(_context.DictCinemaRegiser, "Id", "FullName");

            return View(listOfCinematographyCertificates);
        }

        // GET: Cinematography/ListOfCinematographyCertificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyCertificates = await _context.ListOfCinematographyCertificates.FindAsync(id);
            if (listOfCinematographyCertificates == null)
            {
                return NotFound();
            }

            // страны
            listOfCinematographyCertificates.CinemaCountries = _context.CinemaCountries
                .Include(c => c.ListOfCinematographyCertificates)
                .Where(c => c.ListOfCinematographyCertificatesId == id)
                .Include(c => c.DictCountry)
                .ToList();

            // режиссеры
            listOfCinematographyCertificates.CinemaRegisers = _context.CinemaRegisers
                .Include(c => c.ListOfCinematographyCertificates)
                .Where(c => c.ListOfCinematographyCertificatesId == id)
                .Include(c => c.DictCinemaRegiser)
                .ToList();

            // selectsLists for Countries
            List<SelectList> cinemaCountries = new List<SelectList>();
            foreach (var item in listOfCinematographyCertificates.CinemaCountries)
            {
                cinemaCountries.Add(new SelectList(_context.DictCountry, "Id", "Name", item.DictCountryId));
            }
            // selecLists for Regisers
            List<SelectList> cinemaRegisers = new List<SelectList>();
            foreach (var item in listOfCinematographyCertificates.CinemaRegisers)
            {
                cinemaRegisers.Add(new SelectList(_context.DictCinemaRegiser, "Id", "FullName", item.DictCinemaRegiserId));
            }

            ViewBag.CCLength = cinemaCountries.Count;
            ViewBag.CRLength = cinemaRegisers.Count;
            
            ViewBag.CinemaCountriesIds = cinemaCountries;
            ViewBag.CinemaRegisersIds = cinemaRegisers;

            ViewData["DictCinemaAgeRestrictionsId"] = new SelectList(_context.DictCinemaAgeRestrictions, "Id", "Name", listOfCinematographyCertificates.DictCinemaAgeRestrictionsId);
            ViewData["DictCountryId"] = new SelectList(_context.DictCountry, "Id", "Name");
            ViewData["DictCinemaDurationId"] = new SelectList(_context.DictCinemaDuration, "Id", "Name", listOfCinematographyCertificates.DictCinemaDurationId);
            ViewData["DictCinemaRegiserId"] = new SelectList(_context.DictCinemaRegiser, "Id", "FullName");


            return View(listOfCinematographyCertificates);
        }

        // POST: Cinematography/ListOfCinematographyCertificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameRus,NameKyrg,DictCountryId,Years,DictCinemaRegiserId,DictCinemaDurationId,DictCinemaAgeRestrictionsId,RegistrationDate,CreateDate,ApplicationUserId,CountriesRegisersJson")] ListOfCinematographyCertificates listOfCinematographyCertificates, string CountriesRegisersJson)
        {
            if (id != listOfCinematographyCertificates.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    listOfCinematographyCertificates.ApplicationUserId = uid;
                    _context.Update(listOfCinematographyCertificates);
                    await _context.SaveChangesAsync();

                    // для начала удалить старые данные
                    var listCinemaC = _context.CinemaCountries.Where(a => a.ListOfCinematographyCertificatesId == id).ToList();
                    foreach (var item in listCinemaC)
                    {
                        _context.CinemaCountries.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                    var listCinemaR = _context.CinemaRegisers.Where(a => a.ListOfCinematographyCertificatesId == id).ToList();
                    foreach (var item in listCinemaR)
                    {
                        _context.CinemaRegisers.Remove(item);
                        await _context.SaveChangesAsync();
                    }

                    JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(CountriesRegisersJson);

                    // страны
                    foreach (int CountryId in jsonData.countries)
                    {
                        CinemaCountries cinemaC = new CinemaCountries
                        {
                            DictCountryId = CountryId,
                            ListOfCinematographyCertificatesId = listOfCinematographyCertificates.Id
                        };

                        _context.Add(cinemaC);
                        await _context.SaveChangesAsync();

                    }

                    // режиссеры
                    foreach (int RegiserId in jsonData.regisers)
                    {
                        CinemaRegisers cinemaR = new CinemaRegisers
                        {
                            DictCinemaRegiserId = RegiserId,
                            ListOfCinematographyCertificatesId = listOfCinematographyCertificates.Id
                        };

                        _context.Add(cinemaR);
                        await _context.SaveChangesAsync();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfCinematographyCertificatesExists(listOfCinematographyCertificates.Id))
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


            // страны
            listOfCinematographyCertificates.CinemaCountries = _context.CinemaCountries
                .Include(c => c.ListOfCinematographyCertificates)
                .Where(c => c.ListOfCinematographyCertificatesId == id)
                .Include(c => c.DictCountry)
                .ToList();

            // режиссеры
            listOfCinematographyCertificates.CinemaRegisers = _context.CinemaRegisers
                .Include(c => c.ListOfCinematographyCertificates)
                .Where(c => c.ListOfCinematographyCertificatesId == id)
                .Include(c => c.DictCinemaRegiser)
                .ToList();

            // selectsLists for Countries
            List<SelectList> cinemaCountries = new List<SelectList>();
            foreach (var item in listOfCinematographyCertificates.CinemaCountries)
            {
                cinemaCountries.Add(new SelectList(_context.DictCountry, "Id", "Name", item.DictCountryId));
            }
            // selecLists for Regisers
            List<SelectList> cinemaRegisers = new List<SelectList>();
            foreach (var item in listOfCinematographyCertificates.CinemaRegisers)
            {
                cinemaRegisers.Add(new SelectList(_context.DictCinemaRegiser, "Id", "FullName", item.DictCinemaRegiserId));
            }

            ViewData["CinemaCountriesIds"] = cinemaCountries;
            ViewData["CinemaRegisersIds"] = cinemaRegisers;


            ViewData["DictCinemaAgeRestrictionsId"] = new SelectList(_context.DictCinemaAgeRestrictions, "Id", "Name", listOfCinematographyCertificates.DictCinemaAgeRestrictionsId);
            ViewData["DictCountryId"] = new SelectList(_context.DictCountry, "Id", "Name");
            ViewData["DictCinemaDurationId"] = new SelectList(_context.DictCinemaDuration, "Id", "Name", listOfCinematographyCertificates.DictCinemaDurationId);
            ViewData["DictCinemaRegiserId"] = new SelectList(_context.DictCinemaRegiser, "Id", "FullName");
            
            return View(listOfCinematographyCertificates);
        }

        // GET: Cinematography/ListOfCinematographyCertificates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematographyCertificates = await _context.ListOfCinematographyCertificates
                .Include(l => l.ApplicationUser)
                .Include(l => l.DictCinemaAgeRestrictions)
                //.Include(l => l.DictCountry)
                .Include(l => l.DictCinemaDuration)
                //.Include(l => l.DictCinemaRegiser)
                .FirstOrDefaultAsync(m => m.Id == id);

            // страны
            listOfCinematographyCertificates.CinemaCountries = _context.CinemaCountries
                .Include(c => c.ListOfCinematographyCertificates)
                .Where(c => c.ListOfCinematographyCertificatesId == id)
                .Include(c => c.DictCountry)
                .ToList();

            // режиссеры
            listOfCinematographyCertificates.CinemaRegisers = _context.CinemaRegisers
                .Include(c => c.ListOfCinematographyCertificates)
                .Where(c => c.ListOfCinematographyCertificatesId == id)
                .Include(c => c.DictCinemaRegiser)
                .ToList();


            if (listOfCinematographyCertificates == null)
            {
                return NotFound();
            }

            return View(listOfCinematographyCertificates);
        }

        // POST: Cinematography/ListOfCinematographyCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // страны
            var listCinemaC = _context.CinemaCountries.Where(a => a.ListOfCinematographyCertificatesId == id).ToList();
            foreach (var item in listCinemaC)
            {
                _context.CinemaCountries.Remove(item);
                await _context.SaveChangesAsync();
            }
            // режиссёры
            var listCinemaR = _context.CinemaRegisers.Where(a => a.ListOfCinematographyCertificatesId == id).ToList();
            foreach (var item in listCinemaR)
            {
                _context.CinemaRegisers.Remove(item);
                await _context.SaveChangesAsync();
            }

            var listOfCinematographyCertificates = await _context.ListOfCinematographyCertificates.FindAsync(id);
            _context.ListOfCinematographyCertificates.Remove(listOfCinematographyCertificates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfCinematographyCertificatesExists(int id)
        {
            return _context.ListOfCinematographyCertificates.Any(e => e.Id == id);
        }
    }
}
