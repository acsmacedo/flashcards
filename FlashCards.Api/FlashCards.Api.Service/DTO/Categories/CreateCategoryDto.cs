using FlashCards.Api.Core.Categories;

namespace FlashCards.Api.Service.DTO.Categories;

public class CreateCategoryDto
{
    [Required]
    [StringLength(Category.NameMaxLength)]
    public string Name { get; private set; }

    public CreateCategoryDto(string name)
    {
        Name = name;
    }
}
