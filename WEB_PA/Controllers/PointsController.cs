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
    public class PointsController : Controller
    {
        IDBService ds = new DBService();

        [Authorize]
        [HttpPost]
        public IActionResult MarkPoint([FromForm] int taskId, [FromForm] string pointName, [FromForm] string pointDescription, [FromForm] string mapLink)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            PointModel pointModel = new PointModel(taskId, pointName, pointDescription, currentUser, mapLink);
            return View("MarkPoint", pointModel);
        }

        [Authorize]
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/Tasks/ShowPoint/{tid}")]
        public IActionResult ShowPoint(int tid)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            Tassk task = ds.GetTask(tid);
            TaskModel taskModel = new TaskModel(task, ds.getMap(task.MapID), ds.GetPointsByTaskId(tid), currentUser);
            return View("Task", taskModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SavePoint([FromForm] int taskId, [FromForm] string pointName, [FromForm] string pointDescription, [FromForm] string coordX, [FromFormAttribute] string coordY)
        {
            string userID = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            string currentUser = ds.GetNickname(userID);
            ViewData.Add("currentUser", currentUser);
            float X = float.Parse(coordX.Replace(".",","));
            float Y = float.Parse(coordY.Replace(".", ","));

            ds.AddPoint(taskId, X, Y, pointName, pointDescription);
            return RedirectToAction("ShowTask", "Tasks", new { @tid = taskId });
        }
    }
}