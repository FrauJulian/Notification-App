using Notification_APP.Utils;
using Notification_APP.Utils.CacheData;
using Notification_APP.Utils.Database;
using Notification_APP.Listener;

namespace Notification_APP
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            TableExists.CheckIfTableExist();
            SafeCache.SafeNotificationsOnLoad(LoadNotification.LoadNotificationsDatabase());

            var timer = new System.Threading.Timer((e) =>
            {
                NotificationListener.CheckNotificaiton();
            }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            SafeCache.SafeNotificationsOnLoad(LoadNotification.LoadNotificationsDatabase());

            CounterBtn.Text = "yee";

            DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }

}
