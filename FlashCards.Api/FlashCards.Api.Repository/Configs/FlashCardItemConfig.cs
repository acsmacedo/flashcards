using FlashCards.Api.Core.FlashCards;

namespace FlashCards.Api.Repository.Configs;

public class FlashCardItemConfig : IEntityTypeConfiguration<FlashCardItem>
{
    public void Configure(EntityTypeBuilder<FlashCardItem> builder)
    {
        builder
            .ToTable("flash_card_items");

        builder
            .HasKey(x => x.FlashCardItemID)
            .HasName("pk_flash_card_id");

        builder
            .Property(x => x.FlashCardItemID)
            .HasColumnName("flash_card_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.FrontDescription)
            .HasColumnName("front_description")
            .HasColumnType("varchar")
            .HasMaxLength(FlashCardItem.FrontDescriptionMaxLength)
            .IsRequired();

        builder
            .Property(x => x.VerseDescription)
            .HasColumnName("verse_description")
            .HasColumnType("varchar")
            .HasMaxLength(FlashCardItem.VerseDescriptionMaxLength)
            .IsRequired();
    }
}
