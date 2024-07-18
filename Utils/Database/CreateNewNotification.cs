using Microsoft.Data.Sqlite;
using Microsoft.Maui.Controls;
using Notification_APP.Utils.CacheData;
using Notification_APP.Utils.Timestamp;
using System.Globalization;

namespace Notification_APP.Utils.Database
{
    internal class CreateNotification
    {
        private static SqliteConnection? _connection;

        private static string GenerateID()
        {
            Random random = new Random();
            string number = String.Empty;

            for (int i = 0; i < 6; i++)
            {
                number += random.Next(0, 10).ToString();
            }

            return number;
        }

        public static void CreateNewNotification(string name, DateTime time)
        {
            string databaseFile = Path.Combine(FileSystem.Current.AppDataDirectory, "Database.db");
            _connection = new SqliteConnection(@"Data Source=" + databaseFile);

            try
            {
                CultureInfo germanCulture = new CultureInfo("de-DE");
                string formattedDateTime = time.ToString("G", germanCulture);

                _connection.Open();
                string query = "INSERT INTO `Notifications` (ID, Name, Timestamp) VALUES (" + GenerateID() + ", '" + name + "', '" + formattedDateTime + "') ";
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
