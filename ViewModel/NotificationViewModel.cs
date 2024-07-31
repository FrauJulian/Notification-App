using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Notification_APP.Utils.Database;
using Notification_APP.Model;
using Notification_APP.Utils;
using Notification_APP.Mapper;

namespace Notification_APP.ViewModel
{
    internal partial class NotificationViewModel : ObservableObject
    {
        public ObservableCollection<Item>? Items
        {
            get => ItemList.Instance.Items;
            set => SetProperty(ref ItemList.Instance.Items, value);
        }

        public NotificationViewModel()
        {
            Items = new ObservableCollection<Item>();

            Permission.CheckPermission();
            CheckTable.CheckIfTableExist();
            RegisterListeners.RegisterDateTimeListener();

            GenerateListOnStart();
        }

        public void GenerateListOnStart()
        {
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
