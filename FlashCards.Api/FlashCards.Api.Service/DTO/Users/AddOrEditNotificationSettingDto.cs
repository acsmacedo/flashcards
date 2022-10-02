using FlashCards.Api.Core.NotificationSettings;

namespace FlashCards.Api.Service.DTO.Users;

public class AddOrEditNotificationSettingDto
{
    public int UserID { get; private set; }
    public int NotificationSettingID { get; private set; }
    public NotificationSettingStatus Status { get; private set; }

    public AddOrEditNotificationSettingDto(
        int userID,
        int notificationSettingID,
        NotificationSettingStatus status)
    {
        UserID = userID;
        NotificationSettingID = notificationSettingID;
        Status = status;
    }
}
