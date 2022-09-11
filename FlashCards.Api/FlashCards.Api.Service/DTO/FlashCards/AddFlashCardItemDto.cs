namespace FlashCards.Api.Service.DTO.FlashCards;

public class AddFlashCardItemDto
{
    public int FlashCardCollectionID { get; private set; }
    public string FrontDescription { get; private set; }
    public string VerseDescription { get; private set; }

    public AddFlashCardItemDto(
        int flashCardCollectionID, 
        string frontDescription, 
        string verseDescription)
    {
        FlashCardCollectionID = flashCardCollectionID;
        FrontDescription = frontDescription;
        VerseDescription = verseDescription;
    }
}
