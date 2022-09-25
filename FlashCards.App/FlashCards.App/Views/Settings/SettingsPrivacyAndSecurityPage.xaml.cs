using FlashCards.App.Views.Account;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPrivacyAndSecurityPage : ContentPage
    {
        public SettingsPrivacyAndSecurityPage()
        {
            InitializeComponent();
        }

        private void GoToChangePasswordPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage());
        }

        private async void CancelAccountAction(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("O que você deseja fazer?", "Cancelar", null, "Excluir conta", "Desativar conta");
            
        }

        private void Expander_Tapped(object sender, EventArgs e)
        {

        }
    }
}