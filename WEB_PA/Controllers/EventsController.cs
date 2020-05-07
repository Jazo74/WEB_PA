using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB_PA.Models;
using WEB_PA.Domain;
using System.Security.Claims;

namespace WEB_PA.Controllers
{
    public class EventsController : Controller
    {
        IDataService ds = new DBService();

        [Authorize]
        public IActionResult Events()
        {
            string currentUser = "";
            currentUser = ds.GetNickname(HttpContext.User.FindFirstValue(ClaimTypes.Email));
            ViewData.Add("currentUser", currentUser);
            return View();
        }
    }
}