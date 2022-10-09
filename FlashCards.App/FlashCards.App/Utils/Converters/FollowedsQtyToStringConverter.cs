using System;
using System.Globalization;
using Xamarin.Forms;

namespace FlashCards.App.Utils.Converters
{
    public class FollowedsQtyToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (int)value;

            return string.Format("{0} seguindo", data);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
