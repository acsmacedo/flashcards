using FlashCards.Api.Core.Notifications;

namespace FlashCards.Api.Repository.Configs;

public class NotificationConfig : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder
            .ToTable("notifications");

        builder
            .HasKey(x => x.NotificationID)
            .HasName("pk_notification_id");

        builder
            .Property(x => x.NotificationID)
            .HasColumnName("notification_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.UserID)
            .HasColumnName("user_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.NotificationDate)
            .HasColumnName("notification_date")
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(x => x.Read)
            .HasColumnName("read")
            .HasColumnType("bit")
            .IsRequired();

        builder
            .Property(x => x.Message)
            .HasColumnName("message")
            .HasColumnType("varchar")
            .HasMaxLength(Notification.MessageMaxLength)
            .IsRequired();
    }
}
