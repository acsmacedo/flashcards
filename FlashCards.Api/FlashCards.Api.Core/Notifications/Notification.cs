using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Core.Notifications;

public class Notification
{
    public const int TitleMaxLength = 200;
    public const int MessageMaxLength = 1000;

    public int ID { get; private set; }
    public int UserID { get; private set; }
    public DateTime NotificationDate { get; private set; }
    public DateTime? SentDate { get; private set; }
    public DateTime? ReadDate { get; private set; }
    public string Title { get; private set; }
    public string Message { get; private set; }
    public NotificationStatus Status { get; private set; }
    public User? User { get; private set; } 

    public Notification(
        int userID,
        string title,
        string message)
    {
        UserID = userID;
        Title = title;
        Message = message;
        NotificationDate = DateTime.Now;
        Status = NotificationStatus.New;
    }

    public void Send()
    {
        Status = NotificationStatus.Sent;
        SentDate = DateTime.Now;
    }

    public void Read()
    {
        Status = NotificationStatus.Read;
        ReadDate = DateTime.Now;
    }
}
