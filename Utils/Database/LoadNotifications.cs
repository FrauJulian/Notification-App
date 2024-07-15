using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

namespace Notification_APP.Utils.Database
{
    internal class LoadNotification
    {
        private static SqliteConnection? _connection;

        public static string LoadNotificationsDatabase()
        {
            var databaseFile = Path.Combine(FileSystem.Current.AppDataDirectory, "Database.db");
            _connection = new SqliteConnection(@"Data Source=" + databaseFile);

            try
            {
                _connection.Open();
                var query = "SELECT * FROM `Notifications`";
                var sqlCMD = new SqliteCommand(query, _connection);
                var reader = sqlCMD.ExecuteReader();


                var resultList = new List<Dictionary<string, object>>();

                while (reader.Read())
                {
                    var row = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.GetValue(i);
                    }

                    resultList.Add(row);
                }

                return JsonConvert.SerializeObject(resultList);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
