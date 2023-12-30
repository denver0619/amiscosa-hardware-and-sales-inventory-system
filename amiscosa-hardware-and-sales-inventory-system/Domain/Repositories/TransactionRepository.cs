using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;
using System.Data.SqlTypes;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class TransactionRepository : ITransactionRepository, IDisposable
    {
        private DatabaseHelper<Transaction> databaseHelper;
        private readonly string tableName = "transactions";

        public TransactionRepository()
        {
            databaseHelper = new DatabaseHelper<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            databaseHelper.InsertRecord(tableName, transaction);
        }

        public void DeleteTransaction(Transaction transaction)
        {
            Transaction transactionData = new Transaction(transaction)
            {
                IsInvalid = true
            };
            databaseHelper.UpdateRecord(tableName, transactionData);
        }


        public List<Transaction> GetAllTransactions()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<Transaction> transactions = new List<Transaction>();
            foreach (DataRow row in dataTable.Rows)
            {
                Transaction transaction = new Transaction(
                    row["TransactionID"].ToString()!,
                    DateTime.Parse(row["TransactionDate"].ToString()!),
                    row["StaffID"].ToString()!,
                    row["CustomerID"].ToString()!,
                    bool.Parse(row["IsInvalid"].ToString()!)
                    );
            }
            return new List<Transaction>();
        }

        public List<Transaction> GetAllTransactionByYearMonth(DateTime dateTime)
        {

            throw new NotImplementedException();
        }
        public List<Transaction> GetAllTransactionsByYear (DateTime dateTime)
        {
            throw new NotImplementedException();
        }
        public Transaction GetTransactionByID(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
