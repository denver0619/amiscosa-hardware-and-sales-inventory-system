using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class TransactionDetailRepository : ITransactionDetailRepository, IDisposable
    {
        private DatabaseHelper<TransactionDetail> databaseHelper;
        private readonly string tableName = "transactiondetails";

        public TransactionDetailRepository()
        {
            databaseHelper = new DatabaseHelper<TransactionDetail>();
        }

        public void AddTransactionDetail(TransactionDetail transactionDetail)
        {
            databaseHelper.InsertRecord(tableName, transactionDetail);
        }

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

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
