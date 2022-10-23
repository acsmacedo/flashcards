using FlashCards.App.Models.Flashcards;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class FlashcardChooseGameResult
    {
        public int FlashcardItemID { get; private set; }
        public int? MyAnswer { get; private set; }
        public bool? IsSuccess { get; private set; }
        public bool CanAnser { get; private set; }
        public ObservableCollection<FlashcardChooseGameItemResult> Answers { get; private set; }

        public FlashcardChooseGameResult(FlashcardItem card, IEnumerable<FlashcardItem> allCards)
        {
            FlashcardItemID = card.FlashCardItemID;
            MyAnswer = null;
            IsSuccess = null;
            CanAnser = true;

            var possiblesAnswers = allCards
                .Select(x => new FlashcardChooseGameItemResult(x))
                .OrderBy(x => x.Sequence)
                .ToList();

            var answers = new List<FlashcardChooseGameItemResult>();

            answers.Add(possiblesAnswers.First(x => x.FlashcardItemID == FlashcardItemID));

            var count = Math.Min(possiblesAnswers.Count() - 1, 4);

            for (var i = 0; i < count; i++)
            {
                var index = 0;
                var isNotAdd = true;

                while (isNotAdd)
                {
                    var item = possiblesAnswers[index];

                    if (answers.Contains(item))
                    {
                        index++;
                    }
                    else
                    {
                        answers.Add(item);
                        isNotAdd = false;
                    }
                }
            }

            answers = answers.OrderBy(x => x.Sequence).ToList();

            Answers = new ObservableCollection<FlashcardChooseGameItemResult>();

            foreach (var item in answers)
            {
                Answers.Add(item);
            }
        }

        public void Answer(int flashcardItemID)
        {
            MyAnswer = flashcardItemID;
            IsSuccess = flashcardItemID == FlashcardItemID;
            CanAnser = false;

            foreach (var item in Answers)
            {
                item.Change(MyAnswer.Value, FlashcardItemID);
            }
        }
    }
}
