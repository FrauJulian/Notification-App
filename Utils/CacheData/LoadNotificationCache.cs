using Notification_APP.Utils.Database;
using Notification_APP.ViewModel;

namespace Notification_APP.Utils.CacheData
{
    internal class LoadCache
    {

        private static Presenter? _presenter;

        public static string LoadNotificationCache()
        {
            string cacheFile = Path.Combine(FileSystem.Current.CacheDirectory, "Notifications.json");
            if (File.Exists(cacheFile))
            {
                return File.ReadAllText(cacheFile); 
            }

            return String.Empty;
        }
    }
}
