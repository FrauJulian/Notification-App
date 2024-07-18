
using CommunityToolkit.Mvvm.ComponentModel;

namespace Notification_APP.ViewModel
{
    internal partial class NotificationItems : ObservableObject
    {
        [ObservableProperty]
        public long id;

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string description;

        [ObservableProperty]
        public string timestamp;
    }
}
