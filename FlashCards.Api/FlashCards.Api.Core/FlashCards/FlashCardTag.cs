namespace FlashCards.Api.Core.FlashCards;

public class FlashCardTag
{
    public const int NameMaxLength = 80;

    public int FlashCardCollectionID { get; private set; }
    public string Name { get; private set; }
    public FlashCardCollection? Collection { get; private set; }

    public FlashCardTag(string name)
    {
        Name = name;
    }
}
