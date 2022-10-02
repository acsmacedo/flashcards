using FlashCards.App.Interfaces;
using FlashCards.App.Models.SubscriptionTypes;
using FlashCards.App.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlashCards.App.Services
{
    public class SubscriptionTypeService : BaseService, ISubscriptionTypeService
    {
        public SubscriptionTypeService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IEnumerable<SubscriptionTypeByUser>> GetSubscriptionTypesByUser(int userID)
        {
            var url = AppSettings.URL + "SubscriptionTypes/User/" + userID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<SubscriptionTypeByUser>>(response);

            return result;
        }
    }
}
