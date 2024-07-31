using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Notification_APP.Utils;
using Notification_APP.Utils.Database;
using System.Globalization;

namespace Notification_APP.Listener
{
    internal class Listeners
    {
        public static void CheckIfDateTimeIsBiggerThanNow()
        {
            var objects = JsonConvert.DeserializeObject<List<dynamic>>(LoadNotifications.LoadNotificationsDatabase());

            List<string> timestamps = new List<string>();

            foreach (var obj in objects)
            {
                string timestamp = obj.Timestamp;
                timestamps.Add(timestamp);
            }

            List<string> titles = new List<string>();

            foreach (var obj in objects)
            {
                string title = obj.Title;
                titles.Add(title);
            }

            foreach (var timestamp in timestamps)
            {
                CultureInfo formatCulture = new CultureInfo("de-DE");
                DateTime parsedTime = DateTime.ParseExact(timestamp, "f", formatCulture);

                if (parsedTime < DateTime.Now) 
                {
                    LocalNotification.LaunchNotification("NEW NOTIFICATION", "Please, check the app!");
                }
            }
        }
    }
}
