
using CommunityToolkit.Mvvm.ComponentModel;

namespace Notification_APP.Model
{
    public partial class Item : ObservableObject
    {
        [ObservableProperty]
        public required double id;

        [ObservableProperty]
        public required string title;

        [ObservableProperty]
        public string? description;

        [ObservableProperty]
        public required string timestamp;
    }
}
