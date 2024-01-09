using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class ReportService
    {
        private TransactionRepository transactionRepository;
        private TransactionDetailRepository transactionDetailRepository;
        private ProductRepository productRepository;
        
        public ReportService ()
        {
            transactionRepository = new TransactionRepository ();
            transactionDetailRepository = new TransactionDetailRepository ();
            productRepository = new ProductRepository ();
        }
    }
}
