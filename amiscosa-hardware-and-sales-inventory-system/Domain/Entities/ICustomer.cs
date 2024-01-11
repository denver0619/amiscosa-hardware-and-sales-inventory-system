namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public interface ICustomer
    {
        public string? CustomerID { get; set; }
        public string? CustomerFName { get; set; }
        public string? CustomerMName { get; set; }
        public string? CustomerLName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerContact { get; set; }

    }
}
