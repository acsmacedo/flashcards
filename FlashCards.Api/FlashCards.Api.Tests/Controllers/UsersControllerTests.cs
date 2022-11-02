using FlashCards.Api.Core.Directories;
using FlashCards.Api.Core.NotificationSettings;
using FlashCards.Api.Core.Users;
using FlashCards.Api.Service.DTO.Directories;
using FlashCards.Api.Service.DTO.Users;

namespace FlashCards.Api.Tests.Controllers;

public class UsersControllerTests
{
    private readonly UsersController _objectTesting;
    private readonly Mock<IUserService> _mockUserService;
    private readonly Mock<IDirectoryService> _mockDirectoryService;

    private static readonly Random _random = new();

    public UsersControllerTests()
    {
        _mockUserService = new Mock<IUserService>();
        _mockDirectoryService = new Mock<IDirectoryService>();
        _objectTesting = new UsersController(
            userService: _mockUserService.Object, 
            directoryService: _mockDirectoryService.Object);
    }

    [Fact]
    public async Task OnGetAllUsers_ShouldReturnOkResult()
    {
        IEnumerable<UserRelationshipDto> users = GenerateUserRelationships();
        int userID = _random.Next();

        _mockUserService.Setup(x => x.GetAllAsync(userID)).ReturnsAsync(users);

        IActionResult response = await _objectTesting.GetAllAsync(userID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(users);

        Assert.Equal(expectedData, resultData);

        _mockUserService.Verify(x => x.GetAllAsync(userID), Times.Once);
    }

    [Fact]
    public async Task OnGetFollowers_ShouldReturnOkResult()
    {
        IEnumerable<UserRelationshipDto> users = GenerateUserRelationships();
        int userID = _random.Next();

        _mockUserService.Setup(x => x.GetFollowersAsync(userID)).ReturnsAsync(users);

        IActionResult response = await _objectTesting.GetFollowersAsync(userID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(users);

        Assert.Equal(expectedData, resultData);

        _mockUserService.Verify(x => x.GetFollowersAsync(userID), Times.Once);
    }

    [Fact]
    public async Task OnGetFollowings_ShouldReturnOkResult()
    {
        IEnumerable<UserRelationshipDto> users = GenerateUserRelationships();
        int userID = _random.Next();

        _mockUserService.Setup(x => x.GetFollowingAsync(userID)).ReturnsAsync(users);

        IActionResult response = await _objectTesting.GetFollowingAsync(userID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(users);

        Assert.Equal(expectedData, resultData);

        _mockUserService.Verify(x => x.GetFollowingAsync(userID), Times.Once);
    }

    [Fact]
    public async Task OnGetUserByID_ShouldReturnOkResult()
    {
        UserDto user = GenerateUser();
        int userID = _random.Next();

        _mockUserService.Setup(x => x.GetByIDAsync(userID)).ReturnsAsync(user);

        IActionResult response = await _objectTesting.GetByIDAsync(userID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(user);

        Assert.Equal(expectedData, resultData);

        _mockUserService.Verify(x => x.GetByIDAsync(userID), Times.Once);
    }

    [Fact]
    public async Task OnGetUserRelationshipByID_ShouldReturnOkResult()
    {
        UserRelationshipDto user = GenerateUserRelationship();
        int userID = _random.Next();
        int relationshipID = _random.Next();

        _mockUserService.Setup(x => x.GetUserRelationshipByIDAsync(userID, relationshipID)).ReturnsAsync(user);

        IActionResult response = await _objectTesting.GetUserRelationshipByIDAsync(userID, relationshipID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(user);

        Assert.Equal(expectedData, resultData);

        _mockUserService.Verify(x => x.GetUserRelationshipByIDAsync(userID, relationshipID), Times.Once);
    }

    [Fact]
    public async Task OnGetRootDirectoryByUserID_ShouldReturnOkResult()
    {
        DirectoryDto user = GenerateDirectory();
        int userID = _random.Next();

        _mockDirectoryService.Setup(x => x.GetByUserIDAsync(userID, null)).ReturnsAsync(user);

        IActionResult response = await _objectTesting.GetDirectoryByUserIDAsync(userID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(user);

        Assert.Equal(expectedData, resultData);

        _mockDirectoryService.Verify(x => x.GetByUserIDAsync(userID, null), Times.Once);
    }

    [Fact]
    public async Task OnGetDirectoryByID_ShouldReturnOkResult()
    {
        DirectoryDto user = GenerateDirectory();
        int userID = _random.Next();
        int directoryID = _random.Next();

        _mockDirectoryService.Setup(x => x.GetByUserIDAsync(userID, directoryID)).ReturnsAsync(user);

        IActionResult response = await _objectTesting.GetDirectoryByUserIDAsync(userID, directoryID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(user);

        Assert.Equal(expectedData, resultData);

        _mockDirectoryService.Verify(x => x.GetByUserIDAsync(userID, directoryID), Times.Once);
    }

    [Fact]
    public async Task OnEditUser_ShouldReturnOkResult()
    {
        EditUserDto editDto = new(
            id: _random.Next(),
            name: _random.Next().ToString(),
            instagram: _random.Next().ToString(),
            interests: _random.Next().ToString());

        EditUserDto? resultDto = null;

        _mockUserService
            .Setup(x => x.EditAsync(It.IsAny<EditUserDto>()))
            .Callback((EditUserDto x) => resultDto = x);

        IActionResult response = await _objectTesting.EditAsync(editDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(editDto);

        Assert.Equal(expectedData, resultData);

        _mockUserService.Verify(x => x.EditAsync(It.IsAny<EditUserDto>()), Times.Once);
    }

    [Fact]
    public async Task OnFollowUser_ShouldReturnOkResult()
    {
        FollowDto followDto = new(
            followedID: _random.Next(),
            followerID: _random.Next());

        FollowDto? resultDto = null;

        _mockUserService
            .Setup(x => x.FollowAsync(It.IsAny<FollowDto>()))
            .Callback((FollowDto x) => resultDto = x);

        IActionResult response = await _objectTesting.FollowAsync(followDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(followDto);

        Assert.Equal(expectedData, resultData);

        _mockUserService.Verify(x => x.FollowAsync(It.IsAny<FollowDto>()), Times.Once);
    }

    [Fact]
    public async Task OnUnFollowUser_ShouldReturnOkResult()
    {
        UnfollowDto unfollowDto = new(
            unfollowedID: _random.Next(),
            followerID: _random.Next());

        UnfollowDto? resultDto = null;

        _mockUserService
            .Setup(x => x.UnfollowAsync(It.IsAny<UnfollowDto>()))
            .Callback((UnfollowDto x) => resultDto = x);

        IActionResult response = await _objectTesting.UnfollowAsync(unfollowDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(unfollowDto);

        Assert.Equal(expectedData, resultData);

        _mockUserService.Verify(x => x.UnfollowAsync(It.IsAny<UnfollowDto>()), Times.Once);
    }

    [Fact]
    public async Task OnChangeSubscriptionType_ShouldReturnOkResult()
    {
        ChangeSubscriptionTypeDto changeSubscriptionDto = new(
            userID: _random.Next(),
            subscriptionTypeID: _random.Next());

        ChangeSubscriptionTypeDto? resultDto = null;

        _mockUserService
            .Setup(x => x.ChangeSubscriptionTypeAsync(It.IsAny<ChangeSubscriptionTypeDto>()))
            .Callback((ChangeSubscriptionTypeDto x) => resultDto = x);

        IActionResult response = await _objectTesting.ChangeSubscriptionAsync(changeSubscriptionDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(changeSubscriptionDto);

        Assert.Equal(expectedData, resultData);

        _mockUserService.Verify(x => x.ChangeSubscriptionTypeAsync(It.IsAny<ChangeSubscriptionTypeDto>()), Times.Once);
    }

    [Fact]
    public async Task OnEditNotificationFollowed_ShouldReturnOkResult()
    {
        FollowNotificationDto editNotificationDto = new(
            followerID: _random.Next(),
            followedID: _random.Next(),
            enableNotification: _random.Next() % 2 == 0);

        FollowNotificationDto? resultDto = null;

        _mockUserService
            .Setup(x => x.EditNotificationFollowedAsync(It.IsAny<FollowNotificationDto>()))
            .Callback((FollowNotificationDto x) => resultDto = x);

        IActionResult response = await _objectTesting.EditNotificationFollowedAsync(editNotificationDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(editNotificationDto);

        Assert.Equal(expectedData, resultData);

        _mockUserService.Verify(x => x.EditNotificationFollowedAsync(It.IsAny<FollowNotificationDto>()), Times.Once);
    }

    [Fact]
    public async Task OnAddOrEditNotificationSetting_ShouldReturnOkResult()
    {
        AddOrEditNotificationSettingDto addOrEditNotficationSettingDto = new(
            userID: _random.Next(),
            notificationSettingID: _random.Next(),
            status: NotificationSettingStatus.Email);

        AddOrEditNotificationSettingDto? resultDto = null;

        _mockUserService
            .Setup(x => x.AddOrEditNotificationSettingAsync(It.IsAny<AddOrEditNotificationSettingDto>()))
            .Callback((AddOrEditNotificationSettingDto x) => resultDto = x);

        IActionResult response = await _objectTesting.AddOrEditNotificationSettingAsync(addOrEditNotficationSettingDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(addOrEditNotficationSettingDto);

        Assert.Equal(expectedData, resultData);

        _mockUserService.Verify(x => x.AddOrEditNotificationSettingAsync(It.IsAny<AddOrEditNotificationSettingDto>()), Times.Once);
    }

    private static IEnumerable<UserRelationshipDto> GenerateUserRelationships(int count = 5)
    {
        List<UserRelationshipDto> result = new();

        for (int i = 0; i < count; i++)
        {
            result.Add(GenerateUserRelationship());
        }

        return result;
    }

    private static UserRelationshipDto GenerateUserRelationship()
    {
        var data = new User(
            id: _random.Next(),
            name: _random.Next().ToString());

        var current = new User(
            id: _random.Next(),
            name: _random.Next().ToString());

        return new UserRelationshipDto(data, current);
    }

    private static UserDto GenerateUser()
    {
        var user = new User(
            id: _random.Next(),
            name: _random.Next().ToString());

        return new UserDto(user);
    }

    private static DirectoryDto GenerateDirectory()
    {
        var directory = new UserDirectory(
            userDirectoryParentID: null,
            userID: _random.Next(),
            name: _random.Next().ToString());

        return new DirectoryDto(directory);
    }
}
