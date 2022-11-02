using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Core.Users;
using FlashCards.Api.Service.DTO.Accounts;

namespace FlashCards.Api.Service.Services;

public class AccountService : IAccountService
{
    private readonly ApplicationDbContext _context;

    public AccountService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AccountWithPasswordDto>> GetAllAsync()
    {
        var categories = await _context.Accounts.ToListAsync();
        var result = categories.Select(x => new AccountWithPasswordDto(x));

        return result;
    }

    public Task<AccountDto> GetByIDAsync(int userID)
    {
        var account = _context.Accounts
            .FirstOrDefault(x => x.ID == userID);

        if (account == null)
            throw new Exception("Usuário não encontrado.");

        var user = _context.Users
            .FirstOrDefault(x => x.AccountID == account.ID);

        if (user == null)
            throw new Exception("Usuário não encontrado.");

        var result = new AccountDto(account, user);

        return Task.FromResult(result);
    }

    public async Task<AccountDto> CreateAsync(CreateAccountDto data)
    {
        var subscriptionType = await _context.SubscriptionTypes
            .FirstOrDefaultAsync(x => x.Price == null);

        var account = new Account(data.Email, data.Password);
        var user = new User(account, data.Name, subscriptionType?.ID);

        _context.Add(user);

        await SaveChangesAsync();

        var result = new AccountDto(account, user);

        return result;
    }

    public async Task ChangePasswordAsync(ChangeAccountPasswordDto data)
    {
        var entity = GetByID(data.ID);

        if (entity.Password != data.OldPassword)
            throw new Exception("Senha antiga inválida.");

        entity.ChangePassword(data.NewPassword);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public async Task DeleteAsync(DeleteAccountDto data)
    {
        var entity = GetByID(data.ID);

        _context.Remove(entity);

        await SaveChangesAsync();
    }

    public async Task DisableAsync(DisableAccountDto data)
    {
        var entity = GetByID(data.ID);

        entity.Disable();

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public Task<AccountDto> LoginAsync(LoginAccountDto data)
    {
        var account = _context.Accounts
            .FirstOrDefault(x => x.Email == data.Email);

        if (account == null)
            throw new Exception("Senha ou usuário inválido.");

        if (account.Password != data.Password)
            throw new Exception("Senha ou usuário inválido.");

        var user = _context.Users
            .FirstOrDefault(x => x.AccountID == account.ID);

        if (user == null)
            throw new Exception("Usuário não encontrado.");

        var result = new AccountDto(account, user);

        return Task.FromResult(result);
    }

    private Account GetByID(int id)
    {
        var entity = _context.Accounts
            .FirstOrDefault(x => x.ID == id);

        if (entity != null)
            return entity;

        throw new Exception("Conta não encontrada.");
    }

    private async Task SaveChangesAsync()
    {
        var result = await _context.SaveChangesAsync();

        if (result <= 0)
            throw new Exception("Ocorreu um erro ao salvar os dados. Tente novamente.");
    }
}
