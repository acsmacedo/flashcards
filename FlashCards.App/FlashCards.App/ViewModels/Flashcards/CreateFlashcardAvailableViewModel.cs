using FlashCards.App.Interfaces;
using FlashCards.App.Models.Flashcards;
using System;
using System.Linq;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class CreateFlashcardAvailableViewModel : BaseViewModel
    {
        private readonly IFlashcardCollectionService _service;

        public Command SendAvailableCommand { get; }
        public Command ChangeRatingOneStarCommand { get; }
        public Command ChangeRatingTwoStarCommand { get; }
        public Command ChangeRatingThreeStarCommand { get; }
        public Command ChangeRatingFourStarCommand { get; }
        public Command ChangeRatingFiveStarCommand { get; }

        public CreateFlashcardAvailableViewModel(IFlashcardCollectionService service)
        {
            _service = service;

            SendAvailableCommand = new Command(SendAvailable);
            ChangeRatingOneStarCommand = new Command(ChangeRatingOneStar);
            ChangeRatingTwoStarCommand = new Command(ChangeRatingTwoStar);
            ChangeRatingThreeStarCommand = new Command(ChangeRatingThreeStar);
            ChangeRatingFourStarCommand = new Command(ChangeRatingFourStar);
            ChangeRatingFiveStarCommand = new Command(ChangeRatingFiveStar);
        }

        private int _flashCardCollectionID;
        public int FlashCardCollectionID
        {
            get => _flashCardCollectionID;
            set => SetProperty(ref _flashCardCollectionID, value);
        }

        private string _flashCardCollectionName;
        public string FlashCardCollectionName
        {
            get => _flashCardCollectionName;
            set => SetProperty(ref _flashCardCollectionName, value);
        }

        private int _evaluatorID;
        public int EvaluatorID
        {
            get => _evaluatorID;
            set => SetProperty(ref _evaluatorID, value);
        }

        private int _rating;
        public int Rating
        {
            get => _rating;
            set => SetProperty(ref _rating, value);
        }

        private string _comment;
        public string Comment
        {
            get => _comment;
            set => SetProperty(ref _comment, value);
        }

        public async void SetInitialData(FlashcardCollection item)
        {
            var availables = await _service.GetAvailablesByFlashcardCollectiion(item.ID);

            FlashCardCollectionID = item.ID;
            FlashCardCollectionName = item.Name;
            EvaluatorID = UserID;

            var currentAvailable = availables.FirstOrDefault(x => x.UserID == UserID);

            if (currentAvailable != null)
            {
                Comment = currentAvailable.Comment;
                Rating = currentAvailable.Stars;
            }
        }

        private void ChangeRatingOneStar()
        {
            if (Rating == 1)
            {
                Rating = 0;
            }
            else
            {
                Rating = 1;
            }
        }

        private void ChangeRatingTwoStar()
        {
            if (Rating == 2)
            {
                Rating = 0;
            }
            else
            {
                Rating = 2;
            }
        }

        private void ChangeRatingThreeStar()
        {
            if (Rating == 3)
            {
                Rating = 0;
            }
            else
            {
                Rating = 3;
            }
        }

        private void ChangeRatingFourStar()
        {
            if (Rating == 4)
            {
                Rating = 0;
            }
            else
            {
                Rating = 4;
            }
        }

        private void ChangeRatingFiveStar()
        {
            if (Rating == 5)
            {
                Rating = 0;
            }
            else
            {
                Rating = 5;
            }
        }

        private async void SendAvailable()
        {
            try
            {
                await _service.SendAvailable(this);

                await DisplaySuccess();

                await Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                DisplayError(message: ex.Message);
            }
        }
    }
}
