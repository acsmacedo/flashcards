using FlashCards.App.Models.Flashcards;
using FlashCards.App.ViewModels.Flashcards;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.FlashCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateOrEditFlashcardItemPage : ContentPage
    {
        public CreateOrEditFlashcardItemPage(FlashcardItem flashcardItem)
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<CreateOrEditFlashcardItemViewModel>();

            viewModel.SetInitialData(flashcardItem);

            BindingContext = viewModel;
        }

        public CreateOrEditFlashcardItemPage(int flashcardCollectionID)
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<CreateOrEditFlashcardItemViewModel>();

            viewModel.SetInitialData(flashcardCollectionID);

            BindingContext = viewModel;
        }
    }
}