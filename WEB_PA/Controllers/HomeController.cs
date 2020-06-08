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
        IDBService ds = new DBService();

        public IActionResult Index()
        {
            string currentUser = "";
            currentUser = ds.GetNickname(HttpContext.User.FindFirstValue(ClaimTypes.Email));
            ViewData.Add("currentUser", currentUser);
            return View();
        }

        public IActionResult Privacy()
        {
            string currentUser = "";
            currentUser = ds.GetNickname(HttpContext.User.FindFirstValue(ClaimTypes.Email));
            ViewData.Add("currentUser", currentUser);
            return View();
        }

        public IActionResult AboutUs()
        {
            string currentUser = "";
            currentUser = ds.GetNickname(HttpContext.User.FindFirstValue(ClaimTypes.Email));
            ViewData.Add("currentUser", currentUser);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
