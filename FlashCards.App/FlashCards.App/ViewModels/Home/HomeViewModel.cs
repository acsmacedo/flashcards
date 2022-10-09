using FlashCards.App.Interfaces;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using FlashCards.App.Models.Categories;
using FlashCards.App.Views.FlashCards;

namespace FlashCards.App.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly ICategoryService _service;

        public ObservableCollection<Category> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<Category> GoToFlashcardsCommand { get; }

        public HomeViewModel(ICategoryService service)
        {
            _service = service;

            Items = new ObservableCollection<Category>();
            LoadItems();

            LoadItemsCommand = new Command(LoadItems);
            GoToFlashcardsCommand = new Command<Category>(GoToFlashcards);
        }

        public async void LoadItems()
        {
            Items.Clear();

            var items = await _service.GetAllCategories();

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private void GoToFlashcards(Category item)
        {
            Navigation.PushAsync(new FlashCardsPage());
        }
    }
}
