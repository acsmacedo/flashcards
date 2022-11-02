using FlashCards.Api.Core.Notifications;
using FlashCards.Api.Service.DTO.Notifications;

namespace FlashCards.Api.Tests.Controllers;

public class NotificationsControllerTests
{
    private readonly NotificationsController _objectTesting;
    private readonly Mock<INotificationService> _mockService;

    private static readonly Random _random = new();

    public NotificationsControllerTests()
    {
        _mockService = new Mock<INotificationService>();
        _objectTesting = new NotificationsController(_mockService.Object);
    }

    [Fact]
    public async Task OnGetAllNotificationsByUserID_ShouldReturnOkResult()
    {
        IEnumerable<NotificationDto> notifications = GenerateNotifications();
        int userID = _random.Next();

        _mockService.Setup(x => x.GetAllByUserIDAsync(userID)).ReturnsAsync(notifications);

        IActionResult response = await _objectTesting.GetAllByUserIDAsync(userID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(notifications);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetAllByUserIDAsync(userID), Times.Once);
    }

    [Fact]
    public async Task OnCreateNotification_ShouldReturnOkResult()
    {
        CreateNotificationDto createDto = new(
            userID: _random.Next(),
            title: _random.Next().ToString(),
            message: _random.Next().ToString());

        CreateNotificationDto? resultDto = null;

        _mockService
            .Setup(x => x.CreateAsync(It.IsAny<CreateNotificationDto>()))
            .Callback((CreateNotificationDto x) => resultDto = x);

        IActionResult response = await _objectTesting.CreateAsync(createDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(createDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.CreateAsync(It.IsAny<CreateNotificationDto>()), Times.Once);
    }

    [Fact]
    public async Task OnReadNotification_ShouldReturnOkResult()
    {
        ReadNotificationDto readDto = new(id: _random.Next());

        ReadNotificationDto? resultDto = null;

        _mockService
            .Setup(x => x.ReadAsync(It.IsAny<ReadNotificationDto>()))
            .Callback((ReadNotificationDto x) => resultDto = x);

        IActionResult response = await _objectTesting.ReadAsync(readDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(readDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.ReadAsync(It.IsAny<ReadNotificationDto>()), Times.Once);
    }

    private static IEnumerable<NotificationDto> GenerateNotifications(int count = 5)
    {
        List<NotificationDto> result = new();

        for (int i = 0; i < count; i++)
        {
            result.Add(GenerateNotification());
        }

        return result;
    }

    private static NotificationDto GenerateNotification()
    {
        var notification= new Notification(
            userID: _random.Next(),
            title: _random.Next().ToString(),
            message: _random.Next().ToString());

        return new NotificationDto(notification);
    }
}
