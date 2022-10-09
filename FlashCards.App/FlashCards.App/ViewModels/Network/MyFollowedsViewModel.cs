using FlashCards.App.Interfaces;
using FlashCards.App.Models.Users;
using FlashCards.App.ViewModels.Users;
using FlashCards.App.Views.Network;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Network
{
    public class MyFollowedsViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        public ObservableCollection<UserRelationship> Items { get; }
        public Command<UserRelationship> FollowCommand { get; }
        public Command<UserRelationship> UnfollowCommand { get; }
        public Command<UserRelationship> EnableNotificationCommand { get; }
        public Command<UserRelationship> DisableNotificationCommand { get; }
        public Command<UserRelationship> GoToProfileUserPageCommand { get; }
        public Command LoadItemsCommand { get; }

        public MyFollowedsViewModel(IUserService userService)
        {
            _userService = userService;

            Items = new ObservableCollection<UserRelationship>();

            LoadItems();

            LoadItemsCommand = new Command(LoadItems);
            FollowCommand = new Command<UserRelationship>(Follow);
            UnfollowCommand = new Command<UserRelationship>(Unfollow);
            EnableNotificationCommand = new Command<UserRelationship>(EnableNotification);
            DisableNotificationCommand = new Command<UserRelationship>(DisableNotification);
            FollowCommand = new Command<UserRelationship>(Follow);
            GoToProfileUserPageCommand = new Command<UserRelationship>(GoToProfileUserPage);
        }

        public async void LoadItems()
        {
            Items.Clear();

            var items = await _userService.GetFollowing(UserID);

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private async void Follow(UserRelationship user)
        {
            var data = new FollowUserDto(
                followedID: user.ID,
                followerID: UserID);

            await _userService.Follow(data);

            Items.Single(x => x.ID == user.ID).Follow();
        }

        private async void Unfollow(UserRelationship user)
        {
            var data = new UnfollowUserDto(
                unfollowedID: user.ID,
                followerID: UserID);

            await _userService.Unfollow(data);

            var item = Items.Single(x => x.ID == user.ID);

            item.Unfollow();

            Items.Remove(item);
        }

        private async void EnableNotification(UserRelationship user)
        {
            var data = new FollowNotificationDto(
                followedID: user.ID,
                followerID: UserID,
                enableNotification: true);

            await _userService.ChangeFollowNotification(data);

            Items.Single(x => x.ID == user.ID).EnableNotificationUser();
        }

        private async void DisableNotification(UserRelationship user)
        {
            var data = new FollowNotificationDto(
                followedID: user.ID,
                followerID: UserID,
                enableNotification: false);

            await _userService.ChangeFollowNotification(data);

            Items.Single(x => x.ID == user.ID).DisableNotificationUser();
        }

        private void GoToProfileUserPage(UserRelationship user)
        {
            Navigation.PushAsync(new ProfileUser(user));
        }
    }
}
