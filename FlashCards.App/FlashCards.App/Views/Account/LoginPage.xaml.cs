using FlashCards.App.ViewModels.Accounts;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginAccountViewModel _viewModel;

        public LoginPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = Startup.ServiceProvider.GetService<LoginAccountViewModel>();
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await _viewModel.ConfirmExitApp();

                if (result)
                    Process.GetCurrentProcess().CloseMainWindow();
            });

            return true;
        }
    }
}