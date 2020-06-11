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
    public class EventsController : Controller
    {
        IDBService ds = new DBService();

        [Authorize]
        [HttpGet]
        public IActionResult GetEvents()
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            EventsModel events = new EventsModel(ds.GetEventsByUser(userID), currentUser);
            return View("Events", events);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddEvent([FromForm] string eventName, [FromForm] string description, [FromForm] string address, [FromForm] string gpsCoord, [FromForm] string date, [FromForm] string time)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            string datetime = date + " " + time;
            ds.AddEvent(userID, eventName, address, gpsCoord, description, Convert.ToDateTime(datetime));
            return RedirectToAction("GetEvents", "Events");
        }

        [Authorize]
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/Events/ShowEvent/{eid}")]
        public IActionResult ShowEvent(int eid)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            EventModel eventModel = new EventModel(ds.GetEvent(eid), ds.GetTasksByEvent(eid), ds.GetMapsByEventId(eid), currentUser);
            return View("Event", eventModel);
        }

        [Authorize]
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/Events/DeleteEvent/{eid}")]
        public IActionResult DeleteEvent(int eid)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            ds.DeleteEvent(eid);
            EventsModel events = new EventsModel(ds.GetEventsByUser(userID), currentUser);
            return View("Events", events);
        }

        [Authorize]
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/Events/UpdateEvent/{eid}")]
        public IActionResult UpdateEvent(int eid)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            EventModel eventModel = new EventModel(ds.GetEvent(eid), ds.GetTasksByEvent(eid), ds.GetMapsByEventId(eid), currentUser);
            return View("UpdateEvent", eventModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SaveEvent([FromForm] int eventId, [FromForm] string eventName, [FromForm] string description, [FromForm] string address, [FromForm] string gpsCoord, [FromForm] string date, [FromForm] string time)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            string datetime = date + " " + time;
            ds.UpdateEvent(eventId, eventName, address, gpsCoord, description, Convert.ToDateTime(datetime));
            return RedirectToAction("GetEvents", "Events");
        }
    }
}