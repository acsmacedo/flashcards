using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login(object sender, EventArgs e)
        {
            Application.Current.Properties["user_id"] = -2;
            Application.Current.MainPage = new AppShell();
        }

        private void GoToCreateAccountPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateAccountPage());
        }
    }
}