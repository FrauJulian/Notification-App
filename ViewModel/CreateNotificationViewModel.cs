using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Notification_APP.Model;
using System.Collections.ObjectModel;

namespace Notification_APP.ViewModel
{
    internal partial class CreateNotificationViewModel : ObservableObject
    {
        [RelayCommand]
        public void ShowCreateNotificationPopup()
        {
            var popup = new CreateNotificationPopup();
            Shell.Current.CurrentPage.ShowPopup(popup);
        }
    }
}
