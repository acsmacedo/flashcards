namespace FlashCards.Api.Service.DTO.FlashCards;

public class EditFlashCardCollectioDto
{
    public int ID { get; private set; }
    public int CategoryID { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public IEnumerable<string> Tags { get; private set; }

    public EditFlashCardCollectioDto(
        int id, 
        int categoryID,
        string name,
        string description,
        IEnumerable<string> tags)
    {
        ID = id;
        CategoryID = categoryID;
        Name = name;
        Description = description;
        Tags = tags;
    }
}
