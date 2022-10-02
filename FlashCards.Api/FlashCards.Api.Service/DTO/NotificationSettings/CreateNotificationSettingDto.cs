using FlashCards.Api.Core.NotificationSettings;

namespace FlashCards.Api.Service.DTO.NotificationSettings;

public class CreateNotificationSettingDto
{
    [Required]
    [StringLength(NotificationSetting.NameMaxLength)]
    public string Name { get; private set; }

    [Required]
    [StringLength(NotificationSetting.DescriptionMaxLength)]
    public string Description { get; private set; }

    public CreateNotificationSettingDto(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
