using FlashCards.App.ViewModels.Network;
using System.Diagnostics;
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

        protected override bool OnBackButtonPressed()
        {
            if (Navigation.NavigationStack.Count > 1)
                return base.OnBackButtonPressed();

            Device.BeginInvokeOnMainThread(async () => {
                var result = await _viewModel.ConfirmExitApp();

                if (result)
                    Process.GetCurrentProcess().CloseMainWindow();
            });

            return true;
        }
    }
}
