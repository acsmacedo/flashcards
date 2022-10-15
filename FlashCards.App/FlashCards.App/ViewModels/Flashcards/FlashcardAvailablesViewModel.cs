using FlashCards.App.Interfaces;
using FlashCards.App.Models.Flashcards;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class FlashcardAvailablesViewModel : BaseViewModel
    {
        private readonly IFlashcardCollectionService _service;

        public ObservableCollection<FlashcardCollectionAvailable> Items { get; }
        public Command<FlashcardCollectionAvailable> GoToProfileUserPageCommand { get; }
        public Command LoadItemsCommand { get; }

        public FlashcardAvailablesViewModel(IFlashcardCollectionService service)
        {
            _service = service;

            Items = new ObservableCollection<FlashcardCollectionAvailable>();

            LoadItemsCommand = new Command(LoadItems);
            GoToProfileUserPageCommand = new Command<FlashcardCollectionAvailable>(GoToProfileUserPage);
        }

        private int _id;
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int _stars;
        public int Stars
        {
            get => _stars;
            set => SetProperty(ref _stars, value);
        }

        private int _available;
        public int Available
        {
            get => _available;
            set => SetProperty(ref _available, value);
        }

        public void SetInitialData(FlashcardCollection data)
        {
            ID = data.ID;
            Name = data.Name;
            Available = data.Available;
            Stars = data.Stars;

            LoadItems();
        }

        public async void LoadItems()
        {
            Items.Clear();

            var items = await _service.GetAvailablesByFlashcardCollectiion(ID);

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private void GoToProfileUserPage(FlashcardCollectionAvailable data)
        {
            // TODO
            //Navigation.PushAsync(new ProfileUser(user));
        }
    }
}
