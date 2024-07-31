namespace Notification_APP.Utils
{
    internal class Permission
    {
        async public static void CheckPermission()
        {
            try
            {
                string operatingSystem = DeviceInfo.Current.Platform.ToString();

                PermissionStatus vibrateStatus;
                PermissionStatus speechStatus;
                PermissionStatus phoneStatus;

                switch (operatingSystem)
                {
                    case "Android":
                        vibrateStatus = await Permissions.CheckStatusAsync<Permissions.Vibrate>();

                        if (vibrateStatus == PermissionStatus.Denied)
                        {
                            await Permissions.RequestAsync<Permissions.Vibrate>();
                        }

                        break;

                    case "iOS":
                        speechStatus = await Permissions.CheckStatusAsync<Permissions.Speech>();
                        phoneStatus = await Permissions.CheckStatusAsync<Permissions.Phone>();

                        if (speechStatus == PermissionStatus.Denied)
                        {
                            await Permissions.RequestAsync<Permissions.Speech>();
                        }
                        else if (phoneStatus == PermissionStatus.Denied)
                        {
                            await Permissions.RequestAsync<Permissions.Phone>();
                        }

                        break;

                    default:
                        return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
