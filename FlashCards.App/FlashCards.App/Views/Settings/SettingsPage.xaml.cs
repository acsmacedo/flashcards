using FlashCards.App.ViewModels.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private SettingsViewModel _viewModel;

        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = Startup.ServiceProvider.GetService<SettingsViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
