using FlashCards.App.Models.Flashcards;
using FlashCards.App.ViewModels.Flashcards;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.FlashCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateFlashcardAvailablePage : ContentPage
    {
        public CreateFlashcardAvailablePage(FlashcardCollection flashcard)
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<CreateFlashcardAvailableViewModel>();

            viewModel.SetInitialData(flashcard);

            BindingContext = viewModel;
        }
    }
}
