using FlashCards.Api.Core.Accounts;

namespace FlashCards.Api.Service.DTO.Accounts;

public class LoginAccountDto
{
    [Required]
    [StringLength(Account.EmailMaxlength)]
    public string Email { get; private set; }

    [Required]
    [StringLength(Account.PasswordMaxlength)]
    public string Password { get; private set; }

    public LoginAccountDto(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
