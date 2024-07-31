using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Notification_APP.ViewModel;
using Plugin.LocalNotification;

namespace Notification_APP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()

                .UseLocalNotification()
                .UseMauiCommunityToolkit()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<NotificationViewModel>();

            builder.Services.AddSingleton<CreateNotificationPopup>();
            builder.Services.AddSingleton<CreateNotificationViewModel>();

            builder.Services.AddSingleton<EditNotificationPopup>();
            builder.Services.AddSingleton<EditNotificationViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
