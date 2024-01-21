using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    /// <summary>
    /// Represents a repository for managing transaction detail data in a database.
    /// Implements the <see cref="ITransactionDetailRepository"/> interface.
    /// </summary>
    public class TransactionDetailRepository : ITransactionDetailRepository, IDisposable
    {
        private DatabaseHelper<TransactionDetail> databaseHelper;
        private readonly string tableName = "transactiondetails";

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionDetailRepository"/> class.
        /// </summary>
        public TransactionDetailRepository()
        {
            databaseHelper = new DatabaseHelper<TransactionDetail>();
        }

        /// <summary>
        /// Adds a new transaction detail to the database.
        /// </summary>
        /// <param name="transactionDetail">The transaction detail object to be added.</param>
        public void AddTransactionDetail(TransactionDetail transactionDetail)
        {
            databaseHelper.InsertRecord(tableName, transactionDetail);
        }

        /// <summary>
        /// Retrieves all transaction details associated with a specific transaction ID from the database.
        /// </summary>
        /// <param name="transactionID">The ID of the transaction to retrieve details for.</param>
        /// <returns>A list of transaction detail objects associated with the specified transaction ID.</returns>
        public List<TransactionDetail> GetAllTransactionDetailByTransactionID(string transactionID)
        {
            string constraints = "TransactionID = " + transactionID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<TransactionDetail> transactionDetails = new List<TransactionDetail>();
            foreach (DataRow row in  dataTable.Rows)
            {
                TransactionDetail transactionDetail = new TransactionDetail(
                    row["TransactionDetailID"].ToString()!,
                    row["TransactionID"].ToString()!,
                    row["ProductID"].ToString()!,
                    Int32.Parse(row["Quantity"].ToString()!)
                    );
                transactionDetails.Add(transactionDetail);
            }
            return transactionDetails;
        }

        /// <summary>
        /// Retrieves all transaction details associated with a specific product ID from the database.
        /// </summary>
        /// <param name="productID">The ID of the product to retrieve transaction details for.</param>
        /// <returns>A list of transaction detail objects associated with the specified product ID.</returns>
        public List<TransactionDetail> GetAllTransactionsByProductID(string productID)
        {
            string constraints = "ProductID = " + productID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<TransactionDetail> transactionDetails = new List<TransactionDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                TransactionDetail transactionDetail = new TransactionDetail(
                    row["TransactionDetailID"].ToString()!,
                    row["TransactionID"].ToString()!,
                    row["ProductID"].ToString()!,
                    Int32.Parse(row["Quantity"].ToString()!)
                    );
                transactionDetails.Add(transactionDetail);
            }
            return transactionDetails;
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
