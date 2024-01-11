using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class NotificationService : IDisposable
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

        public void AddNotification(Notification notification)
        {
            notificationRepository.AddNotification(notification);
        }

        public void Dispose()
        {
            notificationRepository.Dispose();
        }
    }
}
