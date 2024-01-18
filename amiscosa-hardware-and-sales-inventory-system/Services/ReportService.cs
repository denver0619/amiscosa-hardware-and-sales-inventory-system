using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;
using System;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class ReportService : IDisposable
    {
        //Declaration of all the repositories needed
        private TransactionRepository transactionRepository;
        private TransactionDetailRepository transactionDetailRepository;
        private ProductRepository productRepository;
        
        public ReportService (DateTime dateTime)
        {
            transactionRepository = new TransactionRepository ();
            transactionDetailRepository = new TransactionDetailRepository ();
            productRepository = new ProductRepository ();
            Model = new ReportModel();
            Model = GetAllProductList(dateTime);
            GetAllStats (dateTime);
 
        }

        public ReportModel Model { get; set; } //required; Data na makikita sa UI. Pinapasa sa controller papuntang views.

        public void Dispose()
        {
            transactionDetailRepository.Dispose ();
            productRepository.Dispose ();
            transactionRepository.Dispose ();
        }

        public ReportModel GetAllProductList(DateTime datetime)
        {
            List<Transaction> transactions = transactionRepository.GetAllTransactionByYearMonth(datetime);// get the list of transaction in the specified date
            List<ProductSoldDataTransferObject> productSolds = new List<ProductSoldDataTransferObject>();//

            for (int i = 0; i < transactions.Count; i++)
            {
                List<TransactionDetail> transactiondetails = transactionDetailRepository.GetAllTransactionDetailByTransactionID(transactions[i].TransactionID!);
                for (int j = 0; j < transactiondetails.Count; j++)//list of product and quantity bought
                {
                    if (Model.ProductTally!.ContainsKey(transactiondetails[j].ProductID!))//if the product id is in the tally, iaadd lang
                    {
                        Model.ProductTally[transactiondetails[j].ProductID!] = Model.ProductTally[transactiondetails[j].ProductID!] + transactiondetails[j].Quantity;
                    }
                    else// if not, append the product the id and the quantity
                    {
                        Model.ProductTally.Add(transactiondetails[j].ProductID!, transactiondetails[j].Quantity);
                    }
                }
             
            }

            List<string> productIDs = Model.ProductTally!.Keys.ToList();

            for (int i = 0; i < Model.ProductTally!.Count; i++)// loop sa keys(productID within the Tally). To compute the sales for each product
            {
                ProductSoldDataTransferObject productsold = new ProductSoldDataTransferObject(productRepository.GetProductByID(productIDs[i]));
                productsold.ProductSold = Model.ProductTally[productIDs[i]];
                productsold.ProductSales = productsold.ProductSold * productsold.UnitPrice;
                productSolds.Add(productsold);//append ung mga product into list
            }

            Model.ProductList = productSolds;
            return Model;           
        }

        public ReportModel GetAllStats(DateTime dateTime)
        {

            double totalCost = 0;
            //get the cost and revenue and total of all products sold
            foreach (ProductSoldDataTransferObject product in Model.ProductList!)
            {
                Model.TotalRevenue += product.ProductSales;
                Model.NumberOfProductsSold += product.ProductSold;
                totalCost += product.UnitCost;
            }
            //get the profit
            Model.TotalProfit = Model.TotalRevenue - totalCost;
            //get the total number of transaction
            List<Transaction> transactions = transactionRepository.GetAllTransactionByYearMonth(dateTime);
            Model.NumberOfTransactionsDone = transactions.Count;
            return Model;
        }
    }
}
