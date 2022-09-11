using FlashCards.Api.Core.Categories;

namespace FlashCards.Api.Service.DTO.Categories;

public class CategoryDto
{
    public int ID { get; private set; }
    public string Name { get; private set; }

    public CategoryDto(Category data)
    {
        ID = data.ID;
        Name = data.Name;
    }
}
