using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Core.Users;
using FlashCards.Api.Service.DTO.Accounts;

namespace FlashCards.Api.Tests.Controllers;

public class AccountsControllerTests
{
    private readonly AccountsController _objectTesting;
    private readonly Mock<IAccountService> _mockService;

    private static readonly Random _random = new();

    public AccountsControllerTests()
    {
        _mockService = new Mock<IAccountService>();
        _objectTesting = new AccountsController(_mockService.Object);
    }

    [Fact]
    public async Task OnGetAllAccountsWithPassword_ShouldReturnOkResult()
    {
        IEnumerable<AccountWithPasswordDto> accounts = GenerateAccountsWithPassword();

        _mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(accounts);

        IActionResult response = await _objectTesting.GetAllAsync();

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(accounts);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task OnCreate_ShouldReturnOkResult()
    {
        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        CreateAccountDto? resultDto = null;

        AccountDto expectedResult = GenerateAccount();

        _mockService
            .Setup(x => x.CreateAsync(It.IsAny<CreateAccountDto>()))
            .Callback((CreateAccountDto x) => resultDto = x)
            .ReturnsAsync(expectedResult);

        IActionResult response = await _objectTesting.CreateAsync(createDto);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(createDto);
        
        Assert.Equal(expectedData, resultData);

        string accountResult = JsonConvert.SerializeObject(objectResponse.Value);
        string accountExpected = JsonConvert.SerializeObject(expectedResult);
        
        Assert.Equal(accountExpected, accountResult);

        _mockService.Verify(x => x.CreateAsync(It.IsAny<CreateAccountDto>()), Times.Once);
    }

    [Fact]
    public async Task OnLogin_ShouldReturnOkResult()
    {
        LoginAccountDto loginDto = new(
            email: _random.Next().ToString(),
            password: _random.Next().ToString());

        LoginAccountDto? resultDto = null;

        AccountDto expectedResult = GenerateAccount();

        _mockService
            .Setup(x => x.LoginAsync(It.IsAny<LoginAccountDto>()))
            .Callback((LoginAccountDto x) => resultDto = x)
            .ReturnsAsync(expectedResult);

        IActionResult response = await _objectTesting.LoginAsync(loginDto);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(loginDto);
        
        Assert.Equal(expectedData, resultData);

        string accountResult = JsonConvert.SerializeObject(objectResponse.Value);
        string accountExpected = JsonConvert.SerializeObject(expectedResult);
        
        Assert.Equal(accountExpected, accountResult);

        _mockService.Verify(x => x.LoginAsync(It.IsAny<LoginAccountDto>()), Times.Once);
    }

    [Fact]
    public async Task OnChangePassword_ShouldReturnOkResult()
    {
        ChangeAccountPasswordDto changePasswordDto = new(
            id: _random.Next(),
            oldPassword: _random.Next().ToString(),
            newPassword: _random.Next().ToString(),
            confirmNewPassword: _random.Next().ToString());

        ChangeAccountPasswordDto? resultDto = null;

        _mockService
            .Setup(x => x.ChangePasswordAsync(It.IsAny<ChangeAccountPasswordDto>()))
            .Callback((ChangeAccountPasswordDto x) => resultDto = x);

        IActionResult response = await _objectTesting.ChangePasswordAsync(changePasswordDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(changePasswordDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.ChangePasswordAsync(It.IsAny<ChangeAccountPasswordDto>()), Times.Once);
    }

    [Fact]
    public async Task OnDisableAccount_ShouldReturnOkResult()
    {
        DisableAccountDto disableDto = new(id: _random.Next());
        DisableAccountDto? resultDto = null;

        _mockService
            .Setup(x => x.DisableAsync(It.IsAny<DisableAccountDto>()))
            .Callback((DisableAccountDto x) => resultDto = x);

        IActionResult response = await _objectTesting.DisableAsync(disableDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(disableDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.DisableAsync(It.IsAny<DisableAccountDto>()), Times.Once);
    }

    [Fact]
    public async Task OnDeleteAccount_ShouldReturnOkResult()
    {
        DeleteAccountDto deleteDto = new(_random.Next());
        DeleteAccountDto? resultDto = null;

        _mockService
            .Setup(x => x.DeleteAsync(It.IsAny<DeleteAccountDto>()))
            .Callback((DeleteAccountDto x) => resultDto = x);

        IActionResult response = await _objectTesting.DeleteAsync(deleteDto.ID);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(deleteDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.DeleteAsync(It.IsAny<DeleteAccountDto>()), Times.Once);
    }

    private static IEnumerable<AccountWithPasswordDto> GenerateAccountsWithPassword(int count = 5)
    {
        List<AccountWithPasswordDto> result = new();

        for (int i = 0; i < count; i++)
        {
            result.Add(GenerateAccountWithPassword());
        }

        return result;
    }

    private static AccountWithPasswordDto GenerateAccountWithPassword()
    {
        var category = new Account(
            id: _random.Next(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString());

        return new AccountWithPasswordDto(category);
    }

    private static AccountDto GenerateAccount()
    {
        var account = new Account(
            id: _random.Next(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString());

        var user = new User(
            id: _random.Next(),
            name: _random.Next().ToString());

        return new AccountDto(account, user);
    }
}
