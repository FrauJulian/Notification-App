using Notification_APP.Listener;

namespace Notification_APP.Utils
{
    internal class RegisterListeners
    {
        async public static void NotificationListener()
        {
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
            while (await timer.WaitForNextTickAsync())
            {
                Listeners.CheckNotificaiton();
            }
        }
    }
}
