using FlashCards.Api.Core.Notifications;

namespace FlashCards.Api.Repository.Configs;

public class NotificationConfig : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder
            .ToTable("notifications");

        builder
            .HasKey(x => x.ID)
            .HasName("pk_notification_id");

        builder
            .Property(x => x.ID)
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
            .Property(x => x.SentDate)
            .HasColumnName("sent_date")
            .HasColumnType("datetime");

        builder
            .Property(x => x.ReadDate)
            .HasColumnName("read_date")
            .HasColumnType("datetime");

        builder
            .Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.Title)
            .HasColumnName("title")
            .HasColumnType("varchar")
            .HasMaxLength(Notification.TitleMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Message)
            .HasColumnName("message")
            .HasColumnType("varchar")
            .HasMaxLength(Notification.MessageMaxLength)
            .IsRequired();
    }
}
