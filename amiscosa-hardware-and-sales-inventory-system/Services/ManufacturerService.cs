using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class ManufacturerService : IDisposable
    {
        private ManufacturerRepository manufacturerRepository;

        public ManufacturerService()
        {
            manufacturerRepository = new ManufacturerRepository();
            Model = new ManufacturerModel();
            Model = GetAllManufacturers();
        }

        public ManufacturerModel Model { get; set; }

        public ManufacturerModel GetAllManufacturers()
        {
            Model.ManufacturerList = manufacturerRepository.GetAllManufacturers();
            return Model;
        }

        public void AddManufacturer(Manufacturer manufacturer)
        {
            manufacturerRepository.AddManufacturer(manufacturer);
        }

        public void EditManufacturer(Manufacturer manufacturer)
        {
            manufacturerRepository.UpdateManufacturer(manufacturer);
        }

        public void Dispose()
        {
            manufacturerRepository.Dispose();
        }
    }
}
