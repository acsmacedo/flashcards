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

        builder.HasData(GetCategories());
    }

    private Category[] GetCategories()
    {
        var result = new Category[8];

        result[0] = GenerateCategory(
            id: -1,
            name: "Administração",
            image: @"http://acsmacedo.somee.com/images/categories/categoria_administracao.png");

        result[1] = GenerateCategory(
            id: -2,
            name: "Arquitetura",
            image: @"http://acsmacedo.somee.com/images/categories/categoria_arquitetura.png");

        result[2] = GenerateCategory(
            id: -3,
            name: "Design",
            image: @"http://acsmacedo.somee.com/images/categories/categoria_design.png");

        result[3] = GenerateCategory(
            id: -4,
            name: "Finanças",
            image: @"http://acsmacedo.somee.com/images/categories/categoria_financas.png");

        result[4] = GenerateCategory(
            id: -5,
            name: "Geografia",
            image: @"http://acsmacedo.somee.com/images/categories/categoria_geografia.png");

        result[5] = GenerateCategory(
            id: -6,
            name: "Literatura",
            image: @"http://acsmacedo.somee.com/images/categories/categoria_literatura.png");

        result[6] = GenerateCategory(
            id: -7,
            name: "Programação",
            image: @"http://acsmacedo.somee.com/images/categories/categoria_programacao.png");

        result[7] = GenerateCategory(
            id: -8,
            name: "Saúde",
            image: @"http://acsmacedo.somee.com/images/categories/categoria_saude.png");

        return result;
    }

    private Category GenerateCategory(
        int id,
        string name,
        string image)
    {
        var category = new Category(
            id: id,
            name: name,
            image: image);

        return category;
    }
}
