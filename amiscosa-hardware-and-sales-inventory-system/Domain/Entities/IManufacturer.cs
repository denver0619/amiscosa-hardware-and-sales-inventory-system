namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public interface IManufacturer
    {
        public string? ManufacturerID { get; set; }
        public string? ManufacturerName { get; set; }
        public string? ManufacturerContact { get; set; }
        public string? ManufacturerAddress { get; set; }
    }
}
