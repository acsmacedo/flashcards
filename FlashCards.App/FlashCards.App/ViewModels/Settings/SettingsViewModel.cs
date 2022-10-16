using FlashCards.App.Interfaces;
using FlashCards.App.Models.Users;
using FlashCards.App.Views.Network;
using FlashCards.App.Views.Settings;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public User User { get; private set; }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _photo;
        public string Photo
        {
            get => _photo;
            set => SetProperty(ref _photo, value);
        }

        private int _following;
        public int Following
        {
            get => _following;
            set => SetProperty(ref _following, value);
        }

        private int _followers;
        public int Followers
        {
            get => _followers;
            set => SetProperty(ref _followers, value);
        }

        public Command GoToPrivacyAndSecurityPageCommand { get; }
        public Command GoToNotificationPageCommand { get; }
        public Command GoToSubscriptionPageCommand { get; }
        public Command GoToMyProfilePageCommand { get; }
        public Command GoToMyFollowersPageCommand { get; }
        public Command GoToMyFollowedsPageCommand { get; }
        public Command LogoutCommand { get; }

        public SettingsViewModel(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;

            GoToPrivacyAndSecurityPageCommand = new Command(GoToPrivacyAndSecurityPage);
            GoToNotificationPageCommand = new Command(GoToNotificationPage);
            GoToSubscriptionPageCommand = new Command(GoToSubscriptionPage);
            GoToMyProfilePageCommand = new Command(GoToMyProfilePage);
            GoToMyFollowersPageCommand = new Command(GoToMyFollowersPage);
            GoToMyFollowedsPageCommand = new Command(GoToMyFollowedsPage);
            LogoutCommand = new Command(Logout);
        }

        public void OnAppearing() => GetUser();

        private async void GetUser()
        {
            User = await _userService.GetUserByID(UserID);

            Name = User.Name;
            Photo = User.Photo;
            Followers = User.Followers;
            Following = User.Following;
        }

        private void GoToPrivacyAndSecurityPage(object sender)
        {
            Navigation.PushAsync(new SettingsPrivacyAndSecurityPage());
        }

        private void GoToNotificationPage(object sender)
        {
            Navigation.PushAsync(new SettingsNotificationPage());
        }

        private void GoToSubscriptionPage(object sender)
        {
            Navigation.PushAsync(new SettingsSubscriptionPage());
        }

        private void GoToMyProfilePage(object sender)
        {
            Navigation.PushAsync(new MyProfilePage(User));
        }

        private void GoToMyFollowersPage(object sender)
        {
            Navigation.PushAsync(new NetworkPage(Network.NetworkViewMode.Followers));
        }

        private void GoToMyFollowedsPage(object sender)
        {
            Navigation.PushAsync(new NetworkPage(Network.NetworkViewMode.Followeds));
        }

        private async void Logout(object sender)
        {
            bool answer = await MainPage.DisplayAlert("Desconectar", "Deseja sair da sua conta?", "Sim", "Não");

            if (answer)
                await _accountService.Logout();
        }
    }
}
