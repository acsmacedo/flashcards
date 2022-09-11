using FlashCards.Api.Service.DTO.Accounts;

namespace FlashCards.Api.Service.Interfaces;

public interface IAccountService
{
    Task<IEnumerable<AccountWithPasswordDto>> GetAllAsync();
    Task<AccountDto> CreateAsync(CreateAccountDto data);
    Task ChangePasswordAsync(ChangeAccountPasswordDto data);
    Task<AccountDto> LoginAsync(LoginAccountDto data);
    Task DisableAsync(DisableAccountDto data);
    Task DeleteAsync(DeleteAccountDto data);
}
