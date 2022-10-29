﻿using FlashCards.App.Models.Flashcards;
using FlashCards.App.Views.FlashCards;
using System.Collections.Generic;
using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using FlashCards.App.Models;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class PlayFlashcardChooseModeViewModel : BaseViewModel
    {
        public FlashcardCollection Data { get; private set; }
        public List<FlashcardChooseGameResult> Result { get; private set; }
        public FlashcardChooseGameResult CurrentResult { get; private set; }
        public ObservableCollection<FlashcardChooseGameItemResult> Answers => CurrentResult.Answers;

        public Command<FlashcardChooseGameItemResult> SendAnswerCommand { get; }
        public Command GoToNextCardCommand { get; }
        public Command GoToPreviousCardCommand { get; }
        public Command FinishGameCommand { get; }

        public PlayFlashcardChooseModeViewModel()
        {
            SendAnswerCommand = new Command<FlashcardChooseGameItemResult>(SendAnswer);
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
            CurrentPage = 1;
            Data = data;
            Result = data.Items
                .Select(x => new FlashcardChooseGameResult(x, data.Items))
                .ToList();

            SetInitialDataInternal();
        }

        public void SetInitialData(PlayFlashcardChooseModeViewModel data, int currentPage)
        {
            CurrentPage = currentPage;
            Data = data.Data;
            Result = new List<FlashcardChooseGameResult>(data.Result);

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

            var result = Result.First(x => x.FlashcardItemID == FlashcardItemID);

            CurrentResult = result;

            UpdateResult();
        }

        private void UpdateResult()
        {
            var result = Result.First(x => x.FlashcardItemID == FlashcardItemID);

            Mistakes = Result.Where(x => x.IsSuccess.HasValue && !x.IsSuccess.Value).Count();
            Hits = Result.Where(x => x.IsSuccess.HasValue && x.IsSuccess.Value).Count();
            
            CanAnswer = result.CanAnser;
            CanNotAnswer = !CanAnswer;
            ShowPreviousCard = CurrentPage > 1;
            ShowNextCard = CanNotAnswer ? CurrentPage < PageQty : false;
            ShowFinishGame = CanNotAnswer ? CurrentPage == PageQty : false;

            PercentageCompletion = (double)Result.Where(x => x.IsSuccess.HasValue).Count() / (double)PageQty;
            PercentageCompletionLabel = string.Format("{0}%", Math.Round(PercentageCompletion * 100));
        }

        private void SendAnswer(FlashcardChooseGameItemResult item)
        {
            if (CurrentResult.CanAnser)
            {
                CurrentResult.Answer(item.FlashcardItemID);

                UpdateResult();
            }
        }

        private void GoToNextCard()
        {
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new PlayFlashcardChooseModePage(this, CurrentPage + 1));
        }

        private void GoToPreviousCard()
        {
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new PlayFlashcardChooseModePage(this, CurrentPage - 1));
        }

        private void FinishGame()
        {
            Navigation.PushAsync(new CreateFlashcardAvailablePage(Data));
        }
    }
}