using Microsoft.Data.Sqlite;
using Notification_APP.Utils.CacheData;

namespace Notification_APP.Utils.Database
{
    internal class ChangeValues
    {
        private static SqliteConnection? _connection;

        public static void ChangeNotificationValues(int id, string valueName, string value)
        {
            string databaseFile = Path.Combine(FileSystem.Current.AppDataDirectory, "Database.db");
            _connection = new SqliteConnection(@"Data Source=" + databaseFile);

            try
            {
                _connection.Open();
                var query = "UPDATE `Notifications` SET " + valueName + " = '" + value + "' WHERE ID = " + id;
                var sqlCMD = new SqliteCommand(query, _connection);
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
