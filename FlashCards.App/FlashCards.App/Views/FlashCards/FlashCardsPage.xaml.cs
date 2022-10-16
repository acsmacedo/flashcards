using FlashCards.App.Models.Categories;
using FlashCards.App.Models.Users;
using FlashCards.App.ViewModels.Flashcards;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.FlashCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashCardsPage : ContentPage
    {
        private FlashcardsViewModel _viewModel;
        private bool _isRoot;

        public FlashCardsPage()
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<FlashcardsViewModel>();

            viewModel.SetInitialData();

            BindingContext = _viewModel = viewModel;
            _isRoot = true;
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

        protected override bool OnBackButtonPressed()
        {
            if (!_isRoot)
                return base.OnBackButtonPressed();

            Device.BeginInvokeOnMainThread(async () => {
                var result = await _viewModel.ConfirmExitApp();

                if (result)
                    Process.GetCurrentProcess().CloseMainWindow();
            });

            return true;
        }
    }
}
