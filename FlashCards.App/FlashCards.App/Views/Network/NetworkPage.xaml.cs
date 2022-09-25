using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Network
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NetworkPage : ContentPage
    {
        public NetworkPage()
        {
            InitializeComponent();
            _collection.ItemsSource = GenerateUsers(20);
        }

        private async void Follow(object sender, EventArgs e)
        {
            await DisplayAlert("Seguir usuário", "Você está seguindo o usuário: Nome do usuário", "Ok");
        }

        private async void UnFollow(object sender, EventArgs e)
        {
            await DisplayAlert("Deixar de seguir usuário", "Você está deixour de seguir o usuário: Nome do usuário", "Ok");
        }

        private async void EnableNotification(object sender, EventArgs e)
        {
            await DisplayAlert("Notificações", "Você habilitou as notificãções do usuário: Nome do usuário", "Ok");
        }

        private async void DisableNotification(object sender, EventArgs e)
        {
            await DisplayAlert("Notificações", "Você desabilitou as notificãções do usuário: Nome do usuário", "Ok");
        }

        private List<User> GenerateUsers(int qty)
        {
            var benefits = new List<User>();
            for (var i = 0; i < qty; i++)
            {
                benefits.Add(new User(
                    name: "Usuário " + i,
                    instagram: "@usuario" + i,
                    isFollwed: i % 2 == 0,
                    isEnableNotification: i < 7 && i % 2 == 0));
            }

            return benefits;
        }

        private void GoToProfileUserPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfileUser());
        }
    }

    public class User
    {
        public string Name { get; private set; }
        public string Instagram { get; private set; }
        public bool IsFollwed { get; private set; }
        public bool IsEnableNotification { get; private set; }

        public bool NotIsFollwed => !IsFollwed;
        public bool NotIsEnableNotification => IsFollwed && !IsEnableNotification;

        public User(string name, string instagram, bool isFollwed, bool isEnableNotification)
        {
            Name = name;
            Instagram = instagram;
            IsFollwed = isFollwed;
            IsEnableNotification = isEnableNotification;
        }
    }
}
