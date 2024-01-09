using amiscosa_hardware_and_sales_inventory_system.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using System.Text.Json;

namespace amiscosa_hardware_and_sales_inventory_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Inventory()
        {
            InventoryService inventoryService = new InventoryService();
            /*String JsonString = JsonSerializer.Serialize(inventoryService.Model);
            Debug.WriteLine(JsonString);*/
            InventoryModel inventoryModel = inventoryService.Model;
            inventoryService.Dispose();

            return View(inventoryModel);
        }

        public IActionResult InventoryPopulate()
        {
            return RedirectToAction("Index");
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
        public IActionResult Report()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
