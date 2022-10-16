using FlashCards.App.Interfaces;
using FlashCards.App.Models.Users;
using FlashCards.App.Utils;
using FlashCards.App.ViewModels.Users;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlashCards.App.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<User> GetUserByID(int userID)
        {
            var url = AppSettings.URL + "Users/" + userID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<User>(response);

            return result;
        }

        public async Task<UserRelationship> GetUserRelationshipByID(int userID, int relationshipID)
        {
            var url = AppSettings.URL + "Users/" + userID + "/Relationship/" + relationshipID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<UserRelationship>(response);

            return result;
        }

        public async Task<IEnumerable<UserRelationship>> GetAllUsers(int userID)
        {
            var url = AppSettings.URL + "Users/All/" + userID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<UserRelationship>>(response);

            return result;
        }

        public async Task<IEnumerable<UserRelationship>> GetFollowers(int userID)
        {
            var url = AppSettings.URL + "Users/Followers/" + userID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<UserRelationship>>(response);

            return result;
        }

        public async Task<IEnumerable<UserRelationship>> GetFollowing(int userID)
        {
            var url = AppSettings.URL + "Users/Following/" + userID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<UserRelationship>>(response);

            return result;
        }

        public async Task EditProfile(MyProfileViewModel data)
        {
            var url = AppSettings.URL + "Users";
            var response = await PutAsync(url, data);

            await HandlerErrorAsync(response);
        }

        public async Task DenounceProfile(ProfileDenounceViewModel data)
        {
            var url = AppSettings.URL + "Denunciations";
            var response = await PostAsync(url, data);

            await HandlerErrorAsync(response);
        }

        public async Task Follow(FollowUserDto data)
        {
            var url = AppSettings.URL + "Users/Follow";
            var response = await PutAsync(url, data);

            await HandlerErrorAsync(response);
        }

        public async Task Unfollow(UnfollowUserDto data)
        {
            var url = AppSettings.URL + "Users/Unfollow";
            var response = await PutAsync(url, data);

            await HandlerErrorAsync(response);
        }

        public async Task ChangeFollowNotification(FollowNotificationDto data)
        {
            var url = AppSettings.URL + "Users/EditNotificationFollowed";
            var response = await PutAsync(url, data);

            await HandlerErrorAsync(response);
        }

        public async Task AddOrEditNotificationSetting(AddOrEditNotificationSettingDto data)
        {
            var url = AppSettings.URL + "Users/AddOrEditNotificationSetting";
            var response = await PutAsync(url, data);

            await HandlerErrorAsync(response);
        }

        public async Task ChangeSubscriptionType(ChangeSubscriptionTypeDto data)
        {
            var url = AppSettings.URL + "Users/ChangeSubscription";
            var response = await PutAsync(url, data);

            await HandlerErrorAsync(response);
        }
    }
}
