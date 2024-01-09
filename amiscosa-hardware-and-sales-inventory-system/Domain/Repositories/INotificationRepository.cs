using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface INotificationRepository
    {
        public void AddNotification(Notification notification);
        public Notification GetNotificationByID(string id);
        public List<Notification> GetAllNotification();
    }
}
