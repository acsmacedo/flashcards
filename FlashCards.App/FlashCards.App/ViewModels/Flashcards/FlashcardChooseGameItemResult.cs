using FlashCards.App.Models.Flashcards;
using System;
using FlashCards.App.Models;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class FlashcardChooseGameItemResult : BaseModel
    {
        private static Random _random = new Random();

        public int FlashcardItemID { get; private set; }
        public string Answer { get; set; }
        public int Sequence { get; private set; }

        private bool _isSuccess;
        public bool IsSuccess
        {
            get => _isSuccess;
            set
            {
                _isSuccess = value;
                RaisePropertyChanged(nameof(IsSuccess));
            }
        }

        private bool _showAnswer;
        public bool ShowAnswer
        {
            get => _showAnswer;
            set
            {
                _showAnswer = value;
                RaisePropertyChanged(nameof(ShowAnswer));
            }
        }

        private bool _notShowAnswer;
        public bool NotShowAnswer
        {
            get => _notShowAnswer;
            set
            {
                _notShowAnswer = value;
                RaisePropertyChanged(nameof(NotShowAnswer));
            }
        }

        public FlashcardChooseGameItemResult(FlashcardItem card)
        {
            FlashcardItemID = card.FlashCardItemID;
            Answer = card.VerseDescription;
            IsSuccess = false;
            ShowAnswer = false;
            NotShowAnswer = true;
            Sequence = _random.Next();
        }

        public void Change(int myAnswer, int rightAnswer)
        {
            if (FlashcardItemID == myAnswer || FlashcardItemID == rightAnswer)
            {
                ShowAnswer = true;
                NotShowAnswer = false;
                IsSuccess = FlashcardItemID == rightAnswer ? true : myAnswer == rightAnswer;
            }
        }
    }
}
