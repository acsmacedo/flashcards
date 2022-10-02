using FlashCards.App.Models.SubscriptionTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlashCards.App.Interfaces
{
    public interface ISubscriptionTypeService
    {
        Task<IEnumerable<SubscriptionTypeByUser>> GetSubscriptionTypesByUser(int userID);
    }
}
