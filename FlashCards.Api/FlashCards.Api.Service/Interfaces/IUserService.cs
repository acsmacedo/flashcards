using FlashCards.Api.Service.DTO.Users;

namespace FlashCards.Api.Service.Interfaces;

public interface IUserService
{
    Task<UserDto> GetByIDAsync(int id);
    Task FollowAsync(FollowDto data);
    Task UnfollowAsync(UnfollowDto data);
    Task EditNotificationFollowedAsync(FollowNotificationDto data);
    Task EditAsync(EditUserDto data);
}
