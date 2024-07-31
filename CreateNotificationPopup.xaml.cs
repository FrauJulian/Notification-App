using CommunityToolkit.Maui.Views;
using Notification_APP.ViewModel;

namespace Notification_APP;

public partial class CreateNotificationPopup : Popup
{
    private string title;
    private string? description;
    private DateTime date;
    private TimeSpan time;
    private readonly NotificationUtils notificationUtils;

    public CreateNotificationPopup()
	{
		InitializeComponent();
        notificationUtils = new NotificationUtils();
    }

    private void CreateNotificationButton(object sender, EventArgs e)
    {
        title = TitleEntry.Text;
        description = DescriptionEntry.Text;
        date = DatePicker.Date;
        time = TimePicker.Time;

        DateTime combinedDateTime = date + time;

        notificationUtils.UpdateCreateNewNotification(title, combinedDateTime, description);

        this.Close();
    }
}