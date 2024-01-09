using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    public class ReportModel
    {
        public int TotalRevenue { get; set; }
        public int NumberOfProductsSold { get; set; }
        public int NumberOfTransactionsDone { get; set; }
        public List<Product>? ProductList { get; set; }
    }
}
