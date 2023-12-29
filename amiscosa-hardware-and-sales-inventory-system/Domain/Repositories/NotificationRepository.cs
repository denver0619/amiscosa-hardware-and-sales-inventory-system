using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private DatabaseHelper<Notification> databaseHelper;
        private readonly string tableName = "notifications";
        

        public NotificationRepository()
        {
            databaseHelper = new DatabaseHelper<Notification>();
        }

        
        public void AddNotification(INotification notification)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
