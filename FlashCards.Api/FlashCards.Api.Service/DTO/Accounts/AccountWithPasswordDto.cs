using FlashCards.Api.Core.Accounts;

namespace FlashCards.Api.Service.DTO.Accounts;

public class AccountWithPasswordDto
{
    public int ID { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public AccountStatus Status { get; private set; }

    public AccountWithPasswordDto(Account data)
    {
        ID = data.ID;
        Email = data.Email;
        Password = data.Password;
        Status = data.Status;
    }
}
