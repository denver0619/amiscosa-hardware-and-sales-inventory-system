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
                transactions.Add(transaction);
            }
            return new List<Transaction>();
        }

        public List<Transaction> GetAllTransactionByYearMonth(DateTime dateTime)
        {
            string constrainsts = "MONTH(TransactionDate) = " + dateTime.Month.ToString() + " AND YEAR(TransactionDate) = " + dateTime.Year.ToString();
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constrainsts);
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
                transactions.Add(transaction);
            }
            return transactions;
        }
        public List<Transaction> GetAllTransactionsByYear (DateTime dateTime)
        {
            string constrainsts = "YEAR(TransactionDate) = " + dateTime.Year.ToString();
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constrainsts);
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
                transactions.Add(transaction);
            }
            return transactions;
        }
        public Transaction GetTransactionByID(string id)
        {
            string constraints = "TransactionID = " + id;
            DataTable  dataTable = databaseHelper.SelectRecord(tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Transaction(
                    row["TransactionID"].ToString()!,
                    DateTime.Parse(row["TransactionDate"].ToString()!),
                    row["StaffID"].ToString()!,
                    row["CustomerID"].ToString()!,
                    bool.Parse(row["IsInvalid"].ToString()!)
                );
        }

        public void UpdateTransaction(Transaction transaction)
        {
            databaseHelper.UpdateRecord(tableName, transaction);
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
