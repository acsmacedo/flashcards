using FlashCards.App.ViewModels.Directories;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Directories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DirectoriesPage : ContentPage
    {
        private int _directoryID;
        private MyDirectoryViewModel _viewModel;

        private List<SwipeView> SwipeViews { set; get; }

        public DirectoriesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = Startup.ServiceProvider.GetService<MyDirectoryViewModel>();
            SwipeViews = new List<SwipeView>();
        }

        public DirectoriesPage(int directoryID)
        {
            InitializeComponent();

            _directoryID = directoryID;
            BindingContext = _viewModel = Startup.ServiceProvider.GetService<MyDirectoryViewModel>();
            SwipeViews = new List<SwipeView>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing(_directoryID);
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

        protected override bool OnBackButtonPressed()
        {
            if (Navigation.NavigationStack.Count > 1)
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