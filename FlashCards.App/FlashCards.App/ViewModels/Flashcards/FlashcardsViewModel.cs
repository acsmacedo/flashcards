using FlashCards.App.Interfaces;
using FlashCards.App.Models.Flashcards;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class FlashcardsViewModel : BaseViewModel
    {
        private readonly IFlashcardCollectionService _service;

        public ObservableCollection<FlashcardCollection> Items { get; }
        public Command<FlashcardCollection> GoToFlahcardPageCommand { get; }
        public Command LoadItemsCommand { get; }

        public FlashcardsViewModel(IFlashcardCollectionService service)
        {
            _service = service;

            Items = new ObservableCollection<FlashcardCollection>();

            LoadItemsCommand = new Command(LoadItems);
            GoToFlahcardPageCommand = new Command<FlashcardCollection>(GoToFlahcardPage);
        }

        public void OnAppearing() => LoadItems();

        public async void LoadItems()
        {
            Items.Clear();

            var items = await _service.GetAllFlashcards();

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private void GoToFlahcardPage(FlashcardCollection user)
        {
            //TODO
            // Navigation.PushAsync(new ProfileUser(user));
        }
    }
}
