using System;
using System.Globalization;
using Xamarin.Forms;

namespace FlashCards.App.Utils.Converters
{
    public class FirstStarToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (int)value;

            if (data >= 1)
            {
                return "icon_star_primary.png";
            }
            else
            {
                return "icon_star_outline.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
