using FlashCards.App.ViewModels.Network;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Network
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFollowersPage : ContentPage
    {
        public MyFollowersPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<MyFollowersViewModel>();
        }
    }
}