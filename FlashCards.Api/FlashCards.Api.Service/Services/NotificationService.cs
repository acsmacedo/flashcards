using FlashCards.Api.Core.Notifications;
using FlashCards.Api.Service.DTO.Categories;
using FlashCards.Api.Service.DTO.Notifications;

namespace FlashCards.Api.Service.Services;

public class NotificationService : INotificationService
{
    private readonly ApplicationDbContext _context;

    public NotificationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<NotificationDto>> GetAllByUserIDAsync(int userID)
    {
        var notifications = await _context.Notifications
            .Where(x => x.UserID == userID)
            .OrderByDescending(x => x.SentDate)
            .ToListAsync();

        var result = notifications.Select(x => new NotificationDto(x));

        return result;
    }

    public Task<NotificationDto> GetByIDAsync(int notificationID)
    {
        var notification = GetByID(notificationID);
        var result = new NotificationDto(notification);

        return Task.FromResult(result);
    }

    public async Task<int> CreateAsync(CreateNotificationDto data)
    {
        var entity = new Notification(
            userID: data.UserID,
            title: data.Title,
            message: data.Message);

        _context.Add(entity);

        await SaveChangesAsync();

        return entity.ID;
    }

    public async Task ReadAsync(ReadNotificationDto data)
    {
        var entity = GetByID(data.ID);

        entity.Read();

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public async Task DeleteAsync(DeleteNotificationDto data)
    {
        var entity = GetByID(data.ID);

        _context.Remove(entity);

        await SaveChangesAsync();
    }

    private Notification GetByID(int id)
    {
        var entity = _context.Notifications
            .FirstOrDefault(x => x.ID == id);

        if (entity != null)
            return entity;

        throw new Exception("Notificação não encontrada.");
    }

    private async Task SaveChangesAsync()
    {
        var result = await _context.SaveChangesAsync();

        if (result <= 0)
            throw new Exception("Ocorreu um erro ao salvar os dados. Tente novamente.");
    }
}
