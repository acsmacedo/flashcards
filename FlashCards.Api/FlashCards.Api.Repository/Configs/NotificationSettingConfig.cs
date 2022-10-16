using FlashCards.Api.Core.NotificationSettings;

namespace FlashCards.Api.Repository.Configs;

public class NotificationSettingConfig : IEntityTypeConfiguration<NotificationSetting>
{
    public void Configure(EntityTypeBuilder<NotificationSetting> builder)
    {
        builder
            .ToTable("notification_settings");

        builder
            .HasKey(x => x.ID)
            .HasName("pk_notification_setting_id");

        builder
            .Property(x => x.ID)
            .HasColumnName("notification_setting_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(NotificationSetting.NameMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("varchar")
            .HasMaxLength(NotificationSetting.DescriptionMaxLength)
            .IsRequired();

        builder.HasData(GetNotificationSettings());
    }

    private NotificationSetting[] GetNotificationSettings()
    {
        var result = new NotificationSetting[5];

        result[0] = GenerateNotificationSetting(
            id: -1,
            name: "Promoções e novidades",
            description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry.");

        result[1] = GenerateNotificationSetting(
            id: -2,
            name: "Novo seguidor",
            description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry.");

        result[2] = GenerateNotificationSetting(
            id: -3,
            name: "Atualizações de conteúdo",
            description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry.");

        result[3] = GenerateNotificationSetting(
            id: -4,
            name: "Sugestões de conteúdo",
            description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry.");

        result[4] = GenerateNotificationSetting(
            id: -5,
            name: "Avaliações e comentários",
            description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry.");

        return result;
    }

    private NotificationSetting GenerateNotificationSetting(
        int id,
        string name,
        string description)
    {
        var notificationSetting = new NotificationSetting(
            id: id,
            name: name,
            description: description);

        return notificationSetting;
    }
}
