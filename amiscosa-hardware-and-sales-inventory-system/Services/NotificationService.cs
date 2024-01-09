using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class NotificationService
    {
        private NotificationRepository notificationRepository;
        public NotificationService()
        {
            notificationRepository = new NotificationRepository();
            Model = new NotificationModel();
        }
        public NotificationModel Model { get; set; }

        public NotificationModel GetAllNotificationList()
        {
            Model.NotificationList = notificationRepository.GetAllNotification();
            return Model;
        }
    }
}
