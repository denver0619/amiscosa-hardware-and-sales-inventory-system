using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository, IDisposable
    {
        private DatabaseHelper databaseHelper;
        private readonly string tableName = "Manufacturers";
        private readonly string tableFields = "(manufacturer_id, manufacturer_name, manufacturer_contact, manufacturer_address)";
        private readonly string tableAddFields = "(manufacturer_name, manufacturer_contact, manufacturer_address)";

        public ManufacturerRepository()
        {
            databaseHelper = new DatabaseHelper();
        }

        public void AddManufacturer(IManufacturer manufacturer)
        {
            string manufacturerValues = "(" + manufacturer.ManufacturerName + "," + manufacturer.ManufacturerContact + "," + manufacturer.ManufacturerAddress + ")";
            List<string> values = [manufacturerValues];
            databaseHelper.InsertRecord(tableName, tableAddFields, values);
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            throw new NotImplementedException();
        }

        public Manufacturer GetManufacturerByID(string id)
        {
            throw new NotImplementedException();
        }

        public Manufacturer GetManufacturerByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateManufacturer(IManufacturer manufacturer)
        {
            Manufacturer manufacturerData = new Manufacturer(manufacturer);
            string manufacturerValues = "(" + manufacturer.ManufacturerID + "," + manufacturer.ManufacturerName + "," + manufacturer.ManufacturerContact + "," + manufacturer.ManufacturerAddress + ")";
            string constraints = "manufacturer = " + manufacturerData.ManufacturerID;
            databaseHelper.UpdateRecord(tableName, manufacturerValues, constraints);
        }
        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
