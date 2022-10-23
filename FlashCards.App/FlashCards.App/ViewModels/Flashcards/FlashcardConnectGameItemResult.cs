using FlashCards.App.Models.Flashcards;
using FlashCards.App.Models;
using System;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class FlashcardConnectGameItemResult : BaseModel
    {
        private static Random _random = new Random();

        public int FlashcardItemID { get; private set; }
        public string Text { get; set; }
        public bool IsAsk { get; set; }
        public int Sequence { get; set; }

        private FlashcardConnectGameItemStatus _status;
        public FlashcardConnectGameItemStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        public FlashcardConnectGameItemResult(FlashcardItem card, bool isAsk)
        {
            FlashcardItemID = card.FlashCardItemID;
            IsAsk = isAsk;
            Text = isAsk ? card.FrontDescription : card.VerseDescription;
            Sequence = _random.Next();
        }

        public void Change(FlashcardConnectGameItemStatus status)
        {
            Status = status;
        }
    }

    public enum FlashcardConnectGameItemStatus
    {
        NotSelected,
        Selected,
        Success
    }
}
