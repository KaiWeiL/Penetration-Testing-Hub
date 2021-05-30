using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penetration_Testing_Hub.Controllers
{
    public class StageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ToolOrTech(String ThreadCategory)
        {
            ViewBag.ThreadCategory = ThreadCategory;
            return View("ToolOrTech");
        }
    }
}
