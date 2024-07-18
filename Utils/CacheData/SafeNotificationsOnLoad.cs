namespace Notification_APP.Utils.CacheData
{
    internal class SafeCache
    {
        public static void SafeNotificationsOnLoad(object data)
        {
            string cacheFile = Path.Combine(FileSystem.Current.CacheDirectory, "Notifications.json");

            if (File.Exists(cacheFile))
            {
                File.Delete(cacheFile);
                File.WriteAllText(cacheFile, data.ToString());
            }
            else
            {
                File.WriteAllText(cacheFile, data.ToString());
            }
        }
    }
}
