using Microsoft.Data.Sqlite;

namespace Notification_APP.Utils.Database
{
    internal class DatabaseConnection
    {
        public static SqliteConnection GetDatabaseConnetion() 
        {
            string databaseFile = Path.Combine(FileSystem.Current.AppDataDirectory, "Database.db");
            SqliteConnection databaseConnection = new SqliteConnection(@"Data Source=" + databaseFile);
            return databaseConnection;
        }
    }
}
