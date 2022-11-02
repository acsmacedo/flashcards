namespace FlashCards.Api.Service.DTO.Notifications;

public class DeleteNotificationDto
{
    public int ID { get; private set; }

    public DeleteNotificationDto(int id)
    {
        ID = id;
    }
}
