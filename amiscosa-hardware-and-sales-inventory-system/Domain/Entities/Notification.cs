namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    /// <summary>
    /// Represents a notification implementing the INotification interface.
    /// </summary>
    public class Notification : INotification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        public Notification() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class with specified details.
        /// </summary>
        /// <param name="notificationID">The unique identifier for the notification.</param>
        /// <param name="notificationName">The name of the notification.</param>
        /// <param name="notificationDescription">The description of the notification.</param>
        /// <param name="productID">The identifier of the related product.</param>
        /// <param name="notificationType">The type of the notification.</param>
        public Notification(string notificationID, string notificationName, string notificationDescription, string productID, int notificationType)
        {
            NotificationID = notificationID;
            NotificationName = notificationName;
            NotificationDescription = notificationDescription;
            ProductID = productID;
            NotificationType = notificationType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class using another notification's information.
        /// </summary>
        /// <param name="notification">An object implementing the INotification interface from which to copy information.</param>
        public Notification(INotification notification)
        {
            NotificationID = notification.NotificationID;
            NotificationName = notification.NotificationName;
            NotificationDescription = notification.NotificationDescription;
            ProductID = notification.ProductID;
            NotificationType = notification.NotificationType;
        }
        public string? NotificationID { get; set; }
        public string? NotificationName { get; set; }
        public string? NotificationDescription { get; set; }
        public string? ProductID { get; set; }
        public int NotificationType { get; set; }
    }
}
