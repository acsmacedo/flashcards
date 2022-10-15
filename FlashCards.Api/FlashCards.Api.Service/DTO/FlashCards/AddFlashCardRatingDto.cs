namespace FlashCards.Api.Service.DTO.FlashCards;

public class AddFlashCardRatingDto
{
    public int FlashCardCollectionID { get; private set; }
    public int EvaluatorID { get; private set; }
    public int Rating { get; private set; }
    public string Comment { get; private set; } = string.Empty;

    public AddFlashCardRatingDto(
        int flashCardCollectionID, 
        int evaluatorID,
        int rating, 
        string comment)
    {
        FlashCardCollectionID = flashCardCollectionID;
        EvaluatorID = evaluatorID;
        Rating = rating;
        Comment = comment;
    }
}
