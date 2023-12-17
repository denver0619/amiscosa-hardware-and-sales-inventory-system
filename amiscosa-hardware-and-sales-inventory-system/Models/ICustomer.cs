namespace amiscosa_hardware_and_sales_inventory_system.Models
{
    public interface ICustomer
    {
        public string? CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Contact {  get; set; }

    }
}
