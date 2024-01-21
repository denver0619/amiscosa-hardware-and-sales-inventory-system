using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    /// <summary>
    /// Represents a model for generating reports.
    /// </summary>
    public class ReportModel
    {
        /// <summary>
        /// Gets or sets the total revenue.
        /// </summary>
        public double TotalRevenue { get; set; }

        /// <summary>
        /// Gets or sets the total profit.
        /// </summary
        public double TotalProfit { get; set; }

        /// <summary>
        /// Gets or sets the number of products sold.
        /// </summary>
        public int NumberOfProductsSold { get; set; }

        /// <summary>
        /// Gets or sets the number of transactions done.
        /// </summary>
        public int NumberOfTransactionsDone { get; set; }

        /// <summary>
        /// Gets or sets the list of products sold along with their details.
        /// </summary>
        public List<ProductSoldDataTransferObject>? ProductList { get; set; }

        /// <summary>
        /// Gets or sets a dictionary representing the tally of products.
        /// </summary>
        public Dictionary<string, int>? ProductTally { get; set; }
    }
}
