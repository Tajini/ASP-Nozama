using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nozama2.Models;

namespace Nozama.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to Nozama !";
            return View();
        }

        public IActionResult Categories()
        {
            ViewData["Message"] = "Les différentes catégories d'articles dans notre magasin.";

            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
