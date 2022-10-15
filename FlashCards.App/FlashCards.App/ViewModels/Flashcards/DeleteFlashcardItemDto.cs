namespace FlashCards.App.ViewModels.Flashcards
{
    public class DeleteFlashcardItemDto
    {
        public int FlashcardCollectionID { get; private set; }
        public int FlashcardItemID { get; private set; }

        public DeleteFlashcardItemDto(int flashcardCollectionID, int flashcardItemID)
        {
            FlashcardCollectionID = flashcardCollectionID;
            FlashcardItemID = flashcardItemID;
        }
    }
}
