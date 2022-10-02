using FlashCards.Api.Core.Users;
using FlashCards.Api.Service.DTO.Users;

namespace FlashCards.Api.Service.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<UserDto> GetByIDAsync(int id)
    {
        var entity = _context.Users
            .Include(x => x.Followers)
                .ThenInclude(x => x.Follower)
            .Include(x => x.Following)
                .ThenInclude(x => x.Followed)
            .FirstOrDefault(x => x.ID == id);

        if (entity == null)
            throw new Exception("Usuário não encontrado.");

        var result = new UserDto(entity);

        return Task.FromResult(result);
    }

    public async Task EditAsync(EditUserDto data)
    {
        var entity = GetByID(data.ID);

        entity.Edit(
            name: data.Name, 
            instagram: data.Instagram, 
            interests: data.Interests);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public async Task EditNotificationFollowedAsync(FollowNotificationDto data)
    {
        var follower = GetByIDWithFollowings(data.FollowerID);

        follower.EditNotificationFollowed(data.FollowedID, data.EnableNotification);

        _context.Update(follower);

        await SaveChangesAsync();
    }

    public async Task FollowAsync(FollowDto data)
    {
        var follower = GetByIDWithFollowings(data.FollowerID);
        var followed = GetByID(data.FollowedID);

        follower.Follow(followed);

        _context.Update(follower);

        await SaveChangesAsync();
    }

    public async Task UnfollowAsync(UnfollowDto data)
    {
        var follower = GetByIDWithFollowings(data.FollowerID);
        var followed = GetByID(data.UnfollowedID);

        follower.Unfollow(followed);

        _context.Update(follower);

        await SaveChangesAsync();
    }


    public async Task ChangeSubscriptionType(ChangeSubscriptionTypeDto data)
    {
        var entity = GetByID(data.UserID);

        var subscriptionType = _context.SubscriptionTypes
            .FirstOrDefault(x => x.ID == data.SubscriptionTypeID);

        if (subscriptionType == null)
            throw new Exception("Tipo de assinatura não encontrado.");

        entity.ChangeSubscriptionType(data.SubscriptionTypeID);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public async Task AddOrEditNotificationSetting(AddOrEditNotificationSettingDto data)
    {
        var entity = GetByIDWithNotificationSettings(data.UserID);

        var notificationSetting = _context.NotificationSettings
            .FirstOrDefault(x => x.ID == data.NotificationSettingID);

        if (notificationSetting == null)
            throw new Exception("Tipo de notificação não encontrada.");

        entity.AddOrEditNotificationSettings(data.NotificationSettingID, data.Status);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    private User GetByID(int id)
    {
        var entity = _context.Users
            .FirstOrDefault(x => x.ID == id);

        if (entity != null)
            return entity;

        throw new Exception("Usuário não encontrado.");
    }

    private User GetByIDWithFollowings(int id)
    {
        var entity = _context.Users
            .Include(x => x.Following)
                .ThenInclude(x => x.Followed)
            .FirstOrDefault(x => x.ID == id);

        if (entity != null)
            return entity;

        throw new Exception("Usuário não encontrado.");
    }

    private User GetByIDWithNotificationSettings(int id)
    {
        var entity = _context.Users
            .Include(x => x.NotiicationSettings)
            .FirstOrDefault(x => x.ID == id);

        if (entity != null)
            return entity;

        throw new Exception("Usuário não encontrado.");
    }

    private async Task SaveChangesAsync()
    {
        var result = await _context.SaveChangesAsync();

        if (result <= 0)
            throw new Exception("Ocorreu um erro ao salvar os dados. Tente novamente.");
    }
}
