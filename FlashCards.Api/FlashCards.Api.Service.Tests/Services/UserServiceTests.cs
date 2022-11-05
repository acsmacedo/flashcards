using FlashCards.Api.Core.NotificationSettings;
using FlashCards.Api.Service.DTO.Accounts;
using FlashCards.Api.Service.DTO.NotificationSettings;
using FlashCards.Api.Service.DTO.SubscriptionTypes;
using FlashCards.Api.Service.DTO.Users;

namespace FlashCards.Api.Service.Tests.Services;

public class UserServiceTests
{
    private const int DefaultUserID = -1;

    private static readonly Random _random = new();
    private static readonly ApplicationDbContextFactory _contextFactory = new();

    [Fact]
    public async Task OnGetAllUsers_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IUserService objectTesting = new UserService(context);

        IEnumerable<UserRelationshipDto> users = await objectTesting.GetAllAsync(DefaultUserID);

        Assert.NotEmpty(users);
    }

    [Fact]
    public async Task OnGetFollowers_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IUserService objectTesting = new UserService(context);
        IAccountService accountService = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await accountService.CreateAsync(createDto);

        IEnumerable<UserRelationshipDto> oldUsers = await objectTesting.GetFollowersAsync(account.UserID);

        Assert.Empty(oldUsers);

        FollowDto followDto = new(
            followerID: DefaultUserID,
            followedID: account.UserID);

        await objectTesting.FollowAsync(followDto);

        IEnumerable<UserRelationshipDto> newUsers = await objectTesting.GetFollowersAsync(account.UserID);

        Assert.NotEmpty(newUsers);
        Assert.Equal(DefaultUserID, newUsers.Single().ID);

        await accountService.DeleteAsync(new DeleteAccountDto(account.AccountID));
    }

    [Fact]
    public async Task OnGetFollowings_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IUserService objectTesting = new UserService(context);
        IAccountService accountService = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await accountService.CreateAsync(createDto);

        IEnumerable<UserRelationshipDto> oldUsers = await objectTesting.GetFollowingAsync(account.UserID);

        Assert.Empty(oldUsers);

        FollowDto followDto = new(
            followerID: account.UserID,
            followedID: DefaultUserID);

        await objectTesting.FollowAsync(followDto);

        IEnumerable<UserRelationshipDto> newUsers = await objectTesting.GetFollowingAsync(account.UserID);

        Assert.NotEmpty(newUsers);
        Assert.Equal(DefaultUserID, newUsers.Single().ID);

        await accountService.DeleteAsync(new DeleteAccountDto(account.AccountID));
    }

    [Fact]
    public async Task OnGetByID_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IUserService objectTesting = new UserService(context);
        IAccountService accountService = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await accountService.CreateAsync(createDto);

        UserDto user = await objectTesting.GetByIDAsync(account.UserID);

        Assert.NotNull(user);
        Assert.Equal(createDto.Name, user.Name);

        await accountService.DeleteAsync(new DeleteAccountDto(account.AccountID));
    }

    [Fact]
    public async Task OnGetUserRelationshipByID_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IUserService objectTesting = new UserService(context);
        IAccountService accountService = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await accountService.CreateAsync(createDto);

        UserRelationshipDto user = await objectTesting.GetUserRelationshipByIDAsync(DefaultUserID, account.UserID);

        Assert.NotNull(user);
        Assert.Equal(createDto.Name, user.Name);

        await accountService.DeleteAsync(new DeleteAccountDto(account.AccountID));
    }

    [Fact]
    public async Task OnEditUser_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IUserService objectTesting = new UserService(context);
        IAccountService accountService = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await accountService.CreateAsync(createDto);
        UserDto oldUser = await objectTesting.GetByIDAsync(account.UserID);

        Assert.NotNull(oldUser);
        Assert.Equal(createDto.Name, oldUser.Name);
        Assert.Null(oldUser.Instagram);
        Assert.Null(oldUser.Interests);

        EditUserDto editDto = new(
            id: account.UserID,
            name: _random.Next().ToString(),
            instagram: _random.Next().ToString(),
            interests: _random.Next().ToString());

        await objectTesting.EditAsync(editDto);
        UserDto updatedUser = await objectTesting.GetByIDAsync(account.UserID);

        Assert.NotNull(updatedUser);

        Assert.Equal(oldUser.ID, updatedUser.ID);
        Assert.NotEqual(oldUser.Name, updatedUser.Name);

        Assert.Equal(editDto.Name, updatedUser.Name);
        Assert.Equal(editDto.Interests, updatedUser.Interests);
        Assert.Equal(editDto.Instagram, updatedUser.Instagram);

        await accountService.DeleteAsync(new DeleteAccountDto(account.AccountID));
    }

    [Fact]
    public async Task OnFollow_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IUserService objectTesting = new UserService(context);
        IAccountService accountService = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await accountService.CreateAsync(createDto);

        IEnumerable<UserRelationshipDto> oldUsers = await objectTesting.GetFollowersAsync(account.UserID);

        Assert.Empty(oldUsers);

        FollowDto followDto = new(
            followerID: DefaultUserID,
            followedID: account.UserID);

        await objectTesting.FollowAsync(followDto);

        IEnumerable<UserRelationshipDto> newUsers = await objectTesting.GetFollowersAsync(account.UserID);

        Assert.NotEmpty(newUsers);
        Assert.Equal(DefaultUserID, newUsers.Single().ID);

        await accountService.DeleteAsync(new DeleteAccountDto(account.AccountID));
    }

    [Fact]
    public async Task OnUnfollow_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IUserService objectTesting = new UserService(context);
        IAccountService accountService = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await accountService.CreateAsync(createDto);

        FollowDto followDto = new(
            followerID: DefaultUserID,
            followedID: account.UserID);

        await objectTesting.FollowAsync(followDto);

        IEnumerable<UserRelationshipDto> oldUsers = await objectTesting.GetFollowersAsync(account.UserID);

        Assert.NotEmpty(oldUsers);
        Assert.Equal(DefaultUserID, oldUsers.Single().ID);

        UnfollowDto unfollowDto = new(
            followerID: DefaultUserID,
            unfollowedID: account.UserID);

        await objectTesting.UnfollowAsync(unfollowDto);

        IEnumerable<UserRelationshipDto> newUsers = await objectTesting.GetFollowersAsync(account.UserID);

        Assert.Empty(oldUsers);

        await accountService.DeleteAsync(new DeleteAccountDto(account.AccountID));
    }

    [Fact]
    public async Task OnChangeNotificationFollowed_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IUserService objectTesting = new UserService(context);
        IAccountService accountService = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await accountService.CreateAsync(createDto);

        FollowDto followDto = new(
            followerID: account.UserID,
            followedID: DefaultUserID);

        await objectTesting.FollowAsync(followDto);

        IEnumerable<UserRelationshipDto> oldUsers = await objectTesting.GetFollowingAsync(account.UserID);

        Assert.NotEmpty(oldUsers);
        Assert.Equal(DefaultUserID, oldUsers.Single().ID);
        Assert.False(oldUsers.Single().IsEnableNotification);

        FollowNotificationDto followNotificationDto = new(
            followerID: account.UserID,
            followedID: DefaultUserID,
            enableNotification: true);

        await objectTesting.EditNotificationFollowedAsync(followNotificationDto);

        IEnumerable<UserRelationshipDto> newUsers = await objectTesting.GetFollowingAsync(account.UserID);

        Assert.NotEmpty(newUsers);
        Assert.Equal(DefaultUserID, newUsers.Single().ID);
        Assert.True(newUsers.Single().IsEnableNotification);

        await accountService.DeleteAsync(new DeleteAccountDto(account.AccountID));
    }

    [Fact]
    public async Task OnChangeSubscriptionType_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IUserService objectTesting = new UserService(context);
        IAccountService accountService = new AccountService(context);
        ISubscriptionTypeService subscriptionTypeService = new SubscriptionTypeService(context);

        CreateAccountDto createAccountDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await accountService.CreateAsync(createAccountDto);
        IEnumerable<SubscriptionTypeByUserDto> oldSubscriptionTypes = await subscriptionTypeService.GetAllByUserAsync(account.UserID);
        int oldSubscriptionTypeID = oldSubscriptionTypes.First(x => x.IsSubscribed).SubscriptionTypeID;

        CreateSubscriptionTypeDto createSubscriptionTypeDto = new(
            name: _random.Next().ToString(),
            price: _random.NextDouble());

        int newSubscriptionTypeID = await subscriptionTypeService.CreateAsync(createSubscriptionTypeDto);

        ChangeSubscriptionTypeDto changeSubscriptionTypeDto = new(
            userID: account.UserID,
            subscriptionTypeID: newSubscriptionTypeID);

        await objectTesting.ChangeSubscriptionTypeAsync(changeSubscriptionTypeDto);

        IEnumerable<SubscriptionTypeByUserDto> newSubscriptionTypes = await subscriptionTypeService.GetAllByUserAsync(account.UserID);
        Assert.True(newSubscriptionTypes.First(x => x.SubscriptionTypeID == newSubscriptionTypeID).IsSubscribed);
        Assert.False(newSubscriptionTypes.First(x => x.SubscriptionTypeID == oldSubscriptionTypeID).IsSubscribed);

        ChangeSubscriptionTypeDto defaultSubscriptionTypeDto = new(
            userID: account.UserID,
            subscriptionTypeID: oldSubscriptionTypeID);

        await objectTesting.ChangeSubscriptionTypeAsync(defaultSubscriptionTypeDto);

        await accountService.DeleteAsync(new DeleteAccountDto(account.AccountID));
        await subscriptionTypeService.DeleteAsync(new DeleteSubscriptionTypeDto(newSubscriptionTypeID));
    }

    [Fact]
    public async Task OnChangeNotificationSettings_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IUserService objectTesting = new UserService(context);
        IAccountService accountService = new AccountService(context);
        INotificationSettingService notificationSettingService = new NotificationSettingService(context);

        CreateAccountDto createAccountDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await accountService.CreateAsync(createAccountDto);

        CreateNotificationSettingDto createNotificationSettingDto = new(
            name: _random.Next().ToString(),
            description: _random.Next().ToString());

        int notificationSettingID = await notificationSettingService.CreateAsync(createNotificationSettingDto);

        IEnumerable<NotificationSettingByUserDto> oldNotificationSettings = await notificationSettingService.GetAllByUserAsync(account.UserID);
        NotificationSettingStatus oldStatus = oldNotificationSettings.First(x => x.NotificationSettingID == notificationSettingID).Status;

        Assert.Equal(NotificationSettingStatus.None, oldStatus);

        AddOrEditNotificationSettingDto addOrEditNotificationSettingDto = new(
            userID: account.UserID,
            notificationSettingID: notificationSettingID,
            status: NotificationSettingStatus.SMS);

        await objectTesting.AddOrEditNotificationSettingAsync(addOrEditNotificationSettingDto);

        IEnumerable<NotificationSettingByUserDto> newNotificationSettings = await notificationSettingService.GetAllByUserAsync(account.UserID);
        NotificationSettingStatus newStatus = oldNotificationSettings.First(x => x.NotificationSettingID == notificationSettingID).Status;

        Assert.Equal(NotificationSettingStatus.SMS, newStatus);

        await accountService.DeleteAsync(new DeleteAccountDto(account.AccountID));
        await notificationSettingService.DeleteAsync(new DeleteNotificationSettingDto(notificationSettingID));
    }
}
