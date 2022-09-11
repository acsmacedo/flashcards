namespace FlashCards.Api.Service.DTO.FlashCards;

public class AddFlashCardRatingDto
{
    public int FlashCardCollectionID { get; private set; }
    public int UserID { get; private set; }
    public int Rating { get; private set; }
    public string Comment { get; private set; } = string.Empty;

    public AddFlashCardRatingDto(
        int flashCardCollectionID, 
        int userID,
        int rating, 
        string comment)
    {
        FlashCardCollectionID = flashCardCollectionID;
        UserID = userID;
        Rating = rating;
        Comment = comment;
    }
}
