﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AisMKIT.Areas.Media.Controllers
{
    [Area("Media")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}