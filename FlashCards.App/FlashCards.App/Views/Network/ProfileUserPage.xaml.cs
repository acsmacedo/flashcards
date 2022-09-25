using FlashCards.App.Views.FlashCards;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Network
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileUser : ContentPage
    {
        public ProfileUser()
        {
            InitializeComponent();
        }


        private void GoToDenunciationPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfileDenouncePage());
        }

        private void GoToFlashcardsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FlashCardsPage());
        }
    }
}