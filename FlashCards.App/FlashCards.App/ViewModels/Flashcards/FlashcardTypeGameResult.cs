namespace FlashCards.App.ViewModels.Flashcards
{
    public class FlashcardTypeGameResult
    {
        public int FlashcardItemID { get; private set; }
        public string MyAnswer { get; private set; }
        public bool IsSuccess { get; private set; }

        public FlashcardTypeGameResult(int flashcardItemID, string myAnswer, bool isSuccess)
        {
            FlashcardItemID = flashcardItemID;
            MyAnswer = myAnswer;
            IsSuccess = isSuccess;
        }
    }
}
