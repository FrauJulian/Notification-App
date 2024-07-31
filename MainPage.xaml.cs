using Notification_APP.ViewModel;

namespace Notification_APP
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            this.BindingContext = new NotificationViewModel();
            InitializeComponent();
        }
        
        private void OnCollectionViewSelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            //DisplayAlert("hallo", e.SelectedItem.ToString(), "NO");
        }
    }
}
