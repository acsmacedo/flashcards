using FlashCards.Api.Service.DTO.NotificationSettings;

namespace FlashCards.Api.Service.Interfaces;

public interface INotificationSettingService
{
    Task<IEnumerable<NotificationSettingDto>> GetAllAsync();
    Task<IEnumerable<NotificationSettingByUserDto>> GetAllByUserAsync(int id);

    Task CreateAsync(CreateNotificationSettingDto data);
    Task EditAsync(EditNotificationSettingDto data);
    Task DeleteAsync(DeleteNotificationSettingDto data);
}
