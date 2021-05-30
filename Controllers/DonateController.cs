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
using Stripe.Checkout;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Penetration_Testing_Hub.Controllers
{
    public class DonateController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        IConfiguration _iconfiguration;
        PTHDbContext _context;

        public DonateController(ILogger<HomeController> logger, IConfiguration iconfiguration,
            PTHDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _iconfiguration = iconfiguration;
            _context = context;
            _userManager = userManager;
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

        //[ValidateAntiForgeryToken]
        public IActionResult Payment() {
            ViewBag.PublicKey = _iconfiguration.GetSection("Stripe")["PublishableKey"];
            return View("~/Views/Donate/Payment.cshtml");
        }

        [HttpPost]
        public IActionResult ProcessPayment() {

            var order = HttpContext.Session.GetObject<Models.Order>("order");

            StripeConfiguration.ApiKey = _iconfiguration.GetSection("Stripe")["SecretKey"];

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                  "card",
                },
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                      UnitAmount = (long?)order.Total * 100,
                      Currency = "cad",
                      ProductData = new SessionLineItemPriceDataProductDataOptions
                      {
                        Name = "PTH Donate",
                      },
                    },
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = "https://" + Request.Host + "/Donate/SaveOrder",
                CancelUrl = "https://" + Request.Host + "/Donate/Cart"
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return Json(new { id = session.Id });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("FirstName,LastName,Address,City,Province,PostalCode,Phone,Email")] Models.Order order, string Total)
        {
            order.CustomerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.OrderDate = DateTime.Now;
            order.Total = int.Parse(Total);
            //if (ModelState.IsValid)
            //{
                //HttpContext.Session.SetObject("order", order);
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Payment));
            //}
            //return View(order);

        }
        public IActionResult SaveOrder()
        {
            var order = HttpContext.Session.GetObject<Models.Order>("order");
            _context.Orders.Add(order);
            _context.SaveChanges();
            //if ( _context.SaveChanges() > 0)
            //{
            //    ViewBag.isPaymentSuccess = "true";
            //}
            //else
            //{
            //    ViewBag.isPaymentSuccess = "false";
            //}
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
