using FlashCards.Api.Core.NotificationSettings;

namespace FlashCards.Api.Service.DTO.NotificationSettings;

public class NotificationSettingDto
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public NotificationSettingDto(NotificationSetting data)
    {
        ID = data.ID;
        Name = data.Name;
        Description = data.Description;
    }
}
