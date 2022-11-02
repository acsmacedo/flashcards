using FlashCards.Api.Service.DTO.NotificationSettings;

namespace FlashCards.Api.Service.Tests.Services;

public class NotificationSettingServiceTests
{
    private const int DefaultUserID = -1;

    private static readonly Random _random = new();
    private static readonly ApplicationDbContextFactory _contextFactory = new();

    [Fact]
    public async Task OnGetAllNotificationSettings_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        INotificationSettingService objectTesting = new NotificationSettingService(context);

        CreateNotificationSettingDto createDto = new(
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        int notificationSettingID = await objectTesting.CreateAsync(createDto);

        IEnumerable<NotificationSettingDto> notificationSettings = await objectTesting.GetAllAsync();

        Assert.NotEmpty(notificationSettings);

        await objectTesting.DeleteAsync(new DeleteNotificationSettingDto(notificationSettingID));
    }

    [Fact]
    public async Task OnGetAllNotificationSettingsByUserID_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        INotificationSettingService objectTesting = new NotificationSettingService(context);

        CreateNotificationSettingDto createDto = new(
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        int notificationSettingID = await objectTesting.CreateAsync(createDto);

        IEnumerable<NotificationSettingByUserDto> notificationSettings = await objectTesting.GetAllByUserAsync(DefaultUserID);

        Assert.NotEmpty(notificationSettings);

        await objectTesting.DeleteAsync(new DeleteNotificationSettingDto(notificationSettingID));
    }

    [Fact]
    public async Task OnGetNotificationSettingByID_WhenExistData_ShouldReturnData()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        INotificationSettingService objectTesting = new NotificationSettingService(context);

        CreateNotificationSettingDto createDto = new(
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        int notificationSettingID = await objectTesting.CreateAsync(createDto);

        NotificationSettingDto notificationSetting = await objectTesting.GetByIDAsync(notificationSettingID);

        Assert.NotNull(notificationSetting);
        Assert.Equal(createDto.Name, notificationSetting.Name);
        Assert.Equal(createDto.Description, notificationSetting.Description);

        await objectTesting.DeleteAsync(new DeleteNotificationSettingDto(notificationSettingID));
    }

    [Fact]
    public async Task OnCreateNotificationSetting_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        INotificationSettingService objectTesting = new NotificationSettingService(context);

        CreateNotificationSettingDto createDto = new(
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        int notificationSettingID = await objectTesting.CreateAsync(createDto);
        NotificationSettingDto newNotificationSetting = await objectTesting.GetByIDAsync(notificationSettingID);

        Assert.NotNull(newNotificationSetting);
        Assert.Equal(createDto.Name, newNotificationSetting.Name);
        Assert.Equal(createDto.Description, newNotificationSetting.Description);

        await objectTesting.DeleteAsync(new DeleteNotificationSettingDto(notificationSettingID));
    }

    [Fact]
    public async Task OnEditNotificationSetting_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        INotificationSettingService objectTesting = new NotificationSettingService(context);

        CreateNotificationSettingDto createDto = new(
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        int notificationSettingID = await objectTesting.CreateAsync(createDto);
        NotificationSettingDto oldNotificationSetting = await objectTesting.GetByIDAsync(notificationSettingID);

        Assert.NotNull(oldNotificationSetting);
        Assert.Equal(createDto.Name, oldNotificationSetting.Name);
        Assert.Equal(createDto.Description, oldNotificationSetting.Description);

        EditNotificationSettingDto editDto = new(
            id: oldNotificationSetting.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        await objectTesting.EditAsync(editDto);
        NotificationSettingDto updatedNotificationSetting = await objectTesting.GetByIDAsync(notificationSettingID);

        Assert.NotNull(updatedNotificationSetting);

        Assert.Equal(oldNotificationSetting.ID, updatedNotificationSetting.ID);
        Assert.NotEqual(oldNotificationSetting.Name, updatedNotificationSetting.Name);
        Assert.NotEqual(oldNotificationSetting.Description, updatedNotificationSetting.Description);

        Assert.Equal(editDto.Name, updatedNotificationSetting.Name);
        Assert.Equal(editDto.Description, updatedNotificationSetting.Description);

        await objectTesting.DeleteAsync(new DeleteNotificationSettingDto(notificationSettingID));
    }

    [Fact]
    public async Task OnDeleteNotificationSetting_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        INotificationSettingService objectTesting = new NotificationSettingService(context);

        CreateNotificationSettingDto createDto = new(
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        int notificationSettingID = await objectTesting.CreateAsync(createDto);
        NotificationSettingDto notificationSetting = await objectTesting.GetByIDAsync(notificationSettingID);

        Assert.NotNull(notificationSetting);

        await objectTesting.DeleteAsync(new DeleteNotificationSettingDto(notificationSettingID));

        Task action() => objectTesting.GetByIDAsync(notificationSettingID);
        Exception result = await Assert.ThrowsAsync<Exception>(action);

        Assert.Equal("Tipo de notificação não encontrada.", result.Message);
    }
}
