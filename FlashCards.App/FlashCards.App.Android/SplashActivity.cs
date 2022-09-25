using Android.App;
using Android.Content.PM;
using Android.OS;

namespace FlashCards.App.Droid
{
    [Activity(
        Label = "Flashcards", 
        Icon = "@mipmap/ic_launcher", 
        Theme = "@style/MainTheme.Splash", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            Finish();

            OverridePendingTransition(0, 0);
        }
    }
}
