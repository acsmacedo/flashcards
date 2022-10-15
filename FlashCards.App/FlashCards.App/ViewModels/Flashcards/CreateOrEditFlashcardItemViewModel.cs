using FlashCards.App.Interfaces;
using FlashCards.App.Models.Flashcards;
using System;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class CreateOrEditFlashcardItemViewModel : BaseViewModel
    {
        private readonly IFlashcardCollectionService _service;

        public Command SaveFlashcardItemCommand { get; }

        public CreateOrEditFlashcardItemViewModel(IFlashcardCollectionService service)
        {
            _service = service;

            SaveFlashcardItemCommand = new Command(SaveFlashcardItem);
        }

        private int _flashCardCollectionID;
        public int FlashCardCollectionID
        {
            get => _flashCardCollectionID;
            set => SetProperty(ref _flashCardCollectionID, value);
        }

        private int _flashCardItemID;
        public int FlashCardItemID
        {
            get => _flashCardItemID;
            set => SetProperty(ref _flashCardItemID, value);
        }

        private string _frontDescription;
        public string FrontDescription
        {
            get => _frontDescription;
            set => SetProperty(ref _frontDescription, value);
        }

        private string _verseDescription;
        public string VerseDescription
        {
            get => _verseDescription;
            set => SetProperty(ref _verseDescription, value);
        }

        private bool _isInvalid =>
           string.IsNullOrEmpty(FrontDescription) ||
           string.IsNullOrEmpty(VerseDescription);

        public void SetInitialData(FlashcardItem item)
        {
            FlashCardCollectionID = item.FlashCardCollectionID;
            FlashCardItemID = item.FlashCardItemID;
            FrontDescription = item.FrontDescription;
            VerseDescription = item.VerseDescription;
        }

        public void SetInitialData(int flashCardCollectionID)
        {
            FlashCardCollectionID = flashCardCollectionID;
        }

        private async void SaveFlashcardItem()
        {
            try
            {
                if (_isInvalid)
                {
                    DisplayError(message: "É neessário preencher todos os campos.");
                    return;
                }

                if (FlashCardItemID != 0)
                {
                    await _service.EditFlashcardItem(this);
                }
                else
                {
                    FlashCardItemID = await _service.AddFlashcardItem(this);
                }

                await DisplaySuccess();
            }
            catch (Exception ex)
            {
                DisplayError(message: ex.Message);
            }
        }
    }
}
