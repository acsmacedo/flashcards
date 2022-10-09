using FlashCards.App.ViewModels.Network;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Network
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFollowedsPage : ContentPage
    {
        public MyFollowedsPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<MyFollowedsViewModel>();
        }
    }
}