namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public class Notification : INotification
    {
        public Notification(string notificationID, string notificationName, string notificationDescription, string productID, int notificationType)
        {
            NotificationID = notificationID;
            NotificationName = notificationName;
            NotificationDescription = notificationDescription;
            ProductID = productID;
            NotificationType = notificationType;
        }

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
