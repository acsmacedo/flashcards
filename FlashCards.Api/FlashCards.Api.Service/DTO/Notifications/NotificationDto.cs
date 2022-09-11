using FlashCards.Api.Core.Notifications;

namespace FlashCards.Api.Service.DTO.Notifications;

public class NotificationDto
{
    public int ID { get; private set; }
    public int UserID { get; private set; }
    public DateTime NotificationDate { get; private set; }
    public DateTime? SentDate { get; private set; }
    public DateTime? ReadDate { get; private set; }
    public string Title { get; private set; }
    public string Message { get; private set; }
    public NotificationStatus Status { get; private set; }

    public NotificationDto(Notification data)
    {
        ID = data.ID;
        UserID = data.UserID;
        NotificationDate = data.NotificationDate;
        SentDate = data.SentDate;
        ReadDate = data.ReadDate;
        Title = data.Title;
        Message = data.Message;
        Status = data.Status;
    }
}
