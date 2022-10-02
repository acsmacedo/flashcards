using FlashCards.App.Interfaces;
using FlashCards.App.Models.NotificationSettings;
using FlashCards.App.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlashCards.App.Services
{
    public class NotificationSettingService : BaseService, INotificationSettingService
    {
        public NotificationSettingService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IEnumerable<NotificationSettingByUser>> GetNotificationSettingsByUser(int userID)
        {
            var url = AppSettings.URL + "NotificationSettings/User/" + userID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<NotificationSettingByUser>>(response);

            return result;
        }
    }
}
