using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Penetration_Testing_Hub.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Stripe;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Penetration_Testing_Hub.Data;

namespace Penetration_Testing_Hub.Controllers
{
    public class DonateController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IConfiguration _iconfiguration;
        PTHDbContext _context;

        public DonateController(ILogger<HomeController> logger, IConfiguration iconfiguration, PTHDbContext context)
        {
            _logger = logger;
            _iconfiguration = iconfiguration;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.isPaymentSuccess = TempData["isPaymentSuccess"];
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

        public IActionResult CheckOut() {

            return View();
        }

        public IActionResult Payment() {
            //var order = HttpContext.Session.GetObject<Models.Order>("Order");
            //ViewBag.Total = order.Total;
            ViewBag.PublicKey = _iconfiguration.GetSection("Stripe")["PublishableKey"];
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,FirstName,LastName,Address,City,Province,PostalCode,Phone,Email,Total")] Models.Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                order.OrderDate = DateTime.Now;
                if (await _context.SaveChangesAsync() > 0)
                {
                    TempData["isPaymentSuccess"] = "true";
                }
                else {
                    TempData["isPaymentSuccess"] = "false";
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
