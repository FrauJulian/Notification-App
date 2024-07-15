using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification_APP.Utils.Database
{
    internal class CreateNotification
    {
        private static SqliteConnection? _connection;

        private static string GenerateID()
        {
            Random random = new Random();
            string number = "";

            for (int i = 0; i < 12; i++)
            {
                number += random.Next(0, 10).ToString();
            }

            return number;
        }

        public static void CreateNewNotification(string name, int timestamp)
        {
            var databaseFile = Path.Combine(FileSystem.Current.AppDataDirectory, "Database.db");
            _connection = new SqliteConnection(@"Data Source=" + databaseFile);

            try
            {
                _connection.Open();
                var query = "INSERT INTO `Notifications` (ID, Name, Timestamp) VALUES (" + GenerateID() + ", '" + name + "', " + timestamp.ToString() + ") ";
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
