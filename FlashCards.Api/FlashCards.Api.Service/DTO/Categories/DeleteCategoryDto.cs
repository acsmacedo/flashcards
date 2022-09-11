namespace FlashCards.Api.Service.DTO.Categories;

public class DeleteCategoryDto
{
    [Key]
    public int ID { get; private set; }

    public DeleteCategoryDto(int id)
    {
        ID = id;
    }
}
