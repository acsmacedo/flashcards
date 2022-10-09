using FlashCards.App.ViewModels.Network;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Network
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NetworkPage : ContentPage
    {
        private NetworkViewModel _viewModel;

        public NetworkPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = Startup.ServiceProvider.GetService<NetworkViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
