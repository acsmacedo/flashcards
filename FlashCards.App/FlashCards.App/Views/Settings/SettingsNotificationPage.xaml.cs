using FlashCards.App.ViewModels.NotificationSettings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsNotificationPage : ContentPage
    {
        public SettingsNotificationPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<NotificationSettingsViewModel>();
        }
    }
}
