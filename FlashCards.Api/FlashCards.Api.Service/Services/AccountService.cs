using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Service.DTO.Accounts;
using Microsoft.EntityFrameworkCore;

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

    public async Task<AccountDto> CreateAsync(CreateAccountDto data)
    {
        var entity = new Account(data.Email, data.Password);

        _context.Add(entity);

        await SaveChangesAsync();

        var result = new AccountDto(entity);

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
        var entity = _context.Accounts
            .FirstOrDefault(x => x.Email == data.Email);

        if (entity == null)
            throw new Exception("Senha ou usuário inválido.");

        if (entity.Password != data.Password)
            throw new Exception("Senha ou usuário inválido.");

        var result = new AccountDto(entity);

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
