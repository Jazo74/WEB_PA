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
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WEB_PA.Controllers
{
    public class TasksController : Controller
    {
        IDBService ds = new DBService();

        //[Authorize]
        //[HttpGet]
        //public IActionResult GetTasksByEventId(int eventId)
        //{
        //    string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
        //    string currentUser = ds.GetNickname(userID);
        //    ViewData.Add("currentUser", currentUser);
        //    TasksModel tasks = new TasksModel(ds.GetTasksByEvent(eventId), currentUser);
        //    return View("Tasks", tasks);
        //}

        [Authorize]
        [HttpPost]
        public IActionResult AddTask([FromForm] int eventId, [FromForm] string taskName, [FromForm] string taskDescription, [FromForm] int serialNumber, [FromForm] string mapNameAndId)
        {
            int start = mapNameAndId.IndexOf("#");
            int mapId =  Convert.ToInt32(mapNameAndId.Substring(start + 1));
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            ds.AddTask(eventId, serialNumber, taskName, taskDescription, mapId);
            return RedirectToAction("ShowEvent", "Events", new { @eid = eventId });
        }

        [Authorize]
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/Tasks/ShowTask/{tid}")]
        public IActionResult ShowTask(int tid)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            Tassk task = ds.GetTask(tid);
            TaskModel taskModel = new TaskModel(task, ds.getMap(task.MapID), ds.GetPointsByTaskId(tid), currentUser);
            return View("Task", taskModel);
        }

        [Authorize]
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/Tasks/DeleteTask/{tid}&{eid}")]
        public IActionResult DeleteTask(int tid, int eid)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            ds.DeleteTask(tid);
            return RedirectToAction("ShowEvent", "Events", new { @eid = eid });
        }

        [Authorize]
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/Tasks/UpdateTask/{tid}&{eid}&{mid}")]
        public IActionResult UpdateTask(int tid, int eid, int mid)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            TaskModel taskModel = new TaskModel(ds.GetTask(tid), ds.getMap(mid), ds.GetPointsByTaskId(tid), currentUser, ds.GetMapsByEventId(eid));
            return View("UpdateTask", taskModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SaveTask([FromForm] int taskId, [FromForm] string taskName, [FromForm] string taskDescription, [FromForm] int serialNumber, [FromForm] string mapNameAndId, [FromForm] int eid)
        {
            int start = mapNameAndId.IndexOf("#");
            int mapId = Convert.ToInt32(mapNameAndId.Substring(start + 1));
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            ds.UpdateTask(taskId, serialNumber, taskName, taskDescription, mapId);
            return RedirectToAction("ShowEvent", "Events", new { @eid = eid });
        }
    }
}