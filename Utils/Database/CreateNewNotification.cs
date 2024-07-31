using Microsoft.Data.Sqlite;
using System.Globalization;

namespace Notification_APP.Utils.Database
{
    internal class CreateNotification
    {
        private static double GenerateID()
        {
            Random random = new Random();
            double number = random.Next(0, 1000000);
            return number;
        }

        public static double CreateNewNotification(string title, DateTime time, string? description = null)
        {
            SqliteConnection databaseConnection = DatabaseConnection.GetDatabaseConnetion();

            try
            {
                databaseConnection.Open();

                double id = TryCreateNewNotification(
                    GenerateID(), 
                    databaseConnection, 
                    title, 
                    time, 
                    description
                    );

                return id;
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        private static double TryCreateNewNotification
            (
            double id,
            SqliteConnection databaseConnection,
            string title,
            DateTime time,
            string? description = null
            )
        {
            try
            {
                CultureInfo formatCulture = new CultureInfo("de-DE");
                string formattedDateTime = time.ToString("f", formatCulture);

                string query;

                if (description == null)
                {
                    query = "INSERT INTO `Notifications` (ID, Title, Timestamp) VALUES (" + id + ", '" + title + "', '" + formattedDateTime + "') ";
                }
                else
                {
                    query = "INSERT INTO `Notifications` (ID, Title, Description, Timestamp) VALUES (" + id + ", '" + title + "', '" + description + "', '" + formattedDateTime + "') ";
                }

                SqliteCommand sqlCMD = new SqliteCommand(query, databaseConnection);
                sqlCMD.ExecuteNonQuery();

                return id;
            }
            catch (Microsoft.Data.Sqlite.SqliteException ex)
            {
                return -0;
            }
        }
    }
}
