namespace FlashCards.Api.Core.FlashCards;

public class FlashCardItem
{
    public const int FrontDescriptionMaxLength = 500;
    public const int VerseDescriptionMaxLength = 500;

    public int FlashCardItemID { get; private set; }
    public string FrontDescription { get; private set; }
    public string VerseDescription { get; private set; }
    public FlashCardCollection Collection { get; private set; } = FlashCardCollection.Empty;

    public FlashCardItem(
        int flashCardItemID, 
        string frontDescription,
        string verseDescription)
    {
        FlashCardItemID = flashCardItemID;
        FrontDescription = frontDescription;
        VerseDescription = verseDescription;
    }
}
