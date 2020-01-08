using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IsadMholt.Models;

namespace IsadMholt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Admin()
        {
            Response.Cookies.Append("user", "Admin");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("user");
            ViewBag.LoggingOut = true;
            return View("Login");
        }

        public IActionResult SetAdminCookie()
        {
            Response.Cookies.Append("user", "Admin");
            return View("Index");
        }

        public IActionResult SetuserCookie(String uID)
        {
            Response.Cookies.Append("user", uID);
            return View("Index");
        }
    }
}
