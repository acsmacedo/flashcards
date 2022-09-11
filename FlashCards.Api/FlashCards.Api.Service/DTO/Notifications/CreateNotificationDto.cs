namespace FlashCards.Api.Service.DTO.Notifications;

public class CreateNotificationDto
{
    public int UserID { get; private set; }
    public string Title { get; private set; }
    public string Message { get; private set; }

    public CreateNotificationDto(
        int userID, 
        string title, 
        string message)
    {
        UserID = userID;
        Title = title;
        Message = message;
    }
}
