using FlashCards.Api.Core.Categories;
using FlashCards.Api.Core.Directories;

namespace FlashCards.Api.Core.FlashCards;

public class FlashCardCollection
{
    public const int NameMaxLength = 80;
    public const int DescriptionMaxLength = 300;

    public int FlashCardCollectionID { get; private set; }
    public int CategoryID { get; private set; }
    public int UserDirectoryID { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public UserDirectory UserDirectory { get; private set; } = UserDirectory.Empty;
    public Category Category { get; private set; } = Category.Empty;

    public FlashCardCollection(
        int flashCardCollectionID,
        int categoryID, 
        int userDirectoryID,
        string name, 
        string description)
    {
        FlashCardCollectionID = flashCardCollectionID;
        CategoryID = categoryID;
        UserDirectoryID = userDirectoryID;
        Name = name;
        Description = description;
    }

    private List<FlashCardTag> _tags = new();
    public IReadOnlyCollection<FlashCardTag> Tags => _tags;

    private List<FlashCardItem> _cards = new();
    public IReadOnlyCollection<FlashCardItem> Cards => _cards;

    private List<FlashCardRating> _ratigns = new();
    public IReadOnlyCollection<FlashCardRating> Ratings => _ratigns;

    public static FlashCardCollection Empty => new(0, 0, 0, string.Empty, string.Empty);
}
