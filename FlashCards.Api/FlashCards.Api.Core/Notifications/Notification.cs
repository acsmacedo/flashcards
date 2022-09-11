using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Core.Notifications;

public class Notification
{
    public const int MessageMaxLength = 1000;

    public int NotificationID { get; private set; }
    public int UserID { get; private set; }
    public DateTime NotificationDate { get; private set; }
    public string Message { get; private set; }
    public bool Read { get; private set; }
    public User User { get; private set; } = User.Empty;

    public Notification(
        int notificationID,
        int userID, 
        DateTime notificationDate,
        string message,
        bool read)
    {
        NotificationID = notificationID;
        UserID = userID;
        NotificationDate = notificationDate;
        Message = message;
        Read = read;
    }
}
