using Microsoft.Data.Sqlite;
using System.Data.SqlTypes;

namespace Notification_APP.Utils.Database
{
    internal class TableExists
    {
        private static SqliteConnection? _connection;

        public static void CheckIfTableExist()
        {
            var databaseFile = Path.Combine(FileSystem.Current.AppDataDirectory, "Database.db");
            _connection = new SqliteConnection(@"Data Source=" + databaseFile);

            try
            {
                _connection.Open();
                var query = "CREATE TABLE IF NOT EXISTS `Notifications` ( ID int(12) UNIQUE NOT NULL, Name varchar(255) DEFAULT NULL, Description varchar(255) DEFAULT NULL, Timestamp varchar(255) DEFAULT NULL, Interval varchar(255) DEFAULT NULL, CONSTRAINT ID PRIMARY KEY(ID) );";
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
