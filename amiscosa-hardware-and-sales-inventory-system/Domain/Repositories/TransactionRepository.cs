using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;
using System.Data.SqlTypes;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    /// <summary>
    /// Represents a repository for managing transaction data in a database.
    /// Implements the <see cref="ITransactionRepository"/> interface.
    /// </summary>
    public class TransactionRepository : ITransactionRepository, IDisposable
    {
        private DatabaseHelper<Transaction> databaseHelper;
        private readonly string tableName = "transactions";

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRepository"/> class.
        /// </summary>
        public TransactionRepository()
        {
            databaseHelper = new DatabaseHelper<Transaction>();
        }

        /// <summary>
        /// Adds a new transaction to the database.
        /// </summary>
        /// <param name="transaction">The transaction object to be added.</param>
        public void AddTransaction(Transaction transaction)
        {
            databaseHelper.InsertRecord(tableName, transaction);
        }

        /// <summary>
        /// Deletes a transaction from the database by marking it as invalid.
        /// </summary>
        /// <param name="transaction">The transaction object to be marked as invalid.</param>
        public void DeleteTransaction(Transaction transaction)
        {
            Transaction transactionData = new Transaction(transaction)
            {
                IsInvalid = true
            };
            databaseHelper.UpdateRecord(tableName, transactionData);
        }

        /// <summary>
        /// Retrieves all transactions from the database.
        /// </summary>
        /// <returns>A list of transaction objects.</returns>
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
            return transactions;
        }

        /// <summary>
        /// Retrieves all transactions from the database for a specific year and month.
        /// </summary>
        /// <param name="dateTime">The year and month to filter transactions.</param>
        /// <returns>A list of transaction objects for the specified year and month.</returns>
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

        /// <summary>
        /// Retrieves all transactions from the database for a specific year.
        /// </summary>
        /// <param name="dateTime">The year to filter transactions.</param>
        /// <returns>A list of transaction objects for the specified year.</returns>
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

        /// <summary>
        /// Retrieves a transaction from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the transaction to retrieve.</param>
        /// <returns>The transaction object with the specified ID.</returns>
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

        /// <summary>
        /// Updates the information of an existing transaction in the database.
        /// </summary>
        /// <param name="transaction">The updated transaction object.</param>
        public void UpdateTransaction(Transaction transaction)
        {
            databaseHelper.UpdateRecord(tableName, transaction);
        }

        /// <summary>
        /// Disposes of the resources used by the repository.
        /// </summary>
        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
