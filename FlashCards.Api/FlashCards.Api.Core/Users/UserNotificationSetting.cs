using FlashCards.Api.Core.NotificationSettings;

namespace FlashCards.Api.Core.Users;

public class UserNotificationSetting
{
    public int UserID { get; private set; }
    public int NotificationSettingID { get; private set; }
    public NotificationSettingStatus Status { get; private set; }

    public virtual User? User { get; private set; }
    public virtual NotificationSetting? NotificationSetting { get; private set; }

    public UserNotificationSetting(
        int notificationSettingID, 
        NotificationSettingStatus status)
    {
        NotificationSettingID = notificationSettingID;
        Status = status;
    }

    public void Edit(NotificationSettingStatus status)
    {
        Status = status;
    }
}
