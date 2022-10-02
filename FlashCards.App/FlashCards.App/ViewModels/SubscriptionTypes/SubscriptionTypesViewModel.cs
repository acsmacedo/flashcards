using FlashCards.App.Interfaces;
using FlashCards.App.Models.SubscriptionTypes;
using FlashCards.App.ViewModels.Users;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.SubscriptionTypes
{
    public class SubscriptionTypesViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly ISubscriptionTypeService _subscriptionTypeService;

        public ObservableCollection<SubscriptionTypeByUser> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<SubscriptionTypeByUser> ChangeSubscriptionTypeCommand { get; }

        public SubscriptionTypesViewModel(
            IUserService userService, 
            ISubscriptionTypeService subscriptionTypeService)
        {
            _userService = userService;
            _subscriptionTypeService = subscriptionTypeService;

            Items = new ObservableCollection<SubscriptionTypeByUser>();

            LoadItems();

            LoadItemsCommand = new Command(LoadItems);
            ChangeSubscriptionTypeCommand = new Command<SubscriptionTypeByUser>(ChangeSubscriptionType);
        }

        private async void LoadItems()
        {
            Items.Clear();

            var items = await _subscriptionTypeService.GetSubscriptionTypesByUser(UserID);

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private async void ChangeSubscriptionType(SubscriptionTypeByUser item)
        {
            if (item == null)
                return;

            var data = new ChangeSubscriptionTypeDto(
                userID: item.UserID, 
                subscriptionTypeID: item.SubscriptionTypeID);

            await _userService.ChangeSubscriptionType(data);

            foreach (var subscription in Items)
            {
                subscription.Change(subscription.SubscriptionTypeID == data.SubscriptionTypeID);
            }
        }
    }
}
