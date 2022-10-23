namespace FlashCards.App.ViewModels.Flashcards
{
    public class FlashcardRememberGameResult
    {
        public int FlashcardItemID { get; private set; }
        public bool? IsSuccess { get; private set; }

        public FlashcardRememberGameResult(int flashcardItemID)
        {
            FlashcardItemID = flashcardItemID;
        }

        public void Change(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
