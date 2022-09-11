namespace FlashCards.Api.Core.FlashCards;

public class FlashCardTag
{
    public const int NameMaxLength = 80;

    public int FlashCardTagID { get; private set; }
    public string Name { get; private set; }
    public FlashCardCollection Collection { get; private set; } = FlashCardCollection.Empty;

    public FlashCardTag(int flashCardTagID, string name)
    {
        FlashCardTagID = flashCardTagID;
        Name = name;
    }
}
