using FlashCards.Api.Core.FlashCards;
using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Service.DTO.FlashCards
{
    public class FlashCardRatingDto
    {
        public int ID { get; private set; }
        public int UserID { get; private set; }
        public string UserName { get; private set; }
        public string UserPhoto { get; private set; }
        public int Stars { get; private set; }
        public string Comment { get; private set; }

        public FlashCardRatingDto(FlashCardRating data)
        {
            ID = data.FlashCardRatingID;
            UserID = data.UserID;
            UserName = data.User?.Name ?? string.Empty;
            UserPhoto = string.IsNullOrEmpty(data.User?.Photo) ? User.PhotoDefault : data.User.Photo;
            Stars = data.Rating;
            Comment = data.Comment;
        }
    }
}
