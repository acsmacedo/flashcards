using FlashCards.Api.Core.Accounts;

namespace FlashCards.Api.Service.DTO.Accounts;

public class CreateAccountDto
{
    [Required]
    [StringLength(Account.EmailMaxlength)]
    public string Email { get; private set; }

    [Required]
    [StringLength(Account.PasswordMaxlength)]
    public string Password { get; private set; }

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; private set; }

    public CreateAccountDto(
        string email, 
        string password,
        string confirmPassword)
    {
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }
}
