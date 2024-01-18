using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class TransactionHistoryService : IDisposable
    {
        TransactionRepository transactionRepository;
        public TransactionHistoryService()
        {
            transactionRepository = new TransactionRepository();
            Model = new TransactionHistoryModel();
            Model = GetAllTransaction();
        }
        public TransactionHistoryModel Model { get; set; }

        public TransactionHistoryModel GetAllTransaction()
        {
            Model.TransactionList = transactionRepository.GetAllTransactions().OrderByDescending(transaction=>transaction.TransactionID).ToList();
            return Model;
        }

        public void Dispose()
        {
            transactionRepository.Dispose();
        }

    }
}
