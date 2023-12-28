using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface ITransactionRepository
    {
        public void AddTransaction (Transaction transaction);
        public void DeleteTransaction (Transaction transaction);
        public void UpdateTransaction (Transaction transaction);
        public Transaction GetTransactionByID (string id);
        public Transaction GetTransactionByDate (string date);
        public List<Transaction> GetAllTransactions ();
    }
}
