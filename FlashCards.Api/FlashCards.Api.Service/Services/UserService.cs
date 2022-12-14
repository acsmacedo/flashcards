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
            .Include(x => x.Directories)
                .ThenInclude(x => x.FlashCardCollections)
                    .ThenInclude(x => x.Ratings)
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

    public Task<UserRelationshipDto> GetUserRelationshipByIDAsync(int userID, int relationshipID)
    {
        var entity = GetByIDWithRelationship(userID);

        var data = _context.Users
            .Include(x => x.Directories)
                .ThenInclude(x => x.FlashCardCollections)
                    .ThenInclude(x => x.Ratings)
            .Include(x => x.Followers)
                .ThenInclude(x => x.Follower)
            .Include(x => x.Following)
                .ThenInclude(x => x.Followed)
            .FirstOrDefault(x => x.ID == relationshipID);

        if (data == null)
            throw new Exception("Usuário não encontrado.");

        var result = new UserRelationshipDto(data, entity);

        return Task.FromResult(result);
    }

    public Task<IEnumerable<UserRelationshipDto>> GetAllAsync(int id)
    {
        var entity = GetByIDWithRelationship(id);

        var data = _context.Users
            .Include(x => x.Directories)
                .ThenInclude(x => x.FlashCardCollections)
                    .ThenInclude(x => x.Ratings)
            .Include(x => x.Followers)
                .ThenInclude(x => x.Follower)
            .Include(x => x.Following)
                .ThenInclude(x => x.Followed)
            .Where(x => x.ID != id);

        var result = data.Select(x => new UserRelationshipDto(x, entity));

        return Task.FromResult(result.AsEnumerable());
    }

    public Task<IEnumerable<UserRelationshipDto>> GetFollowingAsync(int id)
    {
        var entity = GetByIDWithRelationship(id);

        var data = _context.Users
            .Include(x => x.Directories)
                .ThenInclude(x => x.FlashCardCollections)
                    .ThenInclude(x => x.Ratings)
            .Include(x => x.Followers)
                .ThenInclude(x => x.Follower)
            .Include(x => x.Following)
                .ThenInclude(x => x.Followed)
            .Where(x => x.Followers.Any(y => y.FollowerID == id));

        var result = data.Select(x => new UserRelationshipDto(x, entity));

        return Task.FromResult(result.AsEnumerable());
    }

    public Task<IEnumerable<UserRelationshipDto>> GetFollowersAsync(int id)
    {
        var entity = GetByIDWithRelationship(id);

        var data = _context.Users
            .Include(x => x.Directories)
                .ThenInclude(x => x.FlashCardCollections)
                    .ThenInclude(x => x.Ratings)
            .Include(x => x.Followers)
                .ThenInclude(x => x.Follower)
            .Include(x => x.Following)
                .ThenInclude(x => x.Followed)
            .Where(x => x.Following.Any(y => y.FollowedID == id));

        var result = data.Select(x => new UserRelationshipDto(x, entity));

        return Task.FromResult(result.AsEnumerable());
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

    public async Task ChangeSubscriptionTypeAsync(ChangeSubscriptionTypeDto data)
    {
        var subscriptionType = _context.SubscriptionTypes
            .FirstOrDefault(x => x.ID == data.SubscriptionTypeID);

        if (subscriptionType == null)
            throw new Exception("Tipo de assinatura não encontrado.");

        var entity = GetByID(data.UserID);

        entity.ChangeSubscriptionType(data.SubscriptionTypeID);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public async Task AddOrEditNotificationSettingAsync(AddOrEditNotificationSettingDto data)
    {
        var notificationSetting = _context.NotificationSettings
            .FirstOrDefault(x => x.ID == data.NotificationSettingID);

        if (notificationSetting == null)
            throw new Exception("Tipo de notificação não encontrada.");

        var entity = GetByIDWithNotificationSettings(data.UserID);

        entity.AddOrEditNotificationSettings(data.NotificationSettingID, data.Status);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public async Task UpdatePhotoAsync(UpdateUserPhotoDto data)
    {
        var file = data.File.First();
        var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\photos");
        var fileName = "photo-" + data.UserID + "." + file.FileName.Split(".").Last();
        var filePath = Path.Combine(fileDirectory, fileName);

        if (!Directory.Exists(fileDirectory))
            Directory.CreateDirectory(fileDirectory);

        using var memoryStream = new MemoryStream();

        await file.CopyToAsync(memoryStream);
        var info = memoryStream.ToArray();

        using FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate);

        fileStream.Write(info, 0, info.Length);

        var user = GetByID(data.UserID);
        var fileUrl = data.BaseUrl + "/images/photos/" + fileName;

        user.UpdatePhoto(fileUrl);

        _context.Update(user);

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

    private User GetByIDWithRelationship(int id)
    {
        var entity = _context.Users
            .Include(x => x.Followers)
                .ThenInclude(x => x.Follower)
            .Include(x => x.Following)
                .ThenInclude(x => x.Followed)
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
