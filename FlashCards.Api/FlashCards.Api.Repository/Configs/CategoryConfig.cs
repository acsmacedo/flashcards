using FlashCards.Api.Core.Categories;

namespace FlashCards.Api.Repository.Configs;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .ToTable("categories");

        builder
            .HasKey(x => x.ID)
            .HasName("pk_category_id");

        builder
            .Property(x => x.ID)
            .HasColumnName("category_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(Category.NameMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Image)
            .HasColumnName("image")
            .HasColumnType("varchar")
            .HasMaxLength(Category.ImageMaxLength)
            .IsRequired();
    }
}
