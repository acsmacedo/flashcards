using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsNotificationPage : ContentPage
    {
        public SettingsNotificationPage()
        {
            InitializeComponent();
        }

        private async void ChangeNotification(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet(
                "Alterar notificação", 
                "Cancelar", 
                null, 
                "E-mail", 
                "Notificação push",
                "SMS", 
                "Não notificar");
        }
    }
}