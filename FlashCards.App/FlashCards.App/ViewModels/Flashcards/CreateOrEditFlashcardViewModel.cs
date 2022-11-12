using FlashCards.App.Interfaces;
using FlashCards.App.Models.Categories;
using FlashCards.App.Models.Flashcards;
using FlashCards.App.Views.FlashCards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Flashcards
{
    public class CreateOrEditFlashcardViewModel : BaseViewModel
    {
        private readonly IFlashcardCollectionService _flashcardCollectionService;
        private readonly ICategoryService _categoryService;

        public Command SaveFlashcardCollectionCommand { get; }
        public Command AddFlashcarditemCommand { get; }
        public Command<FlashcardItem> EditFlashcarditemCommand { get; }
        public Command<FlashcardItem> DeleteFlashcarditemCommand { get; }

        public ObservableCollection<FlashcardItem> Items { get; }
        public ObservableCollection<Category> Categories { get; }

        public CreateOrEditFlashcardViewModel(
            IFlashcardCollectionService flashcardCollectionService, 
            ICategoryService categoryService)
        {
            _flashcardCollectionService = flashcardCollectionService;
            _categoryService = categoryService;

            Items = new ObservableCollection<FlashcardItem>();
            Categories = new ObservableCollection<Category>();

            SaveFlashcardCollectionCommand = new Command(SaveFlashcardCollection);
            AddFlashcarditemCommand = new Command(AddFlashcarditem);
            EditFlashcarditemCommand = new Command<FlashcardItem>(EditFlashcarditem);
            DeleteFlashcarditemCommand = new Command<FlashcardItem>(DeleteFlashcarditem);
        }

        private int _id;
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private int _userDirectoryID;
        public int UserDirectoryID
        {
            get => _userDirectoryID;
            set => SetProperty(ref _userDirectoryID, value);
        }

        private int _categoryID;
        public int CategoryID
        {
            get => _categoryID;
            set => SetProperty(ref _categoryID, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private bool _showAddCardItem;
        public bool ShowAddCardItem
        {
            get => _showAddCardItem;
            set => SetProperty(ref _showAddCardItem, value);
        }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        public List<string> Tags { get; set; } = new List<string>() { "Teste" };

        private bool _isInvalid =>
            CategoryID == 0 ||
            string.IsNullOrEmpty(Name);

        public void SetInitialData(FlashcardCollection data)
        {
            ID = data.ID;
        }

        public async void SetInitialData(int userDirectoryID)
        {
            await GetCategories();

            UserDirectoryID = userDirectoryID;

            Items.Clear();

            ShowAddCardItem = false;
        }

        public async void OnAppearing()
        {
            if (ID == 0)
                return;

            var flashcard = await _flashcardCollectionService.GetByID(ID);

            Name = flashcard.Name;
            Description = flashcard.Description;
            CategoryID = flashcard.CategoryID;
            UserDirectoryID = flashcard.UserDirectoryID;

            await GetCategories();

            SelectedCategory = Categories.First(x => x.ID == CategoryID);

            Items.Clear();

            foreach (var item in flashcard.Items ?? Enumerable.Empty<FlashcardItem>())
            {
                Items.Add(item);
            }

            ShowAddCardItem = true;
        }

        private async Task GetCategories()
        {
            var categories = await _categoryService.GetAllCategories();

            Categories.Clear();

            foreach (var item in categories)
            {
                Categories.Add(item);
            }
        }

        private async void SaveFlashcardCollection()
        {
            CategoryID = SelectedCategory.ID;

            try
            {
                if (_isInvalid)
                {
                    DisplayError(message: "O campo nome e categoria são obrigatórios.");
                    return;
                }

                if (ID != 0)
                {
                    await _flashcardCollectionService.EditFlashcardCollection(this);
                }
                else
                {
                    ID = await _flashcardCollectionService.CreateFlashcardCollection(this);
                    ShowAddCardItem = true;
                }

                await DisplaySuccess();
            }
            catch (Exception ex)
            {
                DisplayError(message: ex.Message);
            }
        }

        private void AddFlashcarditem()
        {
            Navigation.PushAsync(new CreateOrEditFlashcardItemPage(ID));
        }

        private void EditFlashcarditem(FlashcardItem item)
        {
            Navigation.PushAsync(new CreateOrEditFlashcardItemPage(item));
        }

        private async void DeleteFlashcarditem(FlashcardItem card)
        {
            var confirm = await ConfirmAction(
                title: "Confirmar exclusão",
                message: string.Format("Tem certeza que deseja excluir o card: {0}", card.FrontDescription));

            if (!confirm)
                return;

            var data = new DeleteFlashcardItemDto(
                flashcardCollectionID: card.FlashCardCollectionID,
                flashcardItemID: card.FlashCardItemID);

            await _flashcardCollectionService.DeletelashcardItem(data);

            var item = Items.Single(x => x.FlashCardItemID == card.FlashCardItemID);

            Items.Remove(item);
        }
    }
}
