using FlashCards.App.Views.Account;
using FlashCards.App.Views.Network;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void GoToPrivacyAndSecurityPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPrivacyAndSecurityPage());
        }

        private void GoToNotificationPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsNotificationPage());
        }

        private void GoToSubscriptionPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsSubscriptionPage());
        }

        private void GoToMyProfilePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyProfilePage());
        }

        private void GoToMyFollowersPage(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new MyFollowersPage());
            Navigation.PushAsync(new NetworkPage());
        }

        private void GoToMyFollowedsPage(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new MyFollowedsPage());
            Navigation.PushAsync(new NetworkPage());
        }

        private async void Logout(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Desconectar?", "Deseja sair da sua conta?", "Sim", "Não");

            if (answer)
            {
                Application.Current.Properties.Remove("user_id");
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
