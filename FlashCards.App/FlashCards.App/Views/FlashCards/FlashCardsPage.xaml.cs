using FlashCards.App.ViewModels.Flashcards;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.FlashCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashCardsPage : ContentPage
    {
        public FlashCardsPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<FlashcardsViewModel>();
        }
    }
}
