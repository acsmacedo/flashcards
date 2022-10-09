using Android.Content;
using FlashCards.App.Droid.Utility.Controls;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]
namespace FlashCards.App.Droid.Utility.Controls
{
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
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
