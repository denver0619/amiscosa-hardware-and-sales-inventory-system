using amiscosa_hardware_and_sales_inventory_system.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace amiscosa_hardware_and_sales_inventory_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inventory()
        {
            return View();
        }
        public IActionResult Transaction()
        {
            return View();
        }

        public IActionResult TransactionHistory()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult AlertHistory()
        {
            return View();
        }
        public IActionResult Analytics()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
