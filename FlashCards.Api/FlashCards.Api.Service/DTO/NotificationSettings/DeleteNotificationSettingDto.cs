namespace FlashCards.Api.Service.DTO.NotificationSettings;

public class DeleteNotificationSettingDto
{
    [Key]
    public int ID { get; private set; }

    public DeleteNotificationSettingDto(int id)
    {
        ID = id;
    }
}
