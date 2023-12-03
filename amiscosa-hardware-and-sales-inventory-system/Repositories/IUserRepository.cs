using amiscosa_hardware_and_sales_inventory_system.Models;
namespace amiscosa_hardware_and_sales_inventory_system.Repositories
{
    public interface IUserRepository
    {
        public IUser GetUserByID();
        public IUser GetUserByUserName(string username);
        public List<IUser> GetAllUser();
        public void AddUser();
        public void UpdateUser();
        public void DeleteUser();
    }
}
