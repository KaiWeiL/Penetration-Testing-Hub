using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Penetration_Testing_Hub.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Penetration_Testing_Hub.Controllers
{
    public class DonateController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public DonateController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("~/Views/Donate/Index.cshtml");
        }

        public IActionResult ForMe(int CategoryId, string itemId, int quantity)
        {
            if (CategoryId < 0)
            {
                return View("~/Views/Donate/ForMe.cshtml");
            }
            else if (CategoryId == 1)
            {
                return View("~/Views/Donate/ForMeDrink.cshtml");
            }
            else if (CategoryId == 2)
            {
                return View("~/Views/Donate/ForMeFood.cshtml");
            }
            else
            {
                return View("~/Views/Donate/ForMe.cshtml");
            }

        }

        public IActionResult SupportCommunity(int CategoryId)
        {

            if (CategoryId < 0)
            {
                return View("~/Views/Donate/SupportCommunity.cshtml");
            }
            else if (CategoryId == 3)
            {
                return View("~/Views/Donate/SupportCommunityClothes.cshtml");
            }
            else if (CategoryId == 4)
            {
                return View("~/Views/Donate/SupportCommunityUtensils.cshtml");
            }
            else
            {
                return View("~/Views/Donate/SupportCommunity.cshtml");
            }
        }

        public IActionResult Cart()
        {
            return View("~/Views/Donate/Cart.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
