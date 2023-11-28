namespace amiscosa_hardware_and_sales_inventory_system.Models
{
    public class Manufacturer
    {
        private int _manufacturer_id;
        private String? _manufacturer_name;
        private String? _manufacturer_contact;
        private String? _manufacturer_address;
        private Boolean _is_empty = false;

        Manufacturer(int manufacturerID, String manufacturerName, String manufacturerContact, String manufacturerAddress)
        {
            ManufacturerID = manufacturerID;
            ManufacturerName = (manufacturerName == null) ? String.Empty : manufacturerName;
            ManufacturerContact = (manufacturerContact == null) ? String.Empty : manufacturerContact;
            ManufacturerAddress = (manufacturerAddress == null) ? String.Empty : manufacturerAddress;
            if ((manufacturerName == null) || (manufacturerContact == null) || (manufacturerAddress == null))
            {
                IsEmpty = true;
            }
        }

        public int ManufacturerID
        {
            get { return _manufacturer_id; }
            set { _manufacturer_id = value; }
        }

        public String? ManufacturerName
        {
            get { return _manufacturer_name; }
            set { _manufacturer_name = value; }
        }

        public String? ManufacturerContact
        {
            get { return _manufacturer_contact; }
            set { _manufacturer_contact = value; }
        }

        public String? ManufacturerAddress
        {
            get { return _manufacturer_address; }
            set { _manufacturer_address = value; }
        }

        public Boolean IsEmpty
        {
            get { return _is_empty; }
            set { _is_empty = value; }
        }
    }
}
