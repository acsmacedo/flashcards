using FlashCards.App.Models.Flashcards;
using FlashCards.App.ViewModels.Flashcards;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.FlashCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateOrEditFlashcardPage : ContentPage
    {
        private CreateOrEditFlashcardViewModel _viewModel;

        private List<SwipeView> SwipeViews { set; get; }

        public CreateOrEditFlashcardPage(FlashcardCollection flashcardCollection)
        {
            InitializeComponent();

            SwipeViews = new List<SwipeView>();

            var viewModel = Startup.ServiceProvider.GetService<CreateOrEditFlashcardViewModel>();

            viewModel.SetInitialData(flashcardCollection);

            BindingContext = _viewModel = viewModel;
        }

        public CreateOrEditFlashcardPage(int userDirectoryID)
        {
            InitializeComponent();

            SwipeViews = new List<SwipeView>();

            var viewModel = Startup.ServiceProvider.GetService<CreateOrEditFlashcardViewModel>();

            viewModel.SetInitialData(userDirectoryID);

            BindingContext = _viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void SwipeView_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            if (SwipeViews.Count == 1)
            {
                SwipeViews[0].Close();
                SwipeViews.Remove(SwipeViews[0]);
            }
        }

        private void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            SwipeViews.Add((SwipeView)sender);
        }
    }
}