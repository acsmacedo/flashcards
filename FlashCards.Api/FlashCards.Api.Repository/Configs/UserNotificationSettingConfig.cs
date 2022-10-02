using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Repository.Configs;

public class UserNotificationSettingConfig : IEntityTypeConfiguration<UserNotificationSetting>
{
    public void Configure(EntityTypeBuilder<UserNotificationSetting> builder)
    {
        builder
            .ToTable("user_notification_settings");

        builder
            .HasKey(x => new { x.UserID, x.NotificationSettingID })
            .HasName("pk_user_notification_setting_id");

        builder
            .Property(x => x.UserID)
            .HasColumnName("user_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.NotificationSettingID)
            .HasColumnName("notification_setting_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnType("int")
            .IsRequired();
    }
}
