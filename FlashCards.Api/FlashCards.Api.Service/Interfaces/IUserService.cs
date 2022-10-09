using FlashCards.Api.Service.DTO.Users;

namespace FlashCards.Api.Service.Interfaces;

public interface IUserService
{
    Task<UserDto> GetByIDAsync(int id);
    Task<IEnumerable<UserRelationshipDto>> GetAllAsync(int id);
    Task<IEnumerable<UserRelationshipDto>> GetFollowingAsync(int id);
    Task<IEnumerable<UserRelationshipDto>> GetFollowersAsync(int id);

    Task EditAsync(EditUserDto data);

    Task FollowAsync(FollowDto data);
    Task UnfollowAsync(UnfollowDto data);
    Task EditNotificationFollowedAsync(FollowNotificationDto data);

    Task ChangeSubscriptionType(ChangeSubscriptionTypeDto data);
    Task AddOrEditNotificationSetting(AddOrEditNotificationSettingDto data);
}
