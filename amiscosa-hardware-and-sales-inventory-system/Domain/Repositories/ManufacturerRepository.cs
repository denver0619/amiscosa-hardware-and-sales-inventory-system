using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository, IDisposable
    {
        private DatabaseHelper<Manufacturer> databaseHelper;
        private readonly string tableName = "manufacturers";

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
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            foreach (DataRow row in dataTable.Rows)
            {
                Manufacturer manufacturer = new Manufacturer(
                    row["ManufacturerID"].ToString()!,
                    row["ManufacturerName"].ToString()!,
                    row["ManufacturerContact"].ToString()!,
                    row["ManufacturerAddress"].ToString()!);
                manufacturers.Add(manufacturer);
            }
            return manufacturers;
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
