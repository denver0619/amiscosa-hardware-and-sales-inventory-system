using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    /// <summary>
    /// Represents a repository for managing notification data in a database.
    /// Implements the <see cref="INotificationRepository"/> interface.
    /// </summary>
    public class NotificationRepository : INotificationRepository, IDisposable
    {
        private DatabaseHelper<Notification> databaseHelper;
        private readonly string tableName = "notifications";

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationRepository"/> class.
        /// </summary>
        public NotificationRepository()
        {
            databaseHelper = new DatabaseHelper<Notification>();
        }

        /// <summary>
        /// Adds a new notification to the database.
        /// </summary>
        /// <param name="notification">The notification object to be added.</param>
        public void AddNotification(Notification notification)
        {
            databaseHelper.InsertRecord(tableName, notification);
        }

        /// <summary>
        /// Retrieves all notifications from the database.
        /// </summary>
        /// <returns>A list of notification objects.</returns>
        public List<Notification> GetAllNotification()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<Notification> notifications = new List<Notification>();
            foreach (DataRow row in dataTable.Rows)//retrieve data per row
            {
                Notification notification = new Notification(row["NotificationID"].ToString()!, row["NotificationName"].ToString()!, row["NotificationDescription"].ToString()!, row["ProductID"].ToString()!, Int32.Parse (row["NotificationType"].ToString()!));
                notifications.Add(notification);
            }
            return notifications;
        }

        /// <summary>
        /// Retrieves a notification from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the notification to retrieve.</param>
        /// <returns>The notification object with the specified ID.</returns>
        public Notification GetNotificationByID(string id)
        {
            string constraints = "NotificationID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord (this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Notification(
                row["NotificationID"].ToString()!,
                row["NotificationName"].ToString()!,
                row["NotificationDescription"].ToString()!,
                row["ProductID"].ToString()!,
                Int32.Parse(row["NotificationType"].ToString()!)
                );
        }

        /// <summary>
        /// Disposes of the resources used by the repository.
        /// </summary>
        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
