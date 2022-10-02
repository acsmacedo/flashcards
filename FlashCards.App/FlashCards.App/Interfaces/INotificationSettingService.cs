using FlashCards.App.Models.NotificationSettings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlashCards.App.Interfaces
{
    public interface INotificationSettingService
    {
        Task<IEnumerable<NotificationSettingByUser>> GetNotificationSettingsByUser(int userID);
    }
}
