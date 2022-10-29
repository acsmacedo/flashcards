using FlashCards.Api.Core.Categories;
using FlashCards.Api.Core.Directories;

namespace FlashCards.Api.Core.FlashCards;

public class FlashCardCollection
{
    public const int NameMaxLength = 80;
    public const int DescriptionMaxLength = 300;

    public int ID { get; private set; }
    public int CategoryID { get; private set; }
    public int UserDirectoryID { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public UserDirectory? UserDirectory { get; private set; }
    public Category? Category { get; private set; }

    private FlashCardCollection() { }

    public FlashCardCollection(
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

        _tags = tags.Select(x => new FlashCardTag(x)).ToList();
    }

    public void Edit(
        int categoryID,
        string name,
        string description,
        IEnumerable<string> tags)
    {
        CategoryID = categoryID;
        Name = name;
        Description = description;

        _tags = tags.Select(x => new FlashCardTag(x)).ToList();
    }

    private List<FlashCardTag> _tags = new();
    public IReadOnlyCollection<FlashCardTag> Tags => _tags;

    private List<FlashCardItem> _cards = new();
    public IReadOnlyCollection<FlashCardItem> Cards => _cards;

    public void AddCardItem(
        string frontDescription,
        string verseDescription)
    {
        _cards.Add(new FlashCardItem(
            frontDescription: frontDescription,
            verseDescription: verseDescription));
    }

    public void RemoveCardItem(int flashCardItemID)
    {
        var card = _cards.FirstOrDefault(x => x.FlashCardItemID == flashCardItemID);

        if (card != null)
        {
            _cards.Remove(card);
        }
    }

    public void EditCardItem(
        int flashCardItemID,
        string frontDescription,
        string verseDescription)
    {
        var card = _cards.FirstOrDefault(x => x.FlashCardItemID == flashCardItemID);

        if (card != null)
        {
            card.Edit(
                frontDescription: frontDescription,
                verseDescription: verseDescription);
        }
    }

    private List<FlashCardRating> _ratigns = new();
    public IReadOnlyCollection<FlashCardRating> Ratings => _ratigns;

    public void AddRating(
        int userID,
        int rating,
        string comment)
    {
        var item = _ratigns.FirstOrDefault(x => x.UserID == userID);

        if (item == null)
        {
            _ratigns.Add(new FlashCardRating(
                userID: userID,
                rating: rating,
                comment: comment));
        }
        else
        {
            item.Update(rating, comment);
        }
    }
}
