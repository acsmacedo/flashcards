using FlashCards.App.Models.Categories;
using FlashCards.App.Models.Users;
using FlashCards.App.ViewModels.Flashcards;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.FlashCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashCardsPage : ContentPage
    {
        private FlashcardsViewModel _viewModel;

        public FlashCardsPage()
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<FlashcardsViewModel>();

            viewModel.SetInitialData();

            BindingContext = _viewModel = viewModel;
        }

        public FlashCardsPage(Category category)
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<FlashcardsViewModel>();

            viewModel.SetInitialData(category);

            BindingContext = _viewModel = viewModel;
        }

        public FlashCardsPage(UserRelationship user)
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<FlashcardsViewModel>();

            viewModel.SetInitialData(user);

            BindingContext = _viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
