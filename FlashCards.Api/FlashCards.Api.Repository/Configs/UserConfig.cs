using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Repository.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("users");

        builder
            .HasKey(x => x.UserID)
            .HasName("pk_user_id");

        builder
            .Property(x => x.UserID)
            .HasColumnName("user_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
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
    }
}
