using CommunityToolkit.Mvvm.ComponentModel;

namespace Notification_APP.Model
{
    internal partial class CreateNotificationItems : ObservableObject
    {
        [ObservableProperty]
        public string? title;

        [ObservableProperty]
        public string? description;

        [ObservableProperty]
        public DateTime? date;

        [ObservableProperty]
        public TimeSpan? time;
    }
}
