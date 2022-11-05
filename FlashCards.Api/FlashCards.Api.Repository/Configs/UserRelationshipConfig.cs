using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Repository.Configs;

public class UserRelationshipConfig : IEntityTypeConfiguration<UserRelationship>
{
    public void Configure(EntityTypeBuilder<UserRelationship> builder)
    {
        builder
            .ToTable("user_relationships");

        builder
            .HasKey(x => new { x.FollowedID, x.FollowerID })
            .HasName("pk_user_relationship");

        builder
            .Property(x => x.FollowedID)
            .HasColumnName("followed_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.FollowerID)
            .HasColumnName("follower_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.EnableNotification)
            .HasColumnName("enable_notification")
            .HasColumnType("bit")
            .IsRequired();

        builder
            .HasOne(x => x.Follower)
            .WithMany(x => x.Following)
            .HasForeignKey(x => x.FollowerID)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Followed)
            .WithMany(x => x.Followers)
            .HasForeignKey(x => x.FollowedID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
