using FlashCards.App.Models.NotificationSettings;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace FlashCards.App.Utils.Converters
{
    public  class NotificationSettingStatusToStringConverter : IValueConverter
    {
        private const string None = "Não enviar";
        private const string Email = "E-mail";
        private const string SMS = "SMS";
        private const string Push = "Push";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValue = (NotificationSettingStatus)value;

            switch(enumValue)
            {
                case NotificationSettingStatus.None:
                    return None;
                case NotificationSettingStatus.Email:
                    return Email;
                case NotificationSettingStatus.SMS:
                    return SMS;
                case NotificationSettingStatus.Push:
                    return Push;
                default:
                    return None;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = value.ToString();

            switch (data)
            {
                case None:
                    return NotificationSettingStatus.None;
                case Email:
                    return NotificationSettingStatus.Email;
                case SMS:
                    return NotificationSettingStatus.SMS;
                case Push:
                    return NotificationSettingStatus.Push;
                default:
                    return NotificationSettingStatus.None;
            }
        }
    }
}
