using FlashCards.App.Models.Flashcards;
using FlashCards.App.ViewModels.Flashcards;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.FlashCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashcardAvailablesPage : ContentPage
    {
        public FlashcardAvailablesPage(FlashcardCollection data)
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<FlashcardAvailablesViewModel>();

            viewModel.SetInitialData(data);

            BindingContext = viewModel;
        }
    }
}