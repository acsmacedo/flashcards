namespace FlashCards.Api.Service.DTO.FlashCards;

public class CreateFlashCardCollectionDto
{
    public int CategoryID { get; private set; }
    public int UserDirectoryID { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public IEnumerable<string> Tags { get; private set; }

    public CreateFlashCardCollectionDto(
        int categoryID,
        int userDirectoryID, 
        string name, 
        string description, 
        IEnumerable<string> tags)
    {
        CategoryID = categoryID;
        UserDirectoryID = userDirectoryID;
        Name = name;
        Description = description;
        Tags = tags;
    }
}
