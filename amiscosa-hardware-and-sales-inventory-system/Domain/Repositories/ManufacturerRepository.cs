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
            string constraints = "ManufacturerID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Manufacturer(
                    row["ManufacturerID"].ToString()!,
                    row["ManufacturerName"].ToString()!,
                    row["ManufacturerContact"].ToString()!,
                    row["ManufacturerAddress"].ToString()!
                );
        }

        public List<Manufacturer> GetAllManufacturerByName(string name)
        {
            string constraints = "ManufacturerName LIKE %" + name + "%";
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
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

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            databaseHelper.UpdateRecord(tableName, manufacturer);
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
