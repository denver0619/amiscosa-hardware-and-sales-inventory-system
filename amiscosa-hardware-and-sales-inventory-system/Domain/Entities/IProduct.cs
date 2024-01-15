namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public interface IProduct
    {
        public string? ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? ManufacturerID { get; set; }
        public string? Measurement { get; set; }
        public bool IsAvailable { get; set; }
        public double UnitCost { get; set; }
    }
}
