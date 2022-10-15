namespace FlashCards.App.Models.Flashcards
{
    public class FlashcardItem
    {
        public int FlashCardItemID { get; private set; }
        public int FlashCardCollectionID { get; private set; }
        public string FrontDescription { get; private set; }
        public string VerseDescription { get; private set; }

        public FlashcardItem(
            int flashCardItemID,
            int flashCardCollectionID, 
            string frontDescription, 
            string verseDescription)
        {
            FlashCardItemID = flashCardItemID;
            FlashCardCollectionID = flashCardCollectionID;
            FrontDescription = frontDescription;
            VerseDescription = verseDescription;
        }
    }
}
