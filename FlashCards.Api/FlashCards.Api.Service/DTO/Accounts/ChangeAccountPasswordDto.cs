using FlashCards.Api.Core.Accounts;

namespace FlashCards.Api.Service.DTO.Accounts;

public class ChangeAccountPasswordDto
{
    [Key]
    public int ID { get; private set; }

    [Required]
    [StringLength(Account.PasswordMaxlength)]
    public string OldPassword { get; private set; }

    [Required]
    [StringLength(Account.PasswordMaxlength)]
    public string NewPassword { get; private set; }

    [Compare(nameof(NewPassword))]
    public string ConfirmNewPassword { get; private set; }

    public ChangeAccountPasswordDto(
        int id, 
        string oldPassword, 
        string newPassword, 
        string confirmNewPassword)
    {
        ID = id;
        OldPassword = oldPassword;
        NewPassword = newPassword;
        ConfirmNewPassword = confirmNewPassword;
    }
}
