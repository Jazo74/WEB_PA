using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEB_PA.Models;
using WEB_PA.Domain;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WEB_PA.Controllers
{
    public class HomeController : Controller
    {
        IDataService ds = new DBService();

        public IActionResult Index()
        {
            string currentUser = "";
            currentUser = ds.GetUserId(HttpContext.User.FindFirstValue(ClaimTypes.Email));
            ViewData.Add("currentUser", currentUser);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [Authorize]
        public IActionResult Theeye()
        {
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            ViewData.Add("email", email);
            return View("devspage");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
