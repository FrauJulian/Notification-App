using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification_APP.Utils.Database
{
    internal class DeleteNotification
    {
        private static SqliteConnection? _connection;

        public static void DeleteNotificationDatabase(int id)
        {
            var databaseFile = Path.Combine(FileSystem.Current.AppDataDirectory, "Database.db");
            _connection = new SqliteConnection(@"Data Source=" + databaseFile);

            try
            {
                _connection.Open();
                var query = "DELETE FROM `Notifications` WHERE ID = " + id;
                var sqlCMD = new SqliteCommand(query, _connection);
                sqlCMD.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
