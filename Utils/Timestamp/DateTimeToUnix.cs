namespace Notification_APP.Utils.Timestamp
{
    internal class DateTimeToUnix
    {
        public static long GetUnixTimestamp(DateTime dateTime)
        {
            DateTimeOffset unixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            long unixTimestamp = (long)(dateTime.ToUniversalTime() - unixEpoch).TotalSeconds;
            return unixTimestamp;
        }
    }
}
