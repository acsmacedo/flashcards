namespace FlashCards.Api.Core.FlashCards;

public class FlashCardItem
{
    public const int FrontDescriptionMaxLength = 500;
    public const int VerseDescriptionMaxLength = 500;

    public int FlashCardItemID { get; private set; }
    public int FlashCardCollectionID { get; private set; }
    public string FrontDescription { get; private set; }
    public string VerseDescription { get; private set; }
    public FlashCardCollection? Collection { get; private set; }

    public FlashCardItem(
        string frontDescription,
        string verseDescription)
    {
        FrontDescription = frontDescription;
        VerseDescription = verseDescription;
    }

    public void Edit(
        string frontDescription,
        string verseDescription)
    {
        FrontDescription = frontDescription;
        VerseDescription = verseDescription;
    }
}
