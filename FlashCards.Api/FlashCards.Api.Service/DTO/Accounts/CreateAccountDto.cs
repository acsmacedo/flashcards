using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Service.DTO.Accounts;

public class CreateAccountDto
{
    [Required]
    [StringLength(User.NameMaxLength)]
    public string Name { get; private set; }

    [Required]
    [StringLength(Account.EmailMaxlength)]
    public string Email { get; private set; }

    [Required]
    [StringLength(Account.PasswordMaxlength)]
    public string Password { get; private set; }

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; private set; }

    public CreateAccountDto(
        string name,
        string email, 
        string password,
        string confirmPassword)
    {
        Name = name;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }
}
