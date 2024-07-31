using Microsoft.Data.Sqlite;

namespace Notification_APP.Utils.Database
{
    internal class ChangeValues
    {
        public static void ChangeNotificationValues(int id, string valueName, string value)
        {
            SqliteConnection databaseConnection = DatabaseConnection.GetDatabaseConnetion();

            try
            {
                databaseConnection.Open();
                var query = "UPDATE `Notifications` SET " + valueName + " = '" + value + "' WHERE ID = " + id;
                var sqlCMD = new SqliteCommand(query, databaseConnection);
                sqlCMD.ExecuteNonQuery();
            }
            finally
            {
                databaseConnection.Close();
            }
        }
    }
}
