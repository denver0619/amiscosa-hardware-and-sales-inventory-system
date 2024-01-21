using amiscosa_hardware_and_sales_inventory_system.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using System.Text.Json;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;


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
            List<Product> productList = new List<Product>();
            foreach (ProductDataTransferObject product in transactionService.Model.ProductList!)
            {
                productList.Add(new Product(product));
            }
            List<Customer> customerList = transactionService.Model.CustomerList!;         

            var result = new
            {
                Products = productList,
                Customers = customerList
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult SendTransaction([FromBody] TransactionDataTransferObject transactionDataTransferObject)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Debug.WriteLine("Model state errors: " + string.Join(", ", errors));
                return BadRequest(ModelState);
            }

            Debug.WriteLine(1);
            Debug.WriteLine(JsonSerializer.Serialize(transactionDataTransferObject));
            Debug.WriteLine(2);
            TransactionDataTransferObject transaction = transactionDataTransferObject;
            transaction.TransactionData!.TransactionDate = DateTime.Now;

            TransactionService transactionService = new TransactionService();
            TransactionModel transactionModel = new TransactionModel();
            transactionModel.Transaction = transactionDataTransferObject.TransactionData;
            transactionModel.TransactionDetails = transactionDataTransferObject.TransactionDetails;

            transactionService.AddTransaction(transactionModel);
            transactionService.Dispose();

            return Ok();

            /*if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Debug.WriteLine("Model state errors: " + string.Join(", ", errors));
                return BadRequest(ModelState);
            }
            TransactionDataTransferObject transactionDTO = JsonSerializer.Deserialize<TransactionDataTransferObject>(transactionDataTransferObject)!;
            transactionDTO.TransactionData.TransactionDate = DateTime.Now;

            Debug.WriteLine(1);
            Debug.WriteLine(transactionDataTransferObject);
            Debug.WriteLine(2);

            TransactionService transactionService = new TransactionService();
            TransactionModel transactionModel = new TransactionModel();
            transactionModel.Transaction = transactionDTO.TransactionData;
            transactionModel.TransactionDetails = transactionDTO.TransactionDetails;

            transactionService.AddTransaction(transactionModel);
            transactionService.Dispose();

            return Ok();*/
        }

        public IActionResult Manufacturer()
        {
            ManufacturerService manufacturerService = new ManufacturerService();
            ManufacturerModel manufacturerModel = manufacturerService.Model;
            manufacturerService.Dispose();

            return View(manufacturerModel);
        }

        public IActionResult AddManufacturer([FromBody] Manufacturer manufacturerData)
        {
            ManufacturerService manufacturerService = new ManufacturerService();
            manufacturerService.AddManufacturer(manufacturerData);
            manufacturerService.Dispose();

            return Ok("Success");
        }

        public IActionResult EditManufacturer([FromBody] Manufacturer manufacturerData)
        {
            ManufacturerService manufacturerService = new ManufacturerService();
            manufacturerService.EditManufacturer(manufacturerData);
            manufacturerService.Dispose();

            return Ok("Success");
        }

        public IActionResult GetManufacturerList()
        {
            ManufacturerService manufacturerService = new ManufacturerService();
            List<Manufacturer> manufacturers = manufacturerService.Model.ManufacturerList!;

            manufacturerService.Dispose();

            return Ok(manufacturers);
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

        public IActionResult EditCustomer([FromBody] Customer customerData) {
            Debug.WriteLine(1);
            CustomerService customerService = new CustomerService();
            customerService.UpdateCustomer(customerData);
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
            DateTime dateTime = DateTime.Now;
            ReportService reportService = new ReportService(dateTime);
            ReportModel reportModel = reportService.Model;
            reportService.Dispose();

            return View(reportModel);
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
