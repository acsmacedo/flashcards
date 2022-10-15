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

        builder.HasData(
            new Category(-1, "Administração", @"http://acsmacedo.somee.com/images/categories/categoria_administracao.png"),
            new Category(-2, "Arquitetura", @"http://acsmacedo.somee.com/images/categories/categoria_arquitetura.png"),
            new Category(-3, "Design", @"http://acsmacedo.somee.com/images/categories/categoria_design.png"),
            new Category(-4, "Finanças", @"http://acsmacedo.somee.com/images/categories/categoria_financas.png"),
            new Category(-5, "Geografia", @"http://acsmacedo.somee.com/images/categories/categoria_geografia.png"),
            new Category(-6, "Literatura", @"http://acsmacedo.somee.com/images/categories/categoria_literatura.png"),
            new Category(-7, "Programação", @"http://acsmacedo.somee.com/images/categories/categoria_programacao.png"),
            new Category(-8, "Saúde", @"http://acsmacedo.somee.com/images/categories/categoria_saude.png"));
    }
}
