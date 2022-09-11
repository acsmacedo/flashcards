namespace FlashCards.Api.Service.DTO.FlashCards;

public class EditFlashCardItemDto
{
    public int FlashCardCollectionID { get; private set; }
    public int FlashCardItemID { get; private set; }
    public string FrontDescription { get; private set; }
    public string VerseDescription { get; private set; }

    public EditFlashCardItemDto(
        int flashCardCollectionID, 
        int flashCardItemID,
        string frontDescription,
        string verseDescription)
    {
        FlashCardCollectionID = flashCardCollectionID;
        FlashCardItemID = flashCardItemID;
        FrontDescription = frontDescription;
        VerseDescription = verseDescription;
    }
}
