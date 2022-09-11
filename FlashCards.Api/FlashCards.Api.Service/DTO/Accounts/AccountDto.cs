using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Service.DTO.Accounts;

public class AccountDto
{
    public int AccountID { get; private set; }
    public int UserID { get; private set; }
    public string Email { get; private set; }
    public AccountStatus Status { get; private set; }

    public AccountDto(Account account, User user)
    {
        AccountID = account.ID;
        UserID = user.ID;
        Email = account.Email;
        Status = account.Status;
    }
}
