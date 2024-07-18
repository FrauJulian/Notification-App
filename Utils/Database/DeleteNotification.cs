using Microsoft.Data.Sqlite;
using Notification_APP.Utils.CacheData;

namespace Notification_APP.Utils.Database
{
    internal class DeleteNotification
    {
        private static SqliteConnection? _connection;

        public static void DeleteNotificationDatabase(int id)
        {
            string databaseFile = Path.Combine(FileSystem.Current.AppDataDirectory, "Database.db");
            _connection = new SqliteConnection(@"Data Source=" + databaseFile);

            try
            {
                _connection.Open();
                string query = "DELETE FROM `Notifications` WHERE ID = " + id;
                SqliteCommand sqlCMD = new SqliteCommand(query, _connection);
                sqlCMD.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
                SafeCache.SafeNotificationsOnLoad(LoadNotifications.LoadNotificationsDatabase());
            }
        }
    }
}
