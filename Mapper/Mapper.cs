using Newtonsoft.Json.Linq;
using Notification_APP.Model;

namespace Notification_APP.Mapper
{
    internal class MapData
    {
        public static List<Item> MapJsonArray(string jsonArray)
        {
            if (string.IsNullOrEmpty(jsonArray))
            {
                return new List<Item>();
            }

            try
            {
                var items = new List<Item>();
                var array = JArray.Parse(jsonArray);

                foreach (var jsonItem in array)
                {
                    var item = jsonItem.ToObject<Item>();
                    if (item != null)
                    {
                        items.Add(item);
                    }
                }

                return items;
            }
            catch (Exception ex)
            {
                return new List<Item>();
            }
        }
    }
}
