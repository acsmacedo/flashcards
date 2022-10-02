using FlashCards.App.ViewModels.Accounts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage()
        {
            InitializeComponent();

            BindingContext = Startup.ServiceProvider.GetService<SignUpAccountViewModel>();
        }
    }
}
