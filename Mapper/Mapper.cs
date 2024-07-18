using CommunityToolkit.Mvvm.ComponentModel;
using Notification_APP.ViewModel;

namespace Notification_APP.Mapper
{
    internal partial class Mapper : ObservableObject
    {
        [ObservableProperty]
        public IList<NotificationItems> items;

        public static List<NotificationItems> Map()
        {
            List<NotificationItems> list = new List<NotificationItems>
            {
                new NotificationItems { },
            };

            return list;
        }
    }
}
