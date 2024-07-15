using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Notification_APP.Utils.Database
{
    internal class ChangeValues
    {
        private static SqliteConnection? _connection;

        public static void ChangeNotificationValues(int id, string valueName, string value)
        {
            var databaseFile = Path.Combine(FileSystem.Current.AppDataDirectory, "Database.db");
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
            }
        }
    }
}
