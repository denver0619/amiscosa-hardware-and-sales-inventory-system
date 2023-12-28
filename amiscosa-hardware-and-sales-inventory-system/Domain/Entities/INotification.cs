namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public interface INotification
    {
        public string? NotificationID { get; set; }
        public string? NotificationName { get; set; }
        public string? NotificationDescription { get; set; }
        public string? ProductID { get; set; }
        public int NotificationType { get; set; }
    }
}
