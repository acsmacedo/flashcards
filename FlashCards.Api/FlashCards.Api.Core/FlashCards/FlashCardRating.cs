namespace FlashCards.Api.Core.FlashCards;

public class FlashCardRating
{
    public const int CommentMaxLength = 1000;

    public int FlashCardRatingID { get; private set; }
    public int FlashCardCollectionID { get; private set; }
    public int UserID { get; private set; }
    public int Rating { get; private set; }
    public string Comment { get; private set; } = string.Empty;
    public FlashCardCollection? Collection { get; private set; }

    public FlashCardRating(
        int userID, 
        int rating, 
        string comment)
    {
        UserID = userID;
        Rating = rating;
        Comment = comment;
    }
}
