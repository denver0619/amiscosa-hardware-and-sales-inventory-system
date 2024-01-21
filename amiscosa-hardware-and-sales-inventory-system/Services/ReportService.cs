using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;
using System;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    /// <summary>
    /// A service class responsible for generating reports based on transactions and products.
    /// Implements the <see cref="IDisposable"/> interface to handle resource cleanup.
    /// </summary>
    public class ReportService : IDisposable
    {
        
        private TransactionRepository transactionRepository;
        private TransactionDetailRepository transactionDetailRepository;
        private ProductRepository productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportService"/> class.
        /// Creates instances of repositories and initializes the report model with product-related data.
        /// </summary>
        /// <param name="dateTime">The date and time for which the report is generated.</param
        public ReportService (DateTime dateTime)
        {
            transactionRepository = new TransactionRepository ();
            transactionDetailRepository = new TransactionDetailRepository ();
            productRepository = new ProductRepository ();
            Model = new ReportModel();
            Model = GetAllProductList(dateTime);
            GetAllStats (dateTime);
 
        }

        /// <summary>
        /// Gets or sets the report model associated with the service.
        /// </summary>
        public ReportModel Model { get; set; }

        /// <summary>
        /// Disposes of the resources used by the report service, including associated repositories.
        /// </summary>
        public void Dispose()
        {
            transactionDetailRepository.Dispose ();
            productRepository.Dispose ();
            transactionRepository.Dispose ();
        }

        /// <summary>
        /// Retrieves a report model containing product-related data for the specified date and time.
        /// </summary>
        /// <param name="dateTime">The date and time for which the report is generated.</param>
        /// <returns>The report model with product-related data.</returns>
        public ReportModel GetAllProductList(DateTime datetime)
        {
            List<Transaction> transactions = transactionRepository.GetAllTransactionByYearMonth(datetime);
            List<ProductSoldDataTransferObject> productSolds = new List<ProductSoldDataTransferObject>();
            Model.ProductTally = new Dictionary<string, int> ();

            for (int i = 0; i < transactions.Count; i++)
            {
                List<TransactionDetail> transactiondetails = transactionDetailRepository.GetAllTransactionDetailByTransactionID(transactions[i].TransactionID!);
                if (transactiondetails != null)
                {
                    for (int j = 0; j < transactiondetails.Count; j++)
                    {
                        if ( Model.ProductTally!.ContainsKey(transactiondetails[j].ProductID!))
                        {
                            Model.ProductTally[transactiondetails[j].ProductID!] = Model.ProductTally[transactiondetails[j].ProductID!] + transactiondetails[j].Quantity;
                        }
                        else
                        {
                            Model.ProductTally.Add(transactiondetails[j].ProductID!, transactiondetails[j].Quantity);
                        }
                    }
                }
             
            }

            List<string> productIDs = Model.ProductTally!.Keys.ToList();

            for (int i = 0; i < Model.ProductTally!.Count; i++)
            {
                ProductSoldDataTransferObject productsold = new ProductSoldDataTransferObject(productRepository.GetProductByID(productIDs[i]));
                productsold.ProductSold = Model.ProductTally[productIDs[i]];
                productsold.ProductSales = productsold.ProductSold * productsold.UnitPrice;
                productSolds.Add(productsold);
            }

            Model.ProductList = productSolds.OrderByDescending(product => product.ProductSold).ToList();
            return Model;           
        }

        /// <summary>
        /// Retrieves a report model containing statistics for the specified date and time.
        /// </summary>
        /// <param name="dateTime">The date and time for which the report is generated.</param>
        /// <returns>The report model with statistics.</returns>
        public ReportModel GetAllStats(DateTime dateTime)
        {

            double totalCost = 0;
            
            foreach (ProductSoldDataTransferObject product in Model.ProductList!)
            {
                Model.TotalRevenue += product.ProductSales;
                Model.NumberOfProductsSold += product.ProductSold;
                totalCost +=  Model.ProductTally![product.ProductID!]*product.UnitCost;
            }
            
            Model.TotalProfit = Model.TotalRevenue - totalCost;
            
            List<Transaction> transactions = transactionRepository.GetAllTransactionByYearMonth(dateTime);
            Model.NumberOfTransactionsDone = transactions.Count;
            return Model;
        }
    }
}
