using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AisMKIT.Models;
using NLog;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;

namespace AisMKIT.Controllers
{
    [Authorize(Roles = "Администратор")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ApplicationDbContext _context;

        //Test
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;

            _context = context;
        }

        public IActionResult Index()
        {
            List<string> countries = new List<string> { "Кыргызстан", "Россия" };
            logger.Debug("Hello from Home Controller...");

            // отправка количество записей
            ViewBag.ListOfMedias = _context.ListOfMedia.ToList().Count;
            ViewBag.ListOfMonuments = _context.ListOfMonuments.ToList().Count;
            ViewBag.ListOfCinematographies = _context.ListOfCinematography.ToList().Count;
            ViewBag.ListOfTheatricals = _context.ListOfTheatrical.ToList().Count;
            
            ViewBag.ListOfEduInstituts = _context.ListOfEduInstituts.ToList().Count;
            ViewBag.ListOfTourism = _context.ListOfTourism.ToList().Count;
            ViewBag.ListOfLibraryIndicators = _context.ListOfLibraryIndicators.ToList().Count;
            ViewBag.ListOfCultAndArts = _context.ListOfCultAndArt.ToList().Count;
            
            ViewBag.ListOfRents = _context.ListOfRents.ToList().Count;
            ViewBag.ListOfStateAwards = _context.ListOfStateAwards.ToList().Count;
            ViewBag.ListOfMonumentsProtObjects = _context.ListOfMonumentsProtObjects.ToList().Count;

            return View(countries);
        }

        public IActionResult AdminPanel()
        {
            
            return View();
        }
        public IActionResult Privacy()
        {
            logger.Debug("Hello from Privacy Controller...");
            return View();
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string GetCulture(string code = "")
        {
            if (!String.IsNullOrEmpty(code))
            {
                CultureInfo.CurrentCulture = new CultureInfo(code);
                CultureInfo.CurrentUICulture = new CultureInfo(code);
            }
            return $"CurrentCulture:{CultureInfo.CurrentCulture.Name}, CurrentUICulture:{CultureInfo.CurrentUICulture.Name}";
        }
    }
}
