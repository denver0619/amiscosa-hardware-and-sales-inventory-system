using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    /// <summary>
    /// Represents a model containing a list of notifications.
    /// </summary>
    public class NotificationModel
    {
        /// <summary>
        /// Gets or sets the list of notifications.
        /// </summary>
        public List<Notification>? NotificationList { get; set; }
    }
}
