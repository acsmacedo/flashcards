using FlashCards.Api.Core.NotificationSettings;

namespace FlashCards.Api.Service.DTO.NotificationSettings;

public class EditNotificationSettingDto
{
    [Key]
    public int ID { get; private set; }

    [Required]
    [StringLength(NotificationSetting.NameMaxLength)]
    public string Name { get; private set; }

    [Required]
    [StringLength(NotificationSetting.DescriptionMaxLength)]
    public string Description { get; private set; }

    public EditNotificationSettingDto(
        int id, 
        string name,
        string description)
    {
        ID = id;
        Name = name;
        Description = description;
    }
}
