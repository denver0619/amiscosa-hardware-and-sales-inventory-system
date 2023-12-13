namespace amiscosa_hardware_and_sales_inventory_system.Models
{
    public interface IProduct
    {
        public String ProductID { get; set; }
        public String ProductName { get; set; }
        public String ProductDescription { get; set; }
        public int UnitPrice {  get; set; }
        public int Quantity {  get; set; }
        public String ManufacturerID { get; set; }
        public String Measurement {  get; set; }
        public Boolean IsAvailable { get; set; }
        public int UnitCost { get; set; }
    }
}
