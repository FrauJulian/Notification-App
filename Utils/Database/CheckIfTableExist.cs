using Microsoft.Data.Sqlite;

namespace Notification_APP.Utils.Database
{
    internal class CheckTable
    {

        public static void CheckIfTableExist()
        {
            SqliteConnection databaseConnection = DatabaseConnection.GetDatabaseConnetion();

            try
            {
                databaseConnection.Open();
                var query = "CREATE TABLE IF NOT EXISTS `Notifications` ( ID int(6) UNIQUE NOT NULL, Title varchar(255) DEFAULT NULL, Description varchar(255) DEFAULT NULL, Timestamp varchar(255) DEFAULT NULL, CONSTRAINT ID PRIMARY KEY(ID) );";
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
