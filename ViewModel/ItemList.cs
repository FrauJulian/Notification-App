using CommunityToolkit.Mvvm.ComponentModel;
using Notification_APP.Model;
using System.Collections.ObjectModel;

namespace Notification_APP.ViewModel
{
    public class ItemList : ObservableObject
    {
        private static readonly ItemList _instance = new ItemList();

        public static ItemList Instance => _instance;

        public ObservableCollection<Item>? Items;

        private ItemList()
        {
            Items = new ObservableCollection<Item>();
        }
    }
}