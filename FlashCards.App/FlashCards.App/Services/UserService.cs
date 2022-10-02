using FlashCards.App.Interfaces;
using FlashCards.App.Utils;
using FlashCards.App.ViewModels.Users;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlashCards.App.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
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
