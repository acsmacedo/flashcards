using FlashCards.Api.Service.DTO.Notifications;

namespace FlashCards.Api.Service.Tests.Services;

public class NotificationServiceTests
{
    private const int DefaultUserID = -1;

    private static readonly Random _random = new();
    private static readonly ApplicationDbContextFactory _contextFactory = new();

    [Fact]
    public async Task OnGetAllNotificationsByUser_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        INotificationService objectTesting = new NotificationService(context);

        CreateNotificationDto createDto = new(
            userID: DefaultUserID,
            title: _random.Next().ToString(),
            message: _random.Next().ToString());

        int notificationID = await objectTesting.CreateAsync(createDto);

        IEnumerable<NotificationDto> notifications = await objectTesting.GetAllByUserIDAsync(DefaultUserID);

        Assert.NotEmpty(notifications);

        await objectTesting.DeleteAsync(new DeleteNotificationDto(notificationID));
    }

    [Fact]
    public async Task OnGetCategoriesByID_WhenExistData_ShouldReturnData()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        INotificationService objectTesting = new NotificationService(context);

        CreateNotificationDto createDto = new(
            userID: DefaultUserID,
            title: _random.Next().ToString(),
            message: _random.Next().ToString());

        int notificationID = await objectTesting.CreateAsync(createDto);

        NotificationDto notification = await objectTesting.GetByIDAsync(notificationID);

        Assert.NotNull(notification);
        Assert.Equal(createDto.UserID, notification.UserID);
        Assert.Equal(createDto.Title, notification.Title);
        Assert.Equal(createDto.Message, notification.Message);

        await objectTesting.DeleteAsync(new DeleteNotificationDto(notificationID));
    }

    [Fact]
    public async Task OnCreateNotification_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        INotificationService objectTesting = new NotificationService(context);

        CreateNotificationDto createDto = new(
            userID: DefaultUserID,
            title: _random.Next().ToString(),
            message: _random.Next().ToString());

        int notificationID = await objectTesting.CreateAsync(createDto);
        NotificationDto newNotification = await objectTesting.GetByIDAsync(notificationID);

        Assert.NotNull(newNotification);
        Assert.Equal(createDto.UserID, newNotification.UserID);
        Assert.Equal(createDto.Title, newNotification.Title);
        Assert.Equal(createDto.Message, newNotification.Message);

        await objectTesting.DeleteAsync(new DeleteNotificationDto(notificationID));
    }

    [Fact]
    public async Task OnReadNotification_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        INotificationService objectTesting = new NotificationService(context);

        CreateNotificationDto createDto = new(
            userID: DefaultUserID,
            title: _random.Next().ToString(),
            message: _random.Next().ToString());

        int notificationID = await objectTesting.CreateAsync(createDto);
        NotificationDto oldNotification = await objectTesting.GetByIDAsync(notificationID);

        Assert.NotNull(oldNotification);
        Assert.Equal(createDto.UserID, oldNotification.UserID);
        Assert.Equal(createDto.Title, oldNotification.Title);
        Assert.Equal(createDto.Message, oldNotification.Message);
        Assert.Null(oldNotification.ReadDate);

        ReadNotificationDto editDto = new(id: oldNotification.ID);

        await objectTesting.ReadAsync(editDto);
        NotificationDto updatedNotification = await objectTesting.GetByIDAsync(notificationID);

        Assert.NotNull(updatedNotification);

        Assert.NotNull(oldNotification);
        Assert.Equal(createDto.UserID, updatedNotification.UserID);
        Assert.Equal(createDto.Title, updatedNotification.Title);
        Assert.Equal(createDto.Message, updatedNotification.Message);
        Assert.NotNull(updatedNotification.ReadDate);

        await objectTesting.DeleteAsync(new DeleteNotificationDto(notificationID));
    }

    [Fact]
    public async Task OnDeleteNotification_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        INotificationService objectTesting = new NotificationService(context);

        CreateNotificationDto createDto = new(
            userID: DefaultUserID,
            title: _random.Next().ToString(),
            message: _random.Next().ToString());

        int notificationID = await objectTesting.CreateAsync(createDto);
        NotificationDto notification = await objectTesting.GetByIDAsync(notificationID);

        Assert.NotNull(notification);

        await objectTesting.DeleteAsync(new DeleteNotificationDto(notificationID));

        Task action() => objectTesting.GetByIDAsync(notificationID);
        Exception result = await Assert.ThrowsAsync<Exception>(action);

        Assert.Equal("Notificação não encontrada.", result.Message);
    }
}
