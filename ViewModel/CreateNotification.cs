using CommunityToolkit.Mvvm.ComponentModel;
using Notification_APP.Model;
using Notification_APP.Utils.Database;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Notification_APP.ViewModel
{
    internal class NotificationUtils : ObservableObject
    {
        public ObservableCollection<Item>? Items
        {
            get => ItemList.Instance.Items;
            set => SetProperty(ref ItemList.Instance.Items, value);
        }

        public void UpdateCreateNewNotification(string title, DateTime time, string? description = null)
        {
            CultureInfo formatCulture = new CultureInfo("de-DE");
            string formattedDateTime = time.ToString("f", formatCulture);

            double id;
            Item notificationItem;

            if (title is null) return;
            if (time < DateTime.Now) return;

            if (description == null)
            {
                id = CreateNotification.CreateNewNotification(title, time);
                if (id is -0) return;

                notificationItem = new Item
                {
                    id = id,
                    title = title,
                    description = null,
                    timestamp = formattedDateTime
                };
            }
            else
            {
                id = CreateNotification.CreateNewNotification(title, time, description);
                if (id is -0) return;

                notificationItem = new Item
                {
                    id = id,
                    title = title,
                    description = description,
                    timestamp = formattedDateTime
                };
            }

            string[] timestamp = notificationItem.Timestamp.Split(" ", 5);
            notificationItem.Timestamp = $"am {timestamp[0]} {timestamp[1]} {timestamp[2]} {timestamp[3]} um {timestamp[4]} Uhr";

            notificationItem.Description ??= "Keine Angabe!";

            Items.Add(notificationItem);
        }
    }
}
