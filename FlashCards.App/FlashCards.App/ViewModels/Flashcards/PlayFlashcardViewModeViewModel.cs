using FlashCards.App.Models.Flashcards;
using FlashCards.App.Views.FlashCards;
using System;
using System.Linq;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class PlayFlashcardViewModeViewModel : BaseViewModel
    {
        public FlashcardCollection Data { get; private set; }

        public Command GoToNextCardCommand { get; }
        public Command GoToPreviousCardCommand { get; }
        public Command FinishGameCommand { get; }

        public PlayFlashcardViewModeViewModel()
        {
            GoToNextCardCommand = new Command(GoToNextCard);
            GoToPreviousCardCommand = new Command(GoToPreviousCard);
            FinishGameCommand = new Command(FinishGame);
        }

        private int _flashcardCollectionID;
        public int FlashcardCollectionID
        {
            get => _flashcardCollectionID;
            set => SetProperty(ref _flashcardCollectionID, value);
        }

        private string _flashcardCollectionName;
        public string FlashcardCollectionName
        {
            get => _flashcardCollectionName;
            set => SetProperty(ref _flashcardCollectionName, value);
        }

        private int _currentPage;
        public int CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        private int _pageQty;
        public int PageQty
        {
            get => _pageQty;
            set => SetProperty(ref _pageQty, value);
        }

        private string _ask;
        public string Ask
        {
            get => _ask;
            set => SetProperty(ref _ask, value);
        }

        private string _answer;
        public string Answer
        {
            get => _answer;
            set => SetProperty(ref _answer, value);
        }

        private bool _showPreviousCard;
        public bool ShowPreviousCard
        {
            get => _showPreviousCard;
            set => SetProperty(ref _showPreviousCard, value);
        }

        private bool _showNextCard;
        public bool ShowNextCard
        {
            get => _showNextCard;
            set => SetProperty(ref _showNextCard, value);
        }

        private bool _showFinishGame;
        public bool ShowFinishGame
        {
            get => _showFinishGame;
            set => SetProperty(ref _showFinishGame, value);
        }

        private double _percentageCompletion;
        public double PercentageCompletion
        {
            get => _percentageCompletion;
            set => SetProperty(ref _percentageCompletion, value);
        }

        private string _percentageCompletionLabel;
        public string PercentageCompletionLabel
        {
            get => _percentageCompletionLabel;
            set => SetProperty(ref _percentageCompletionLabel, value);
        }

        public void SetInitialData(FlashcardCollection data, int currentPage)
        {
            Data = data;

            FlashcardCollectionID = data.ID;
            FlashcardCollectionName = data.Name;

            PageQty = data.Items.Count();
            CurrentPage = currentPage;

            var card = data.Items.ToList()[currentPage - 1];

            Ask = card.FrontDescription;
            Answer = card.VerseDescription;

            ShowPreviousCard = CurrentPage > 1;
            ShowNextCard = CurrentPage < PageQty;
            ShowFinishGame = CurrentPage == PageQty;

            PercentageCompletion = (double)CurrentPage / (double)PageQty;
            PercentageCompletionLabel = string.Format("{0}%", Math.Round(PercentageCompletion * 100));
        }

        private async void GoToNextCard()
        {
            await Navigation.PopModalAsync();
            await Navigation.PushModalAsync(new PlayFlashcardViewModePage(Data, CurrentPage + 1));
        }

        private async void GoToPreviousCard()
        {
            await Navigation.PopModalAsync();
            await Navigation.PushModalAsync(new PlayFlashcardViewModePage(Data, CurrentPage - 1));
        }

        private async void FinishGame()
        {
            await Navigation.PushAsync(new CreateFlashcardAvailablePage(Data));
        }
    }
}
