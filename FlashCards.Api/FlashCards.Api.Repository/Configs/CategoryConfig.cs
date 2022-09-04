using FlashCards.Api.Core.Categories;

namespace FlashCards.Api.Repository.Configs;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
    }
}