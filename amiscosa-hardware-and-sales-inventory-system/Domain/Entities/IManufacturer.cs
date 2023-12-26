namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public interface IManufacturer
    {
        public string? ManufacturerID { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }
    }
}
