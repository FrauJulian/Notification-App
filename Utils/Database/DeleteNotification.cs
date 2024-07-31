using Microsoft.Data.Sqlite;

namespace Notification_APP.Utils.Database
{
    internal class DeleteNotification
    {
        public static void DeleteNotificationDatabase(int id)
        {
            SqliteConnection databaseConnection = DatabaseConnection.GetDatabaseConnetion();

            try
            {
                databaseConnection.Open();
                string query = "DELETE FROM `Notifications` WHERE ID = " + id;
                SqliteCommand sqlCMD = new SqliteCommand(query, databaseConnection);
                sqlCMD.ExecuteNonQuery();
            }
            finally
            {
                databaseConnection.Close();
            }
        }
    }
}
