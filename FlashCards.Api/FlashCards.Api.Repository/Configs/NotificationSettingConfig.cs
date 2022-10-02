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
    }
}
