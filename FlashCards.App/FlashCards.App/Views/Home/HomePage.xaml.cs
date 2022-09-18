using FlashCards.App.Views.Account;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.Properties.Remove("user_id");
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}