using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AisMKIT.Areas.Library.Controllers
{
    [Area("Library")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}