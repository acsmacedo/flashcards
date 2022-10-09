using System;
using System.Globalization;
using Xamarin.Forms;

namespace FlashCards.App.Utils.Converters
{
    public class FollowersQtyToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (int)value;

            if (data == 1)
            {
                return string.Format("{0} seguidor", data);
            }

            return string.Format("{0} seguidores", data);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
