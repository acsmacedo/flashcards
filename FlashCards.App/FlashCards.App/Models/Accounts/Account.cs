namespace FlashCards.App.Models.Accounts
{
    public class Account
    {
        public int AccountID { get; private set; }
        public int UserID { get; private set; }
        public string Email { get; private set; }
        public AccountStatus Status { get; private set; }

        public Account(
            int accountID, 
            int userID, 
            string email,
            AccountStatus status)
        {
            AccountID = accountID;
            UserID = userID;
            Email = email;
            Status = status;
        }
    }
}
