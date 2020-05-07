using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB_PA.Controllers
{
    public class EventsController : Controller
    {
        [Authorize]
        public IActionResult Events()
        {
            return View();
        }
    }
}