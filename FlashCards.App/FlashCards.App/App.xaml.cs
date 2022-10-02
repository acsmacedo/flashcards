using FlashCards.App.Views.Account;
using Xamarin.Forms;

namespace FlashCards.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Startup.Init();

            if (Current.Properties.TryGetValue("user_account", out var value))
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
