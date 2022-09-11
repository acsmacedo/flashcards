using FlashCards.Api.Service.DTO.Categories;
using FlashCards.Api.Service.DTO.Notifications;

namespace FlashCards.Api.Service.Interfaces;

public interface INotificationService
{
    Task<IEnumerable<NotificationDto>> GetAllByUserIDAsync(int userID);
    Task CreateAsync(CreateNotificationDto data);
    Task ReadAsync(ReadNotificationDto data);
}
