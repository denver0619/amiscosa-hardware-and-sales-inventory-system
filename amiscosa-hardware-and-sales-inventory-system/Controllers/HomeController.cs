using amiscosa_hardware_and_sales_inventory_system.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using System.Text.Json;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;


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
            InventoryModel inventoryModel = inventoryService.Model;
            inventoryService.Dispose();

            return View(inventoryModel);
        }

        [HttpPost]
        public IActionResult AddInventoryProduct([FromBody] Product productData)
        {

            InventoryService inventoryService = new InventoryService();
            inventoryService.AddProduct(productData);
            inventoryService.Dispose();

            return Ok("Success");
        }

        [HttpPost]
        public IActionResult EditInventoryProduct([FromBody] Product productData)
        {

            InventoryService inventoryService = new InventoryService();
            inventoryService.EditProduct(productData);
            inventoryService.Dispose();


            return Ok("Success");
        }

        [HttpPost]
        public IActionResult DeleteProduct([FromBody] Product productData)
        {

            InventoryService inventoryService = new InventoryService();
            inventoryService.RemoveProduct(productData);
            inventoryService.Dispose();


            return Ok("Success");
        }

        public IActionResult Transaction()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTransactionDataList()
        {
            TransactionService transactionService = new TransactionService();
            List<Product> productList = transactionService.Model.ProductList!;
            List<Customer> customerList = transactionService.Model.CustomerList!;         

            var result = new
            {
                Products = productList,
                Customers = customerList
            };

            

            return Ok(result);
        }

        public IActionResult TransactionHistory()
        {
            return View();
        }

        public IActionResult Customer()
        {

            CustomerService customerService = new CustomerService();
            CustomerModel customerModel = customerService.Model;
            customerService.Dispose();

            return View(customerModel);
        }

        public IActionResult AddCustomer([FromBody] Customer customerData) {
            CustomerService customerService = new CustomerService();
            customerService.AddCustomer(customerData);
            customerService.Dispose();

            return Ok("Success");
        }

        public IActionResult AlertHistory()
        {
            NotificationService notificationService = new NotificationService();
            NotificationModel notificationModel = notificationService.Model;
            notificationService.Dispose();


            return View(notificationModel);
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
