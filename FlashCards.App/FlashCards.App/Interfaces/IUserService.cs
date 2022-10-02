using FlashCards.App.ViewModels.Users;
using System.Threading.Tasks;

namespace FlashCards.App.Interfaces
{
    public interface IUserService
    {
        Task ChangeSubscriptionType(ChangeSubscriptionTypeDto data);
        Task AddOrEditNotificationSetting(AddOrEditNotificationSettingDto data);
    }
}
