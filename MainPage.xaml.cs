using Notification_APP.Utils;
using Notification_APP.Utils.Database;

namespace Notification_APP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void CreateNotificationBtn(object sender, EventArgs args)
        {
            CreateNotification.CreateNewNotification("test", DateTime.Now);
            UpdateHelper.UpdatePropeties();
        }
    }
}
