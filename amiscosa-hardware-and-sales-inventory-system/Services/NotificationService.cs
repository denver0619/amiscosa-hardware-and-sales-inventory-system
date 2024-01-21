using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    /// <summary>
    /// A service class responsible for managing notification-related operations.
    /// Implements the <see cref="IDisposable"/> interface to handle resource cleanup.
    /// </summary>
    public class NotificationService : IDisposable
    {
        private NotificationRepository notificationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationService"/> class.
        /// Creates an instance of <see cref="NotificationRepository"/> and initializes the notification model.
        /// </summary>
        public NotificationService()
        {
            notificationRepository = new NotificationRepository();
            Model = new NotificationModel();
        }

        /// <summary>
        /// Gets or sets the notification model associated with the service.
        /// </summary>
        public NotificationModel Model { get; set; }

        /// <summary>
        /// Retrieves a notification model containing a list of all notifications.
        /// </summary>
        /// <returns>The notification model with the list of notifications.</returns>
        public NotificationModel GetAllNotificationList()
        {
            Model.NotificationList = notificationRepository.GetAllNotification();
            return Model;
        }

        /// <summary>
        /// Adds a new notification to the system.
        /// </summary>
        /// <param name="notification">The notification to be added.</param>
        public void AddNotification(Notification notification)
        {
            notificationRepository.AddNotification(notification);
        }

        /// <summary>
        /// Disposes of the resources used by the notification service, including the associated repository.
        /// </summary>
        public void Dispose()
        {
            notificationRepository.Dispose();
        }
    }
}
