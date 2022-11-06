using FlashCards.App.Models.Flashcards;
using FlashCards.App.Views.FlashCards;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class PlayFlashcardTypeModeViewModel : BaseViewModel
    {
        public FlashcardCollection Data { get; private set; }
        public List<FlashcardTypeGameResult> Result { get; private set; }

        public Command SendAnswerCommand { get; }
        public Command GoToNextCardCommand { get; }
        public Command GoToPreviousCardCommand { get; }
        public Command QuitAnswerCommand { get; }
        public Command FinishGameCommand { get; }

        public PlayFlashcardTypeModeViewModel()
        {
            SendAnswerCommand = new Command(SendAnswer);
            GoToNextCardCommand = new Command(GoToNextCard);
            GoToPreviousCardCommand = new Command(GoToPreviousCard);
            QuitAnswerCommand = new Command(QuitAnswer);
            FinishGameCommand = new Command(FinishGame);
        }

        private int _flashcardCollectionID;
        public int FlashcardCollectionID
        {
            get => _flashcardCollectionID;
            set => SetProperty(ref _flashcardCollectionID, value);
        }

        private int _flashcardItemID;
        public int FlashcardItemID
        {
            get => _flashcardItemID;
            set => SetProperty(ref _flashcardItemID, value);
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

        private int _mistakes;
        public int Mistakes
        {
            get => _mistakes;
            set => SetProperty(ref _mistakes, value);
        }

        private int _hits;
        public int Hits
        {
            get => _hits;
            set => SetProperty(ref _hits, value);
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

        private string _myAnswer;
        public string MyAnswer
        {
            get => _myAnswer;
            set => SetProperty(ref _myAnswer, value);
        }

        private bool _showPreviousCard;
        public bool ShowPreviousCard
        {
            get => _showPreviousCard;
            set => SetProperty(ref _showPreviousCard, value);
        }

        private bool _canAnswer;
        public bool CanAnswer
        {
            get => _canAnswer;
            set => SetProperty(ref _canAnswer, value);
        }

        private bool _isSuccess;
        public bool IsSuccess
        {
            get => _isSuccess;
            set => SetProperty(ref _isSuccess, value);
        }

        private bool _canNotAnswer;
        public bool CanNotAnswer
        {
            get => _canNotAnswer;
            set => SetProperty(ref _canNotAnswer, value);
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

        public void SetInitialData(FlashcardCollection data)
        {
            Data = data;
            Result = new List<FlashcardTypeGameResult>();
            CurrentPage = 1;

            SetInitialDataInternal();
        }

        public void SetInitialData(PlayFlashcardTypeModeViewModel data, int currentPage)
        {
            Data = data.Data;
            Result = new List<FlashcardTypeGameResult>(data.Result);
            CurrentPage = currentPage;

            SetInitialDataInternal();
        }

        private void SetInitialDataInternal()
        {
            FlashcardCollectionID = Data.ID;
            FlashcardCollectionName = Data.Name;
            PageQty = Data.Items.Count();

            var card = Data.Items.ToList()[CurrentPage - 1];

            FlashcardItemID = card.FlashCardItemID;
            Ask = card.FrontDescription;
            Answer = card.VerseDescription;

            UpdateResult();
        }

        private void UpdateResult()
        {
            var result = Result.FirstOrDefault(x => x.FlashcardItemID == FlashcardItemID);

            Mistakes = Result.Where(x => !x.IsSuccess).Count();
            Hits = Result.Where(x => x.IsSuccess).Count();

            MyAnswer = result?.MyAnswer ?? string.Empty;
            IsSuccess = result?.IsSuccess ?? false;

            CanNotAnswer = result != null;
            CanAnswer = !CanNotAnswer;

            ShowPreviousCard = CurrentPage > 1;
            ShowNextCard = CanNotAnswer ? CurrentPage < PageQty : false;
            ShowFinishGame = CanNotAnswer ? CurrentPage == PageQty : false;

            PercentageCompletion = (double)Result.Count() / (double)PageQty;
            PercentageCompletionLabel = string.Format("{0}%", Math.Round(PercentageCompletion * 100));
        }

        private void SendAnswer()
        {
            if (MyAnswer.Trim().ToLower() == Answer.Trim().ToLower())
            {
                Result.Add(new FlashcardTypeGameResult(FlashcardItemID, MyAnswer, true));

                UpdateResult();
            }
            else
            {
                DisplayError(
                    title: "Reposta errada", 
                    message: "Você não acertou a reposta, tente novamente!");
            }
        }

        private void QuitAnswer()
        {
            Result.Add(new FlashcardTypeGameResult(FlashcardItemID, MyAnswer, false));

            UpdateResult();
        }

        private async void GoToNextCard()
        {
            await Navigation.PopModalAsync();
            await Navigation.PushModalAsync(new PlayFlashcardTypeModePage(this, CurrentPage + 1));
        }

        private async void GoToPreviousCard()
        {
            await Navigation.PopModalAsync();
            await Navigation.PushModalAsync(new PlayFlashcardTypeModePage(this, CurrentPage - 1));
        }

        private async void FinishGame()
        {
            await Navigation.PushAsync(new CreateFlashcardAvailablePage(Data));
        }
    }
}
