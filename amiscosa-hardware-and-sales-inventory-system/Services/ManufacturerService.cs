using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    /// <summary>
    /// A service class responsible for managing manufacturer-related operations.
    /// Implements the <see cref="IDisposable"/> interface to handle resource cleanup.
    /// </summary>
    public class ManufacturerService : IDisposable
    {
        private ManufacturerRepository manufacturerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturerService"/> class.
        /// Creates an instance of <see cref="ManufacturerRepository"/> and initializes the manufacturer model.
        /// </summary>
        public ManufacturerService()
        {
            manufacturerRepository = new ManufacturerRepository();
            Model = new ManufacturerModel();
            Model = GetAllManufacturers();
        }

        /// <summary>
        /// Gets or sets the manufacturer model associated with the service.
        /// </summary>
        public ManufacturerModel Model { get; set; }

        /// <summary>
        /// Retrieves a manufacturer model containing a list of all manufacturers.
        /// </summary>
        /// <returns>The manufacturer model with the list of manufacturers.</returns>
        public ManufacturerModel GetAllManufacturers()
        {
            Model.ManufacturerList = manufacturerRepository.GetAllManufacturers();
            return Model;
        }

        /// <summary>
        /// Adds a new manufacturer to the system.
        /// </summary>
        /// <param name="manufacturer">The manufacturer to be added.</param>
        public void AddManufacturer(Manufacturer manufacturer)
        {
            manufacturerRepository.AddManufacturer(manufacturer);
        }

        /// <summary>
        /// Edits an existing manufacturer in the system.
        /// </summary>
        /// <param name="manufacturer">The updated manufacturer information.</param>
        public void EditManufacturer(Manufacturer manufacturer)
        {
            manufacturerRepository.UpdateManufacturer(manufacturer);
        }

        /// <summary>
        /// Disposes of the resources used by the manufacturer service, including the associated repository.
        /// </summary>
        public void Dispose()
        {
            manufacturerRepository.Dispose();
        }
    }
}
