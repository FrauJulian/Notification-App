using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification_APP.Utils.CacheData
{
    internal class LoadCache
    {
        public static string[] LoadNotificationCache(string[] data)
        {
            var cacheFile = Path.Combine(FileSystem.Current.CacheDirectory, "Notifications.json");
            if (File.Exists(cacheFile))
            {
                string Content = File.ReadAllText(cacheFile);
                return [Content]; 
            }

            return [];
        }
    }
}
