namespace FlashCards.Api.Service.DTO.FlashCards;

public class RemoveFlashCardItemDto
{
    public int FlashCardCollectionID { get; private set; }
    public int FlashCardItemID { get; private set; }

    public RemoveFlashCardItemDto(
        int flashCardCollectionID, 
        int flashCardItemID)
    {
        FlashCardCollectionID = flashCardCollectionID;
        FlashCardItemID = flashCardItemID;
    }
}
