using Notification_APP.Listener;

namespace Notification_APP.Utils
{
    internal class RegisterListeners
    {
        async public static void RegisterDateTimeListener()
        {
            var periodicTimer = new PeriodicTimer(TimeSpan.FromMinutes(1));
            while (await periodicTimer.WaitForNextTickAsync())
            {
                Listeners.CheckIfDateTimeIsBiggerThanNow();
            }
        }
    }
}
