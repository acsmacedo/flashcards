using FlashCards.App.Interfaces;
using FlashCards.App.Models.Directories;
using FlashCards.App.Models.Flashcards;
using FlashCards.App.Views.Directories;
using FlashCards.App.Views.FlashCards;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Directories
{
    public class MyDirectoryViewModel : BaseViewModel
    {
        private readonly IDirectoryService _directoryService;
        private readonly IFlashcardCollectionService _flashcardCollectionService;
        private int _directoryID;

        public ObservableCollection<UserDirectoryItem> Directories { get; }
        public ObservableCollection<FlashcardCollection> Cards { get; }

        public Command LoadItemsCommand { get; }
        public Command CreateDirectoryOrFlashcardCommand { get; }
        public Command<UserDirectoryItem> EditDirectoryCommand { get; }
        public Command<UserDirectoryItem> DeleteDirectoryCommand { get; }
        public Command<UserDirectoryItem> GoToDirectoryCommand { get; }

        public Command<FlashcardCollection> EditFlashcardCommand { get; }
        public Command<FlashcardCollection> DeleteFlashcardCommand { get; }
        public Command<FlashcardCollection> PlayFlashcardCommand { get; }
        public Command<FlashcardCollection> GoToAvailableFlashcardCommand { get; }

        public MyDirectoryViewModel(
            IDirectoryService directoryService,
            IFlashcardCollectionService flashcardCollectionService)
        {
            _directoryService = directoryService;
            _flashcardCollectionService = flashcardCollectionService;

            Directories = new ObservableCollection<UserDirectoryItem>();
            Cards = new ObservableCollection<FlashcardCollection>();

            LoadItemsCommand = new Command(LoadItems);
            CreateDirectoryOrFlashcardCommand = new Command(CreateDirectoryOrFlashcard);
            EditDirectoryCommand = new Command<UserDirectoryItem>(EditDirectory);
            DeleteDirectoryCommand = new Command<UserDirectoryItem>(DeleteDirectory);
            GoToDirectoryCommand = new Command<UserDirectoryItem>(GoToDirectory);

            EditFlashcardCommand = new Command<FlashcardCollection>(EditFlashcard);
            DeleteFlashcardCommand = new Command<FlashcardCollection>(DeleteFlashcard);
            PlayFlashcardCommand = new Command<FlashcardCollection>(PlayFlashcard);
            GoToAvailableFlashcardCommand = new Command<FlashcardCollection>(GoToAvailableFlashcard);
        }

        public void OnAppearing(int directoryID)
        {
            _directoryID = directoryID;

            LoadItems();
        }

        public async void LoadItems()
        {
            Directories.Clear();
            Cards.Clear();

            int? directoryID = null;

            if (_directoryID != 0)
                directoryID = _directoryID;

            var item = await _directoryService.GetUserDirectory(UserID, directoryID);

            _directoryID = item.ID;

            foreach (var directory in item.Directories)
            {
                Directories.Add(directory);
            }

            foreach (var card in item.Cards)
            {
                Cards.Add(card);
            }
        }

        private async void CreateDirectoryOrFlashcard()
        {
            string action = await DisplayActionSheet(
                title: "O que você deseja fazer?",
                cancel:"Cancelar",
                buttons: new[] { "Criar diretório", "Criar flashcard" });

            if (action == "Criar diretório")
            {
                await CreateDirectory();
            }
            else if (action == "Criar flashcard")
            {
                CreateFlashcard();
            }
        }

        private async Task CreateDirectory()
        {
            var result = await DisplayPrompt("Criar diretório", "Nome do diretório");

            if (string.IsNullOrWhiteSpace(result))
                return;

            var data = new CreateUserDirectoryDto(
                parentID: _directoryID,
                userID: UserID,
                name: result);

            var id = await _directoryService.CreateDirectory(data);

            Directories.Add(new UserDirectoryItem(id, result));
        }

        private void CreateFlashcard()
        {
            Navigation.PushAsync(new CreateOrEditFlashcardPage(_directoryID));
        }

        private void EditFlashcard(FlashcardCollection item)
        {
            Navigation.PushAsync(new CreateOrEditFlashcardPage(item));
        }

        private async void PlayFlashcard(FlashcardCollection item)
        {
            var data = await _flashcardCollectionService.GetByID(item.ID);

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

        private void GoToAvailableFlashcard(FlashcardCollection item)
        {
            Navigation.PushAsync(new FlashcardAvailablesPage(item));
        }

        private async void DeleteFlashcard(FlashcardCollection flashcard)
        {
            var confirm = await ConfirmAction(
                title: "Confirmar exclusão",
                message: string.Format("Tem certeza que deseja excluir o flashcard: {0}", flashcard.Name));

            if (!confirm)
                return;

            await _flashcardCollectionService.DeleteFlashcardCollection(flashcard.ID);

            var item = Cards.Single(x => x.ID == flashcard.ID);

            Cards.Remove(item);
        }

        private async void EditDirectory(UserDirectoryItem directory)
        {
            var result = await DisplayPrompt("Editar diretório", "Nome do diretório", directory.Name);

            if (string.IsNullOrWhiteSpace(result))
                return;

            var data = new EditUserDirectoryDto(
                id: directory.ID,
                name: result);

            await _directoryService.EditDirectory(data);

            Directories.Single(x => x.ID == directory.ID).Change(result);
        }

        private async void DeleteDirectory(UserDirectoryItem directory)
        {
            var confirm = await ConfirmAction(
                title: "Confirmar exclusão", 
                message: string.Format("Tem certeza que deseja excluir o diretório: {0}", directory.Name));

            if (!confirm)
                return;

            var data = new DeleteUserDirectoryDto(id: directory.ID);

            await _directoryService.DeleteDirectory(data);

            var item = Directories.Single(x => x.ID == directory.ID);

            Directories.Remove(item);
        }

        private void GoToDirectory(UserDirectoryItem directory)
        {
            Navigation.PushAsync(new DirectoriesPage(directory.ID));
        }
    }
}
