using Plugin.LocalNotification;

namespace Notification_APP.Utils
{
    internal class LocalNotification
    {
        public static void LaunchNotification(string title, string description, string? subTitle = null)
        {
            if (subTitle != null)
            {
                NotificationRequest request = new NotificationRequest
                {
                    NotificationId = 1337,
                    Title = title,
                    Subtitle = subTitle,
                    Description = description,
                    BadgeNumber = 42
                };

                LocalNotificationCenter.Current.Show(request);
            }
            else
            {
                NotificationRequest request = new NotificationRequest
                {
                    NotificationId = 1337,
                    Title = title,
                    Description = description,
                    BadgeNumber = 42
                };

                LocalNotificationCenter.Current.Show(request);
            }
        }
    }
}
