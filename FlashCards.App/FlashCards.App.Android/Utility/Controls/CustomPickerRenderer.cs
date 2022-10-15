using Android.Content;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FlashCards.App.Droid.Utility.Controls;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace FlashCards.App.Droid.Utility.Controls
{
    public class CustomPickerRenderer : PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = null;
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}
