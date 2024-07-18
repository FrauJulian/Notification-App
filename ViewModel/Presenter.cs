using CommunityToolkit.Mvvm.ComponentModel;
using Notification_APP.Utils;
using Newtonsoft.Json;
using Notification_APP.Utils.CacheData;
using Notification_APP.Utils.Database;
using System.Collections.ObjectModel;
using Notification_APP.Utils.Timestamp;
using Notification_APP.Mapper;

namespace Notification_APP.ViewModel
{
    internal partial class Presenter : ObservableObject
    {
        [ObservableProperty]
        public IList<NotificationItems> items;

        public Presenter()
        {
            
            items = new ObservableCollection<NotificationItems>();
            InitizializePresenter();

            CheckTable.CheckIfTableExist();
            SafeCache.SafeNotificationsOnLoad(LoadNotifications.LoadNotificationsDatabase());
        }

        public void InitizializePresenter()
        {
            if (LoadCache.LoadNotificationCache() != String.Empty &&
                LoadCache.LoadNotificationCache() != "{}")
            {
                items = JsonConvert.DeserializeObject<List<NotificationItems>>(LoadCache.LoadNotificationCache());

                foreach (var item in items)
                {
                    string[] timestamp = item.Timestamp.Split(" ", 2);
                    item.Timestamp = "am " + timestamp[0] + " um " + timestamp[1] + " Uhr";

                    item.Description = "Keine Angabe!";
                }
            }
        }
    }
}
