using System;
using System.Globalization;
using Xamarin.Forms;

namespace FlashCards.App.Utils.Converters
{
    public class BoolToVisibilityPasswordIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (bool)value;

            if (data)
            {
                return "icon_eye_light.png";
            }
            else
            {
                return "icon_eye_primary.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
