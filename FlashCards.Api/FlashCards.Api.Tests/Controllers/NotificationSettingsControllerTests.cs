using FlashCards.Api.Core.NotificationSettings;
using FlashCards.Api.Core.Users;
using FlashCards.Api.Service.DTO.NotificationSettings;

namespace FlashCards.Api.Tests.Controllers;

public class NotificationSettingsControllerTests
{
    private readonly NotificationSettingsController _objectTesting;
    private readonly Mock<INotificationSettingService> _mockService;

    private static readonly Random _random = new();

    public NotificationSettingsControllerTests()
    {
        _mockService = new Mock<INotificationSettingService>();
        _objectTesting = new NotificationSettingsController(_mockService.Object);
    }

    [Fact]
    public async Task OnGetAllNotificationSettings_ShouldReturnOkResult()
    {
        IEnumerable<NotificationSettingDto> notificationSettings = GenerateNotificationSettings();

        _mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(notificationSettings);

        IActionResult response = await _objectTesting.GetAllAsync();

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(notificationSettings);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task OnGetAllNotificationSettingsByUserID_ShouldReturnOkResult()
    {
        IEnumerable<NotificationSettingByUserDto> notificationSettings = GenerateNotificationSettingsByUser();
        int userID = _random.Next();

        _mockService.Setup(x => x.GetAllByUserAsync(userID)).ReturnsAsync(notificationSettings);

        IActionResult response = await _objectTesting.GetAllByUserIDAsync(userID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(notificationSettings);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetAllByUserAsync(userID), Times.Once);
    }

    [Fact]
    public async Task OnCreateNotificationSetting_ShouldReturnOkResult()
    {
        CreateNotificationSettingDto createDto = new(
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        CreateNotificationSettingDto? resultDto = null;

        _mockService
            .Setup(x => x.CreateAsync(It.IsAny<CreateNotificationSettingDto>()))
            .Callback((CreateNotificationSettingDto x) => resultDto = x);

        IActionResult response = await _objectTesting.CreateAsync(createDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(createDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.CreateAsync(It.IsAny<CreateNotificationSettingDto>()), Times.Once);
    }

    [Fact]
    public async Task OnEditNotificationSetting_ShouldReturnOkResult()
    {
        EditNotificationSettingDto editDto = new(
            id: _random.Next(),
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        EditNotificationSettingDto? resultDto = null;

        _mockService
            .Setup(x => x.EditAsync(It.IsAny<EditNotificationSettingDto>()))
            .Callback((EditNotificationSettingDto x) => resultDto = x);

        IActionResult response = await _objectTesting.EditAsync(editDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(editDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.EditAsync(It.IsAny<EditNotificationSettingDto>()), Times.Once);
    }

    [Fact]
    public async Task OnDeleteNotificationSetting_ShouldReturnOkResult()
    {
        DeleteNotificationSettingDto deleteDto = new(_random.Next());
        DeleteNotificationSettingDto? resultDto = null;

        _mockService
            .Setup(x => x.DeleteAsync(It.IsAny<DeleteNotificationSettingDto>()))
            .Callback((DeleteNotificationSettingDto x) => resultDto = x);

        IActionResult response = await _objectTesting.DeleteAsync(deleteDto.ID);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(deleteDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.DeleteAsync(It.IsAny<DeleteNotificationSettingDto>()), Times.Once);
    }
    
    private static IEnumerable<NotificationSettingDto> GenerateNotificationSettings(int count = 5)
    {
        List<NotificationSettingDto> result = new();

        for (int i = 0; i < count; i++)
        {
            result.Add(GenerateNotificationSetting());
        }

        return result;
    }

    private static NotificationSettingDto GenerateNotificationSetting()
    {
        var notificationSetting = new NotificationSetting(
            id: _random.Next(),
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        return new NotificationSettingDto(notificationSetting);
    }

    private static IEnumerable<NotificationSettingByUserDto> GenerateNotificationSettingsByUser(int count = 5)
    {
        List<NotificationSettingByUserDto> result = new();

        for (int i = 0; i < count; i++)
        {
            result.Add(GenerateNotificationSettingByUser());
        }

        return result;
    }

    private static NotificationSettingByUserDto GenerateNotificationSettingByUser()
    {
        var notificationSetting = new NotificationSetting(
            id: _random.Next(),
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        var user = new User(
            id: _random.Next(),
            name: _random.Next().ToString());

        return new NotificationSettingByUserDto(notificationSetting, user);
    }
}
