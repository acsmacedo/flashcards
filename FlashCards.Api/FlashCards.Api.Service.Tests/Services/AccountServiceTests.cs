using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Service.DTO.Accounts;

namespace FlashCards.Api.Service.Tests.Services;

public class AccountServiceTests
{
    private static readonly Random _random = new();
    private static readonly ApplicationDbContextFactory _contextFactory = new();

    [Fact]
    public async Task OnGetAllAccounts_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IAccountService objectTesting = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await objectTesting.CreateAsync(createDto);

        IEnumerable<AccountWithPasswordDto> accounts = await objectTesting.GetAllAsync();

        Assert.NotEmpty(accounts);

        await objectTesting.DeleteAsync(new DeleteAccountDto(account.AccountID));
    }

    [Fact]
    public async Task OnGetAccountByID_WhenExistData_ShouldReturnData()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IAccountService objectTesting = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await objectTesting.CreateAsync(createDto);

        Assert.NotNull(account);
        Assert.Equal(createDto.Email, account.Email);

        await objectTesting.DeleteAsync(new DeleteAccountDto(account.AccountID));
    }

    [Fact]
    public async Task OnCreateAccount_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IAccountService objectTesting = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await objectTesting.CreateAsync(createDto);
        AccountDto newAccount = await objectTesting.GetByIDAsync(account.AccountID);

        Assert.NotNull(newAccount);
        Assert.Equal(createDto.Email, newAccount.Email);

        await objectTesting.DeleteAsync(new DeleteAccountDto(account.AccountID));
    }

    [Fact]
    public async Task OnLoginAccount_WhenEmailIsInvalid_ShouldThrowException()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IAccountService objectTesting = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await objectTesting.CreateAsync(createDto);
        
        LoginAccountDto loginDto = new(
            email: _random.Next().ToString(),
            password: createDto.Password);

        Task action() => objectTesting.LoginAsync(loginDto);
        Exception result = await Assert.ThrowsAsync<Exception>(action);

        Assert.Equal("Senha ou usuário inválido.", result.Message);
    }

    [Fact]
    public async Task OnLoginAccount_WhenPasswordIsInvalid_ShouldThrowException()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IAccountService objectTesting = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await objectTesting.CreateAsync(createDto);

        LoginAccountDto loginDto = new(
            email: createDto.Email,
            password: _random.Next().ToString());

        Task action() => objectTesting.LoginAsync(loginDto);
        Exception result = await Assert.ThrowsAsync<Exception>(action);

        Assert.Equal("Senha ou usuário inválido.", result.Message);
    }

    [Fact]
    public async Task OnLoginAccount_WhenDataIsValid_ShouldReturnData()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IAccountService objectTesting = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await objectTesting.CreateAsync(createDto);

        LoginAccountDto loginDto = new(
            email: createDto.Email,
            password: createDto.Password);

        AccountDto newLogin = await objectTesting.LoginAsync(loginDto);

        Assert.NotNull(newLogin);
    }

    [Fact]
    public async Task OnDeleteAccount_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IAccountService objectTesting = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto account = await objectTesting.CreateAsync(createDto);

        Assert.NotNull(account);

        await objectTesting.DeleteAsync(new DeleteAccountDto(account.AccountID));

        Task action() => objectTesting.GetByIDAsync(account.AccountID);
        Exception result = await Assert.ThrowsAsync<Exception>(action);

        Assert.Equal("Usuário não encontrado.", result.Message);
    }

    [Fact]
    public async Task OnDisable_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IAccountService objectTesting = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto oldAccount = await objectTesting.CreateAsync(createDto);

        Assert.Equal(AccountStatus.Active, oldAccount.Status);

        DisableAccountDto disableDto = new(id: oldAccount.AccountID);

        await objectTesting.DisableAsync(disableDto);

        AccountDto updatedAccount = await objectTesting.GetByIDAsync(oldAccount.AccountID);

        Assert.Equal(AccountStatus.Disabled, updatedAccount.Status);

        await objectTesting.DeleteAsync(new DeleteAccountDto(oldAccount.AccountID));
    }

    [Fact]
    public async Task OnChangePassword_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IAccountService objectTesting = new AccountService(context);

        CreateAccountDto createDto = new(
            name: _random.Next().ToString(),
            email: _random.Next().ToString(),
            password: _random.Next().ToString(),
            confirmPassword: _random.Next().ToString());

        AccountDto oldAccount = await objectTesting.CreateAsync(createDto);

        ChangeAccountPasswordDto changePasswordDto = new(
            id: oldAccount.AccountID,
            oldPassword: createDto.Password,
            newPassword: _random.Next().ToString(),
            confirmNewPassword: _random.Next().ToString());

        await objectTesting.ChangePasswordAsync(changePasswordDto);

        LoginAccountDto loginDto = new(
            email: createDto.Email,
            password: changePasswordDto.NewPassword);

        AccountDto newLogin = await objectTesting.LoginAsync(loginDto);

        Assert.NotNull(newLogin);

        await objectTesting.DeleteAsync(new DeleteAccountDto(oldAccount.AccountID));
    }
}
