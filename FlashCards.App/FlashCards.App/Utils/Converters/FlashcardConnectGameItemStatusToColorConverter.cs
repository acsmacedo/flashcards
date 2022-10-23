using FlashCards.App.ViewModels.Flashcards;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace FlashCards.App.Utils.Converters
{
    public class FlashcardConnectGameItemStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (FlashcardConnectGameItemStatus)value;

            if (data == FlashcardConnectGameItemStatus.Success)
            {
                return "LightGreen";
            }
            if (data == FlashcardConnectGameItemStatus.Selected)
            {
                return "Black";
            }
            else
            {
                return "White";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
