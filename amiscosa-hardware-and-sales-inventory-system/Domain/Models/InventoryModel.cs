using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    public class InventoryModel
    {
        public InventoryModel(List<Product> productList)
        {
            ProductList = productList;
        }
        public List<Product> ProductList { get; set; }
    }
}
