using FlashCards.App.Models.Users;
using FlashCards.App.ViewModels.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Network
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfilePage : ContentPage
    {
        public MyProfilePage(User user)
        {
            InitializeComponent();
            
            var viewModel = Startup.ServiceProvider.GetService<MyProfileViewModel>();

            viewModel.SetInitialData(user);

            BindingContext = viewModel;
        }
    }
}