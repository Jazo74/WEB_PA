using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB_PA.Models;
using WEB_PA.Domain;
using System.Security.Claims;
using System.Security.Cryptography;

namespace WEB_PA.Controllers
{
    public class MapsController : Controller
    {
        IDBService ds = new DBService();

        //[Authorize]
        //[HttpGet]
        //public IActionResult GetMapsByEventId(int eventId)
        //{
        //    string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
        //    string currentUser = ds.GetNickname(userID);
        //    ViewData.Add("currentUser", currentUser);
        //    TasksModel tasks = new TasksModel(ds.GetTasksByEvent(eventId), currentUser);
        //    return View("Tasks", tasks);
        //}

        [Authorize]
        [HttpPost]
        public IActionResult AddMap([FromForm] int eventId, [FromForm] string mapName, [FromForm] string mapLink)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            ds.AddMap(mapLink, mapName, eventId);
            return RedirectToAction("ShowEvent", "Events", new { @eid = eventId });
        }

    }
}