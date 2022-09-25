using System;
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
        }

        private void Login(object sender, EventArgs e)
        {
            Application.Current.Properties["user_id"] = -2;
            Application.Current.MainPage = new AppShell();
        }

        private void GoToTermsAndConditions(object sender, EventArgs e)
        {
            
        }
    }
}