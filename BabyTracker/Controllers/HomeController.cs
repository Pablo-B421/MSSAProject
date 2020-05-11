using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BabyTracker.Models;
using System.Text.Encodings.Web;

namespace BabyTracker.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult NewProfile()
        {
            return View();
        }
        public IActionResult Calendar()
        {
            return View();
        }
        public IActionResult DiaperTracker()
        {
            return View();
        }
        public IActionResult FeedingTracker()
        {
            return View();
        }

    }
}
