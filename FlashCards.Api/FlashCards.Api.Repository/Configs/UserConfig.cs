using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Repository.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("users");

        builder
            .HasKey(x => x.ID)
            .HasName("pk_user_id");

        builder
            .Property(x => x.ID)
            .HasColumnName("user_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.AccountID)
            .HasColumnName("account_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(User.NameMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Instagram)
            .HasColumnName("instagram")
            .HasColumnType("varchar")
            .HasMaxLength(User.InstagramMaxLength);

        builder
            .Property(x => x.Interests)
            .HasColumnName("interests")
            .HasColumnType("varchar")
            .HasMaxLength(User.InterestsMaxLength);

        builder
            .Property(x => x.Photo)
            .HasColumnName("photo")
            .HasColumnType("varchar")
            .HasMaxLength(User.PhotoMaxLength);

        builder
            .HasOne(x => x.Account)
            .WithOne()
            .HasForeignKey<User>(x => x.AccountID);

        builder
            .HasOne(x => x.SubscriptionType)
            .WithOne()
            .HasForeignKey<User>(x => x.SubscriptionTypeID);

        builder
            .HasMany(x => x.NotiicationSettings)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserID);
    }
}
