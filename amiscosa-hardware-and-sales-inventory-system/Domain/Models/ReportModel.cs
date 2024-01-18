using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    public class ReportModel
    {
        public double TotalRevenue { get; set; }
        public double TotalProfit { get; set; }
        public int NumberOfProductsSold { get; set; }
        public int NumberOfTransactionsDone { get; set; }
        public List<ProductSoldDataTransferObject>? ProductList { get; set; }

        public Dictionary<string, int>? ProductTally { get; set; }

    }
}
