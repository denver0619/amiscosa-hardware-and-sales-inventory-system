using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class NotificationRepository : INotificationRepository, IDisposable
    {
        private DatabaseHelper<Notification> databaseHelper;
        private readonly string tableName = "notifications";
        

        public NotificationRepository()
        {
            databaseHelper = new DatabaseHelper<Notification>();
        }

        
        public void AddNotification(Notification notification)
        {
            databaseHelper.InsertRecord(tableName, notification);
        }


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
        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
