using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    /// <summary>
    /// A service class responsible for managing transaction history.
    /// Implements the <see cref="IDisposable"/> interface to handle resource cleanup.
    /// </summary>
    public class TransactionHistoryService : IDisposable
    {
        TransactionRepository transactionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionHistoryService"/> class.
        /// Creates an instance of the transaction repository and initializes the transaction history model.
        /// </summary>
        public TransactionHistoryService()
        {
            transactionRepository = new TransactionRepository();
            Model = new TransactionHistoryModel();
            Model = GetAllTransaction();
        }

        /// <summary>
        /// Gets or sets the transaction history model associated with the service.
        /// </summary>
        public TransactionHistoryModel Model { get; set; }

        /// <summary>
        /// Retrieves a transaction history model containing all transactions in descending order by TransactionID.
        /// </summary>
        /// <returns>The transaction history model with all transactions.</returns>
        public TransactionHistoryModel GetAllTransaction()
        {
            Model.TransactionList = transactionRepository.GetAllTransactions().OrderByDescending(transaction=>transaction.TransactionID).ToList();
            return Model;
        }

        /// <summary>
        /// Disposes of the resources used by the transaction history service, including the associated repository.
        /// </summary>
        public void Dispose()
        {
            transactionRepository.Dispose();
        }

    }
}
