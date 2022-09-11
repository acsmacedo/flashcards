namespace FlashCards.Api.Service.DTO.Notifications;

public class ReadNotificationDto
{
    public int ID { get; private set; }

    public ReadNotificationDto(int id)
    {
        ID = id;
    }
}
