namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public interface ICustomer
    {
        public string? CustomerID { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerMiddleName { get; set; }
        public string? CustomerLastName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerContact { get; set; }

    }
}
