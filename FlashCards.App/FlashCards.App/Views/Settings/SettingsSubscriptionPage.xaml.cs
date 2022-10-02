using FlashCards.App.ViewModels.SubscriptionTypes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsSubscriptionPage : ContentPage
    {
        public SettingsSubscriptionPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<SubscriptionTypesViewModel>();
        }
    }
}
