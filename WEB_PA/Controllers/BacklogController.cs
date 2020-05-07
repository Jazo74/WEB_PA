using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WEB_PA.Controllers
{
    public class BacklogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}