using FlashCards.App.Models.Flashcards;
using FlashCards.App.ViewModels.Flashcards;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.FlashCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayFlashcardRememberModePage : ContentPage
    {
        private PlayFlashcardRememberModeViewModel _viewModel;

        public PlayFlashcardRememberModePage(FlashcardCollection data)
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<PlayFlashcardRememberModeViewModel>();

            viewModel.SetInitialData(data);

            BindingContext = _viewModel = viewModel;
        }

        public PlayFlashcardRememberModePage(PlayFlashcardRememberModeViewModel data, int currentPage)
        {
            InitializeComponent();

            var viewModel = Startup.ServiceProvider.GetService<PlayFlashcardRememberModeViewModel>();

            viewModel.SetInitialData(data, currentPage);

            BindingContext = _viewModel = viewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await _viewModel.ConfirmExitPage();

                if (result)
                    base.OnBackButtonPressed();
            });

            return true;
        }
    }
}