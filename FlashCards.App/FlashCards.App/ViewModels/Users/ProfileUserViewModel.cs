using FlashCards.App.Interfaces;
using FlashCards.App.Models.Users;
using FlashCards.App.Services;
using FlashCards.App.Views.FlashCards;
using FlashCards.App.Views.Network;
using System.Xml.Linq;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Users
{
    public class ProfileUserViewModel : BaseViewModel
    {
        private readonly IUserService _service;

        public UserRelationship User { get; private set; }
        public Command<UserRelationship> GoToFlashcardsPageCommand { get; }
        public Command<UserRelationship> GoToDenunciationPageCommand { get; }
        public Command FollowCommand { get; }
        public Command UnfollowCommand { get; }
        public Command EnableNotificationUserCommand { get; }
        public Command DisableNotificationUserCommand { get; }

        public ProfileUserViewModel(IUserService service)
        {
            _service = service;

            GoToFlashcardsPageCommand = new Command<UserRelationship>(GoToFlashcardsPage);
            GoToDenunciationPageCommand = new Command<UserRelationship>(GoToDenunciationPage);
            FollowCommand = new Command(Follow);
            UnfollowCommand = new Command(Unfollow);
            EnableNotificationUserCommand = new Command(EnableNotificationUser);
            DisableNotificationUserCommand = new Command(DisableNotificationUser);
        }

        private int _id;
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _instagram;
        public string Instagram
        {
            get => _instagram;
            set => SetProperty(ref _instagram, value);
        }

        private string _interests;
        public string Interests
        {
            get => _interests;
            set => SetProperty(ref _interests, value);
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

        private int _available;
        public int Available
        {
            get => _available;
            set => SetProperty(ref _available, value);
        }

        private int _stars;
        public int Stars
        {
            get => _stars;
            set => SetProperty(ref _stars, value);
        }

        private bool _isFollowed;
        public bool IsFollowed
        {
            get => _isFollowed;
            set => SetProperty(ref _isFollowed, value);
        }

        private bool _isEnableNotification;
        public bool IsEnableNotification
        {
            get => _isEnableNotification;
            set => SetProperty(ref _isEnableNotification, value);
        }

        private bool _notIsFollowed;
        public bool NotIsFollowed
        {
            get => _notIsFollowed;
            set => SetProperty(ref _notIsFollowed, value);
        }

        private bool _notIsEnableNotification;
        public bool NotIsEnableNotification
        {
            get => _notIsEnableNotification;
            set => SetProperty(ref _notIsEnableNotification, value);
        }

        public void SetInitialData(UserRelationship data)
        {
            User = data;

            ID = data.ID;
            Name = data.Name;
            Instagram = data.Instagram;
            Interests = data.Interests;
            Photo = data.Photo;
            Following = data.Following;
            Followers = data.Followers;
            Available = data.Available;
            Stars = data.Stars;
            IsFollowed = data.IsFollowed;
            IsEnableNotification = data.IsEnableNotification;
            NotIsFollowed = data.NotIsFollowed;
            NotIsEnableNotification = data.NotIsEnableNotification;
        }

        private void GoToFlashcardsPage(UserRelationship data)
        {
            Navigation.PushAsync(new FlashCardsPage());
        }

        private void GoToDenunciationPage(UserRelationship user)
        {
            Navigation.PushAsync(new ProfileDenouncePage(user));
        }

        private async void Follow()
        {
            var data = new FollowUserDto(
                followedID: ID,
                followerID: UserID);

            await _service.Follow(data);

            User.Follow();

            SetInitialData(User);
        }

        private async void Unfollow()
        {
            var data = new UnfollowUserDto(
                unfollowedID: ID,
                followerID: UserID);

            await _service.Unfollow(data);

            User.Unfollow();

            SetInitialData(User);
        }

        private async void EnableNotificationUser()
        {
            var data = new FollowNotificationDto(
                followedID: ID,
                followerID: UserID,
                enableNotification: true);

            await _service.ChangeFollowNotification(data);

            User.EnableNotificationUser();

            SetInitialData(User);
        }

        private async void DisableNotificationUser()
        {
            var data = new FollowNotificationDto(
                followedID: ID,
                followerID: UserID,
                enableNotification: false);

            await _service.ChangeFollowNotification(data);

            User.DisableNotificationUser();

            SetInitialData(User);
        }
    }
}
