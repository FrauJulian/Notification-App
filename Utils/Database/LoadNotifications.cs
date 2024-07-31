using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

namespace Notification_APP.Utils.Database
{
    internal class LoadNotifications
    {
        public static string LoadNotificationsDatabase()
        {
            SqliteConnection databaseConnection = DatabaseConnection.GetDatabaseConnetion();

            try
            {
                databaseConnection.Open();
                string query = "SELECT * FROM `Notifications`";
                SqliteCommand sqlCMD = new SqliteCommand(query, databaseConnection);
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
                databaseConnection.Close();
            }
        }
    }
}
