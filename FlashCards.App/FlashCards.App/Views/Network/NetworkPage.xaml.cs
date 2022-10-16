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

            var viewModel = _viewModel = Startup.ServiceProvider.GetService<NetworkViewModel>();

            viewModel.SetInitialData(NetworkViewMode.All);

            BindingContext = _viewModel = viewModel;
        }

        public NetworkPage(NetworkViewMode mode)
        {
            InitializeComponent();

            var viewModel = _viewModel = Startup.ServiceProvider.GetService<NetworkViewModel>();

            viewModel.SetInitialData(mode);

            BindingContext = _viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
