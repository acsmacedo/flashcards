using FlashCards.Api.Core.Categories;

namespace FlashCards.Api.Service.DTO.Categories;

public class CreateCategoryDto
{
    [Required]
    [StringLength(Category.NameMaxLength)]
    public string Name { get; private set; }

    [Required]
    [StringLength(Category.ImageMaxLength)]
    public string Image { get; private set; }

    public CreateCategoryDto(string name, string image)
    {
        Name = name;
        Image = image;
    }
}
