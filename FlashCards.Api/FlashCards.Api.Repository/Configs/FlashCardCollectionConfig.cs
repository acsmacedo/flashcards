using FlashCards.Api.Core.FlashCards;

namespace FlashCards.Api.Repository.Configs;

public class FlashCardCollectionConfig : IEntityTypeConfiguration<FlashCardCollection>
{
    public void Configure(EntityTypeBuilder<FlashCardCollection> builder)
    {
        builder
            .ToTable("flash_card_collections");

        builder
            .HasKey(x => x.ID)
            .HasName("pk_flash_card_collection_id");

        builder
            .Property(x => x.ID)
            .HasColumnName("flash_card_collection_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.CategoryID)
            .HasColumnName("category_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.UserDirectoryID)
            .HasColumnName("user_directory_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(FlashCardCollection.NameMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("varchar")
            .HasMaxLength(FlashCardCollection.DescriptionMaxLength);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.FlashCardCollections)
            .HasForeignKey(x => x.CategoryID);

        builder
            .HasOne(x => x.UserDirectory)
            .WithMany(x => x.FlashCardCollections)
            .HasForeignKey(x => x.UserDirectoryID);

        builder
            .HasMany(x => x.Cards)
            .WithOne(x => x.Collection)
            .HasForeignKey(x => x.FlashCardCollectionID);

        builder
            .HasMany(x => x.Tags)
            .WithOne(x => x.Collection)
            .HasForeignKey(x => x.FlashCardCollectionID);

        builder
            .HasMany(x => x.Ratings)
            .WithOne(x => x.Collection)
            .HasForeignKey(x => x.FlashCardCollectionID);
    }
}
