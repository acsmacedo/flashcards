using FlashCards.Api.Service.DTO.Notifications;

namespace FlashCards.Api.Service.Interfaces;

public interface INotificationService
{
    Task<IEnumerable<NotificationDto>> GetAllByUserIDAsync(int userID);
    Task<NotificationDto> GetByIDAsync(int notificationID);
    Task<int> CreateAsync(CreateNotificationDto data);
    Task ReadAsync(ReadNotificationDto data);
    Task DeleteAsync(DeleteNotificationDto data);
}
