using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface ITransactionRepository
    {
        public void AddTransaction (ITransaction transaction);
        public void DeleteTransaction (ITransaction transaction);
        public void UpdateTransaction (ITransaction transaction);
        public Transaction GetTransactionByID (string id);
        public Transaction GetTransactionByDate (string date);
        public List<Transaction> GetAllTransactions ();
    }
}
