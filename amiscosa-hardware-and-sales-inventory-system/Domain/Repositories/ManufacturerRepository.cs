using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

/// <summary>
/// Represents a repository for managing manufacturer data in a database.
/// Implements the <see cref="IManufacturerRepository"/> interface.
/// </summary>
namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository, IDisposable
    {
        private DatabaseHelper<Manufacturer> databaseHelper;
        private readonly string tableName = "manufacturers";

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturerRepository"/> class.
        /// </summary>
        public ManufacturerRepository()
        {
            databaseHelper = new DatabaseHelper<Manufacturer>();
        }

        /// <summary>
        /// Adds a new manufacturer to the database.
        /// </summary>
        /// <param name="manufacturer">The manufacturer object to be added.</param>
        public void AddManufacturer(Manufacturer manufacturer)
        {
            databaseHelper.InsertRecord(tableName, manufacturer);
        }

        /// <summary>
        /// Retrieves all manufacturers from the database.
        /// </summary>
        /// <returns>A list of manufacturer objects.</returns>
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

        /// <summary>
        /// Retrieves a manufacturer from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the manufacturer to retrieve.</param>
        /// <returns>The manufacturer object with the specified ID.</returns>
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

        /// <summary>
        /// Retrieves manufacturers from the database based on the provided name.
        /// </summary>
        /// <param name="name">The name or part of the name to search for.</param>
        /// <returns>A list of manufacturer objects matching the provided name.</returns>
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

        /// <summary>
        /// Updates the information of an existing manufacturer in the database.
        /// </summary>
        /// <param name="manufacturer">The updated manufacturer object.</param>
        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            databaseHelper.UpdateRecord(tableName, manufacturer);
        }

        /// <summary>
        /// Disposes of the resources used by the repository.
        /// </summary>
        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
