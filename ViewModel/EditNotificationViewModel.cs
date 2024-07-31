using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Notification_APP.Mapper;
using Notification_APP.Model;
using Notification_APP.Utils.Database;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Notification_APP.ViewModel
{
    internal partial class EditNotificationViewModel : ObservableObject
    {
        public ObservableCollection<Item>? Items
        {
            get => ItemList.Instance.Items;
            set => SetProperty(ref ItemList.Instance.Items, value);
        }

        [RelayCommand]
        public void ShowEditNotificationPopup()
        {
            var popup = new EditNotificationPopup();
            Shell.Current.CurrentPage.ShowPopup(popup);

        }

        public void UpdatEditNotification(string valueName, string value, double id)
        {
            //Code...

            Items.Clear();

            var JsonDataArray = LoadNotifications.LoadNotificationsDatabase();

            if (
                JsonDataArray == String.Empty ||
                JsonDataArray == "[]" ||
                JsonDataArray == ""
                ) return;

            var newItems = new List<Item>();

            newItems = MapData.MapJsonArray(JsonDataArray);

            foreach (var item in newItems)
            {
                Items.Add(item);
            }

            foreach (var item in Items)
            {
                string[] timestamp = item.Timestamp.Split(" ", 5);
                item.Timestamp = $"am {timestamp[0]} {timestamp[1]} {timestamp[2]} {timestamp[3]} um {timestamp[4]} Uhr";
            }

            foreach (var item in Items)
            {
                item.Description ??= "Keine Angabe!";
            }
        }
    }
}
