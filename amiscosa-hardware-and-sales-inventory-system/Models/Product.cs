namespace amiscosa_hardware_and_sales_inventory_system.Models
{
    public class Product : IProduct
    {
        private string? _producID;
        private string? _productName;
        private string? _productDescription;
        private int _unitPrice;
        private int _quantity;
        private string? _manufacturerID;
        private string? _measurement;
        private bool _isAvailable;
        private int _unitCost;

        public Product(string productID, string productName, string productDescription, int unitPrice, int quantity, string manufacturerID, string measurement, bool isAvailable, int unitCost)
        {
            ProductID = productID;
            ProductName = productName;
            ProductDescription = productDescription;
            UnitPrice = unitPrice;
            Quantity = quantity;
            ManufacturerID = manufacturerID;
            Measurement = measurement;
            IsAvailable = isAvailable;
            UnitCost = unitCost;
        }

        public string ProductID
        {
            get { return _producID!; }
            set { _producID = value; }
        }
        public string ProductName
        {
            get { return _productName!; }
            set { _productName = value; }
        }
        public string ProductDescription
        {
            get { return _productDescription!; }
            set { _productDescription = value; }
        }
        public int UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public string ManufacturerID
        {
            get { return _manufacturerID!; }
            set { _manufacturerID = value; }
        }
        public string Measurement
        {
            get { return _measurement!; }
            set { _measurement = value; }
        }
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; }
        }
        public int UnitCost
        {
            get { return _unitCost; }
            set { _unitCost = value; }
        }
    }
}
