using FlashCards.App.Interfaces;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using FlashCards.App.Models.Categories;
using FlashCards.App.Views.FlashCards;
using FlashCards.App.Views.Settings;
using FlashCards.App.Views.Directories;

namespace FlashCards.App.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly ICategoryService _service;

        public ObservableCollection<Category> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<Category> GoToFlashcardsCommand { get; }
        public Command GoToSettingsSubscriptionPageCommand { get; }
        public Command GoToDirectoriesPageCommand { get; }

        public HomeViewModel(ICategoryService service)
        {
            _service = service;

            Items = new ObservableCollection<Category>();
            LoadItems();

            LoadItemsCommand = new Command(LoadItems);
            GoToFlashcardsCommand = new Command<Category>(GoToFlashcards);
            GoToSettingsSubscriptionPageCommand = new Command(GoToSettingsSubscriptionPage);
            GoToDirectoriesPageCommand = new Command(GoToDirectoriesPage);
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
            Navigation.PushAsync(new FlashCardsPage(item));
        }

        private void GoToSettingsSubscriptionPage()
        {
            Navigation.PushAsync(new SettingsSubscriptionPage());
        }

        private void GoToDirectoriesPage()
        {
            Navigation.PushAsync(new DirectoriesPage());
        }
    }
}
