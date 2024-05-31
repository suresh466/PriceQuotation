using Microsoft.AspNetCore.Mvc;
using PriceQuotation.Models;
using System.Diagnostics;

namespace PriceQuotation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Total = 0;
            ViewBag.DiscountAmount = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(DiscountCalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.DiscountAmount = model.CalculateDiscountAmount();
                ViewBag.Total = model.CalculateTotal();
            }
            else
            {
                ViewBag.DiscountAmount = 0;
                ViewBag.Total = 0;
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
