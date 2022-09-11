using FlashCards.Api.Core.FlashCards;

namespace FlashCards.Api.Repository.Configs;

public class FlashCardTagConfig : IEntityTypeConfiguration<FlashCardTag>
{
    public void Configure(EntityTypeBuilder<FlashCardTag> builder)
    {
        builder
            .ToTable("flash_card_tags");

        builder
            .HasKey(x => x.FlashCardTagID)
            .HasName("pk_flash_card_tag_id");

        builder
            .Property(x => x.FlashCardTagID)
            .HasColumnName("flash_card_tag_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(FlashCardTag.NameMaxLength)
            .IsRequired();
    }
}
