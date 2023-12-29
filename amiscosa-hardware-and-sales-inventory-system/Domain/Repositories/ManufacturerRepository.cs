using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository, IDisposable
    {
        private DatabaseHelper<Manufacturer> databaseHelper;
        private readonly string tableName = "Manufacturers";
        private readonly string tableFields = "(manufacturer_id, manufacturer_name, manufacturer_contact, manufacturer_address)";
        private readonly string tableAddFields = "(manufacturer_name, manufacturer_contact, manufacturer_address)";

        public ManufacturerRepository()
        {
            databaseHelper = new DatabaseHelper<Manufacturer>();
        }

        public void AddManufacturer(Manufacturer manufacturer)
        {
            databaseHelper.InsertRecord(tableName, manufacturer);
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

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            Manufacturer manufacturerData = new Manufacturer(manufacturer);
            databaseHelper.UpdateRecord(tableName, manufacturerData);
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
