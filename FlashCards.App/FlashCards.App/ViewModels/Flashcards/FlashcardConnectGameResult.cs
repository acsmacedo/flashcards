using FlashCards.App.Models.Flashcards;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class FlashcardConnectGameResult
    {
        public int FlashcardItemID { get; private set; }
        public bool IsCompleted { get; private set; }

        public ObservableCollection<FlashcardConnectGameItemResult> Asks { get; private set; }
        public ObservableCollection<FlashcardConnectGameItemResult> Answers { get; private set; }

        public FlashcardConnectGameResult(FlashcardItem card, IEnumerable<FlashcardItem> allCards)
        {
            FlashcardItemID = card.FlashCardItemID;
            IsCompleted = false;

            var possibleAsks= allCards
                .Select(x => new FlashcardConnectGameItemResult(x, true))
                .OrderBy(x => x.Sequence)
                .ToList();

            var possibleAnswers = allCards
                .Select(x => new FlashcardConnectGameItemResult(x, false))
                .OrderBy(x => x.Sequence)
                .ToList();

            var asks = new List<FlashcardConnectGameItemResult>();
            var answers = new List<FlashcardConnectGameItemResult>();

            asks.Add(possibleAsks.First(x => x.FlashcardItemID == FlashcardItemID));
            answers.Add(possibleAnswers.First(x => x.FlashcardItemID == FlashcardItemID));

            var count = Math.Min(possibleAsks.Count() - 1, 4);

            for (var i = 0; i < count; i++)
            {
                var index = 0;
                var isNotAdd = true;

                while (isNotAdd)
                {
                    var answer = possibleAnswers[index];
                    var ask = possibleAsks.First(x => x.FlashcardItemID == answer.FlashcardItemID);

                    if (answers.Contains(answer))
                    {
                        index++;
                    }
                    else
                    {
                        asks.Add(ask);
                        answers.Add(answer);
                        isNotAdd = false;
                    }
                }
            }

            answers = answers.OrderBy(x => x.Sequence).ToList();
            asks = asks.OrderBy(x => x.Sequence).ToList();

            Asks = new ObservableCollection<FlashcardConnectGameItemResult>();

            foreach (var item in asks)
            {
                Asks.Add(item);
            }

            Answers = new ObservableCollection<FlashcardConnectGameItemResult>();

            foreach (var item in answers)
            {
                Answers.Add(item);
            }
        }

        public void Answer(FlashcardConnectGameItemResult item)
        {
            if (item.IsAsk)
            {
                var ask = Asks.First(x => x.FlashcardItemID == item.FlashcardItemID);

                if (ask.Status == FlashcardConnectGameItemStatus.Success)
                    return;

                if (Asks.Any(x => x.Status == FlashcardConnectGameItemStatus.Selected))
                    return;

                var answer = Answers.FirstOrDefault(x => x.Status == FlashcardConnectGameItemStatus.Selected);

                if (answer != null)
                {
                    if (ask.FlashcardItemID == answer.FlashcardItemID)
                    {
                        ask.Change(FlashcardConnectGameItemStatus.Success);
                        answer.Change(FlashcardConnectGameItemStatus.Success);
                    }
                    else
                    {
                        ask.Change(FlashcardConnectGameItemStatus.NotSelected);
                        answer.Change(FlashcardConnectGameItemStatus.NotSelected);
                    }
                }
                else
                {
                    ask.Change(FlashcardConnectGameItemStatus.Selected);
                }
            }
            else
            {
                var answer = Answers.First(x => x.FlashcardItemID == item.FlashcardItemID);

                if (answer.Status == FlashcardConnectGameItemStatus.Success)
                    return;

                if (Answers.Any(x => x.Status == FlashcardConnectGameItemStatus.Selected))
                    return;

                var ask = Asks.FirstOrDefault(x => x.Status == FlashcardConnectGameItemStatus.Selected);

                if (ask != null)
                {
                    if (ask.FlashcardItemID == answer.FlashcardItemID)
                    {
                        ask.Change(FlashcardConnectGameItemStatus.Success);
                        answer.Change(FlashcardConnectGameItemStatus.Success);
                    }
                    else
                    {
                        ask.Change(FlashcardConnectGameItemStatus.NotSelected);
                        answer.Change(FlashcardConnectGameItemStatus.NotSelected);
                    }
                }
                else
                {
                    answer.Change(FlashcardConnectGameItemStatus.Selected);
                }
            }

            IsCompleted = !Answers.Any(x => x.Status != FlashcardConnectGameItemStatus.Success);
        }
    }
}
