using FlashCards.App.Interfaces;
using FlashCards.App.Models.Categories;
using FlashCards.App.Models.Flashcards;
using FlashCards.App.Models.Users;
using FlashCards.App.Services;
using FlashCards.App.Views.FlashCards;
using FlashCards.App.Views.Network;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class FlashcardsViewModel : BaseViewModel
    {
        private readonly IFlashcardCollectionService _flashcardService;
        private readonly IUserService _userService;

        public FlashcardViewMode Mode { get; private set; }
        public int CategoryDataID { get; private set; }
        public int UserDataID { get; private set; }

        public ObservableCollection<FlashcardCollection> Items { get; }
        public Command<FlashcardCollection> OpenFlashcardOptionsCommand { get; }
        public Command<FlashcardCollection> GoToFlahcardAvailablesCommand { get; }

        public Command LoadItemsCommand { get; }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public FlashcardsViewModel(
            IFlashcardCollectionService service,
            IUserService userService)
        {
            _flashcardService = service;
            _userService = userService;

            Items = new ObservableCollection<FlashcardCollection>();

            LoadItemsCommand = new Command(LoadItems);
            OpenFlashcardOptionsCommand = new Command<FlashcardCollection>(OpenFlashcardOptions);
            GoToFlahcardAvailablesCommand = new Command<FlashcardCollection>(GoToFlahcardAvailables);            
        }

        public void SetInitialData(Category category)
        {
            Mode = FlashcardViewMode.Category;
            CategoryDataID = category.ID;
            Title = category.Name;
        }

        public void SetInitialData(UserRelationship user)
        {
            Mode = FlashcardViewMode.User;
            UserDataID = user.ID;
            Title = user.Name;
        }

        public void SetInitialData()
        {
            Mode = FlashcardViewMode.All;
            Title = "Cards";
        }

        public void OnAppearing() => LoadItems();

        public async void LoadItems()
        {
            Items.Clear();

            var items = Enumerable.Empty<FlashcardCollection>();

            if (Mode == FlashcardViewMode.All)
            {
                items = await _flashcardService.GetAllFlashcards();
            }
            else if (Mode == FlashcardViewMode.Category)
            {
                items = await _flashcardService.GetFlashcardsByCategory(CategoryDataID);
            }
            else if (Mode == FlashcardViewMode.User)
            {
                items = await _flashcardService.GetFlashcardsByUser(UserDataID);
            }

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private void GoToFlahcardAvailables(FlashcardCollection flashcardCollection)
        {
            Navigation.PushAsync(new FlashcardAvailablesPage(flashcardCollection));
        }

        private async void OpenFlashcardOptions(FlashcardCollection flashcardCollection)
        {
            var data = await _flashcardService.GetByID(flashcardCollection.ID);
            if (!data.Items.Any())
            {
                DisplayError("Erro", "Esta coleção não possui itens!");
                return;
            }

            string action = await DisplayActionSheet(
                title: "O que você deseja fazer?",
                cancel: "Cancelar",
                buttons: new[] { "Conectar", "Digitar", "Escolher", "Lembrar", "Visualizar" });

            if (action == "Conectar")
            {
                await Navigation.PushModalAsync(new PlayFlashcardConnectModePage(data));
            }
            else if (action == "Digitar")
            {
                await Navigation.PushModalAsync(new PlayFlashcardTypeModePage(data));
            }
            else if (action == "Escolher")
            {
                await Navigation.PushModalAsync(new PlayFlashcardChooseModePage(data));
            }
            else if (action == "Lembrar")
            {
                await Navigation.PushModalAsync(new PlayFlashcardRememberModePage(data));
            }
            else if (action == "Visualizar")
            {
                await Navigation.PushModalAsync(new PlayFlashcardViewModePage(data, 1));
            }
        }
    }

    public enum FlashcardViewMode
    {
        All,
        Category,
        User
    }
}
