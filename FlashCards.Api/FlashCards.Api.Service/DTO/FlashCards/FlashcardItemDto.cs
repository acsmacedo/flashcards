using FlashCards.Api.Core.FlashCards;

namespace FlashCards.Api.Service.DTO.FlashCards
{
    public class FlashcardItemDto
    {
        public int FlashCardItemID { get; private set; }
        public int FlashCardCollectionID { get; private set; }
        public string FrontDescription { get; private set; }
        public string VerseDescription { get; private set; }

        public FlashcardItemDto(FlashCardItem data)
        {
            FlashCardItemID = data.FlashCardItemID;
            FlashCardCollectionID = data.FlashCardCollectionID;
            FrontDescription = data.FrontDescription;
            VerseDescription = data.VerseDescription;
        }
    }
}
