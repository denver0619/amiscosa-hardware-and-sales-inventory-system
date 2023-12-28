using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface IManufacturerRepository
    {
        public void AddManufacturer(Manufacturer manufacturer);
        public void DeleteManufacturer(Manufacturer manufacturer);
        public void UpdateManufacturer(Manufacturer manufacturer);
        public Manufacturer GetManufacturerByID(string id);
        public Manufacturer GetManufacturerByName(string name);
        public List<Manufacturer> GetAllManufacturers();
    }
}
