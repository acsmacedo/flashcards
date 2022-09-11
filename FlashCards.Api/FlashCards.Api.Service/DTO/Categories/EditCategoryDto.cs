using FlashCards.Api.Core.Categories;

namespace FlashCards.Api.Service.DTO.Categories;

public class EditCategoryDto
{
    [Key]
    public int ID { get; private set; }

    [Required]
    [StringLength(Category.NameMaxLength)]
    public string Name { get; private set; }

    public EditCategoryDto(int id, string name)
    {
        ID = id;
        Name = name;
    }
}
