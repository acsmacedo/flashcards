using FlashCards.Api.Core.Directories;

namespace FlashCards.Api.Repository.Configs;

public class UserDirectoryConfig : IEntityTypeConfiguration<UserDirectory>
{
    public void Configure(EntityTypeBuilder<UserDirectory> builder)
    {
        builder
            .ToTable("user_directories");

        builder
            .HasKey(x => x.ID)
            .HasName("pk_user_directory_id");

        builder
            .Property(x => x.ID)
            .HasColumnName("user_directory_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.UserDirectoryParentID)
            .HasColumnName("user_directory_parent_id")
            .HasColumnType("int");

        builder
            .Property(x => x.UserID)
            .HasColumnName("user_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(UserDirectory.NameMaxLength)
            .IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Directories)
            .HasForeignKey(x => x.UserID);

        builder
            .HasOne(x => x.Parent)
            .WithMany(x => x.Children)
            .HasForeignKey(x => x.UserDirectoryParentID);
    }
}
