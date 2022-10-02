using FlashCards.Api.Core.NotificationSettings;
using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Service.DTO.NotificationSettings;

public class NotificationSettingByUserDto
{
    public int UserID { get; private set; }
    public int NotificationSettingID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public NotificationSettingStatus Status { get; private set; }

    public NotificationSettingByUserDto(NotificationSetting data, User user)
    {
        NotificationSettingID = data.ID;
        UserID = user.ID;
        Name = data.Name;
        Description = data.Description;
        Status = user.GetNotificationStatus(data.ID);
    }
}
