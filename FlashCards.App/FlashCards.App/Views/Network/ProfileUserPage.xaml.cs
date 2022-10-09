using FlashCards.App.Models.Users;
using FlashCards.App.ViewModels.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Network
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileUser : ContentPage
    {
        public ProfileUser(UserRelationship user)
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<ProfileUserViewModel>();

            viewModel.SetInitialData(user);

            BindingContext = viewModel;
        }
    }
}