using FlashCards.Api.Core.FlashCards;

namespace FlashCards.Api.Repository.Configs;

public class FlashCardRatingConfig : IEntityTypeConfiguration<FlashCardRating>
{
    public void Configure(EntityTypeBuilder<FlashCardRating> builder)
    {
        builder
            .ToTable("flash_card_ratings");

        builder
            .HasKey(x => x.FlashCardRatingID)
            .HasName("pk_flash_card_rating_id");

        builder
            .Property(x => x.FlashCardRatingID)
            .HasColumnName("flash_card_rating_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.FlashCardCollectionID)
            .HasColumnName("flash_card_collection_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.UserID)
            .HasColumnName("user_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.Rating)
            .HasColumnName("rating")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.Comment)
            .HasColumnName("comment")
            .HasColumnType("varchar")
            .HasMaxLength(FlashCardRating.CommentMaxLength);

        builder
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}