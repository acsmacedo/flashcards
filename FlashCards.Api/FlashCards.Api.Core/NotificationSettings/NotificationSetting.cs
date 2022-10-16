namespace FlashCards.Api.Core.NotificationSettings;

public class NotificationSetting
{
    public const int NameMaxLength = 80;
    public const int DescriptionMaxLength = 200;

    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public NotificationSetting(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
    }

    public NotificationSetting(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Edit(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
