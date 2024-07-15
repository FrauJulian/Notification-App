using Plugin.LocalNotification;

namespace Notification_APP.Utils
{
    internal class LocalNotification
    {
        public static void LaunchNotification(string name, string? subTitle, string description)
        {
            if (subTitle != null)
            {
                var request = new NotificationRequest
                {
                    NotificationId = 1337,
                    Title = name,
                    Subtitle = subTitle,
                    Description = description,
                    BadgeNumber = 42
                };

                LocalNotificationCenter.Current.Show(request);
            }
            else
            {
                var request = new NotificationRequest
                {
                    NotificationId = 1337,
                    Title = name,
                    Description = description,
                    BadgeNumber = 42
                };

                LocalNotificationCenter.Current.Show(request);
            }
        }
    }
}
