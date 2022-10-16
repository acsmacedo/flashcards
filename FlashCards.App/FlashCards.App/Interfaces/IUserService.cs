using FlashCards.App.Models.Users;
using FlashCards.App.ViewModels.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlashCards.App.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByID(int userID);
        Task<UserRelationship> GetUserRelationshipByID(int userID, int relationshipID);
        Task<IEnumerable<UserRelationship>> GetAllUsers(int userID);
        Task<IEnumerable<UserRelationship>> GetFollowers(int userID);
        Task<IEnumerable<UserRelationship>> GetFollowing(int userID);

        Task EditProfile(MyProfileViewModel data);

        Task Follow(FollowUserDto data);
        Task Unfollow(UnfollowUserDto data);
        Task ChangeFollowNotification(FollowNotificationDto data);

        Task ChangeSubscriptionType(ChangeSubscriptionTypeDto data);
        Task AddOrEditNotificationSetting(AddOrEditNotificationSettingDto data);
        Task DenounceProfile(ProfileDenounceViewModel data);
    }
}
