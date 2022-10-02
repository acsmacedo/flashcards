using FlashCards.App.Interfaces;
using FlashCards.App.Models.NotificationSettings;
using FlashCards.App.Utils.Converters;
using FlashCards.App.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.NotificationSettings
{
    public class NotificationSettingsViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly INotificationSettingService _notificationSettingService;

        public ObservableCollection<NotificationSettingByUser> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<NotificationSettingByUser> AddOrEditNotificationSettingCommand { get; }

        public NotificationSettingsViewModel(
            IUserService userService,
            INotificationSettingService notificationSettingService)
        {
            _userService = userService;
            _notificationSettingService = notificationSettingService;

            Items = new ObservableCollection<NotificationSettingByUser>();

            LoadItems();

            LoadItemsCommand = new Command(LoadItems);
            AddOrEditNotificationSettingCommand = new Command<NotificationSettingByUser>(AddOrEditNotificationSetting);
        }

        public async void LoadItems()
        {
            Items.Clear();

            var items = await _notificationSettingService.GetNotificationSettingsByUser(UserID);

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private async void AddOrEditNotificationSetting(NotificationSettingByUser item)
        {
            if (item == null)
                return;

            var converter = new NotificationSettingStatusToStringConverter();
            var buttons = new List<string>();

            foreach (var value in Enum.GetValues(typeof(NotificationSettingStatus)))
            {
                var result = converter.Convert(
                    value: value, 
                    targetType: typeof(string), 
                    parameter: null, 
                    culture: CultureInfo.InvariantCulture);
                
                buttons.Add(result.ToString());
            }

            string action = await DisplayActionSheet(
                title: "Alterar notificação",
                cancel: "Cancelar",
                buttons: buttons.ToArray());

            if (action == "Cancelar")
                return;

            var actionResult = converter.ConvertBack(
                value: action, 
                targetType: typeof(NotificationSettingStatus), 
                parameter: null, 
                culture: CultureInfo.InvariantCulture);
            
            var data = new AddOrEditNotificationSettingDto(
                userID: item.UserID,
                notificationSettingID: item.NotificationSettingID,
                status: (NotificationSettingStatus)actionResult);

            await _userService.AddOrEditNotificationSetting(data);

            var notification = Items.FirstOrDefault(x => x.NotificationSettingID == data.NotificationSettingID);
            
            if (notification != null)
            {
                notification.Change((NotificationSettingStatus)actionResult);
            }
        }
    }
}
