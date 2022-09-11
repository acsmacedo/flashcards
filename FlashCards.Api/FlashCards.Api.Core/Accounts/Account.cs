namespace FlashCards.Api.Core.Accounts;

public class Account
{
    public const int EmailMaxlength = 80;
    public const int PasswordMaxlength = 80;

    public int ID { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public AccountStatus Status { get; private set; }

    public Account(string email, string password)
    {
        Email = email;
        Password = password;
        Status = AccountStatus.Active;
    }

    public void ChangePassword(string password)
    {
        Password = password;
    }

    public void Disable()
    {
        Status = AccountStatus.Disabled;
    }
}
