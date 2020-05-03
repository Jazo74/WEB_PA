using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_PA;
using WEB_PA.Domain;
using WEB_PA.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WEB_PA.Controllers
{
    [Microsoft.AspNetCore.Components.Route("")]
    public class UserController : Controller 
    { 
        public static string focusQid = "";
        IDataService ds = new DBService();

        [Authorize]
        [HttpGet]
        public IActionResult user()
        {
            string currentUser = ds.GetUserId(HttpContext.User.FindFirstValue(ClaimTypes.Email));
            ViewData.Add("currentUser", currentUser);
            QAC qac = ds.GetQACByUserId(currentUser);
            return View("user", qac);
        }
    }
}