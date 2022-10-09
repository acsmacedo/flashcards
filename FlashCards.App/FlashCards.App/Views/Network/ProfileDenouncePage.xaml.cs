using FlashCards.App.Models.Users;
using FlashCards.App.ViewModels.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Network
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileDenouncePage : ContentPage
    {
        public ProfileDenouncePage(UserRelationship user)
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<ProfileDenounceViewModel>();

            viewModel.SetInitialData(user);

            BindingContext = viewModel;
        }
    }
}