using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;
using System.Diagnostics;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class TransactionService : IDisposable
    {
        private CustomerRepository customerRepository;
        private ProductRepository productRepository;
        private TransactionRepository transactionRepository;
        private TransactionDetailRepository transactionDetailRepository;
        private ManufacturerRepository manufacturerRepository;

        public TransactionService()
        {
            customerRepository = new CustomerRepository();
            productRepository = new ProductRepository();    
            transactionRepository = new TransactionRepository();
            transactionDetailRepository = new TransactionDetailRepository();
            manufacturerRepository = new ManufacturerRepository();
            Model = new TransactionModel();
            Model = GetAllCustomerList();
            Model = GetAllProductList();
        }

        public TransactionModel Model { get; set; }

        public TransactionModel GetAllCustomerList()
        {
            Model.CustomerList = customerRepository.GetAllCustomers();
            return Model;
        }

        public TransactionModel GetAllProductList()
        {
            List<Product> products = productRepository.GetAllProducts();

            List<ProductDataTransferObject> productData = new List<ProductDataTransferObject>();

            foreach (Product product in products)
            {
                ProductDataTransferObject productDataTransferObject = new ProductDataTransferObject(product);
                productDataTransferObject.Manufacturer = manufacturerRepository.GetManufacturerByID(product.ManufacturerID!);
                productData.Add(productDataTransferObject);
            }
            Model.ProductList = productData;
            return Model;
        }

        public void AddTransaction(TransactionModel model)
        {
            Model.Transaction = model.Transaction;
            Model.TransactionDetails = model.TransactionDetails;
            transactionRepository.AddTransaction(Model.Transaction!);
            List<Transaction> transactions = transactionRepository.GetAllTransactions();
            Debug.WriteLine("Transaction Count: " + transactions.Count);
            Debug.WriteLine("Transaction Count index: " + (transactions.Count - 1));
            Transaction transaction = transactions[transactions.Count - 1];
            foreach (TransactionDetail transactionDetail in Model.TransactionDetails!)
            {
                Product product = new Product(productRepository.GetProductByID(transactionDetail.ProductID!));
                TransactionDetail transactionDetailData = new TransactionDetail(transactionDetail);
                transactionDetailData.TransactionID = transaction.TransactionID;
                product.Quantity -= transactionDetail.Quantity;
                productRepository.UpdateProduct(product);
                transactionDetailRepository.AddTransactionDetail(transactionDetailData);
            }
        }

        public void Dispose()
        {
            customerRepository.Dispose();
            productRepository.Dispose();
            transactionRepository.Dispose();
            transactionDetailRepository.Dispose();
            manufacturerRepository.Dispose();
        }
    }
}
