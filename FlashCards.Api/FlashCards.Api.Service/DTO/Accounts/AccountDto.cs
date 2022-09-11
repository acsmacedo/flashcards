using FlashCards.Api.Core.Accounts;

namespace FlashCards.Api.Service.DTO.Accounts;

public class AccountDto
{
    public int ID { get; private set; }
    public string Email { get; private set; }
    public AccountStatus Status { get; private set; }

    public AccountDto(Account data)
    {
        ID = data.ID;
        Email = data.Email;
        Status = data.Status;
    }
}
