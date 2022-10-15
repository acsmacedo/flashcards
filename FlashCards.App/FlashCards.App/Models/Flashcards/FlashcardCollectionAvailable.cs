namespace FlashCards.App.Models.Flashcards
{
    public class FlashcardCollectionAvailable
    {
        public int ID { get; private set; }
        public int UserID { get; private set; }
        public string UserName { get; private set; }
        public string UserPhoto { get; private set; }
        public int Stars { get; private set; }
        public string Comment { get; private set; }

        public FlashcardCollectionAvailable(
            int id, 
            int userID,
            string userName, 
            string userPhoto, 
            int stars,
            string comment)
        {
            ID = id;
            UserID = userID;
            UserName = userName;
            UserPhoto = userPhoto;
            Stars = stars;
            Comment = comment;
        }
    }
}
