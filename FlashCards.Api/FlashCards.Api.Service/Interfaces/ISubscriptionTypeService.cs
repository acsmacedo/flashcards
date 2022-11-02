using FlashCards.Api.Service.DTO.SubscriptionTypes;

namespace FlashCards.Api.Service.Interfaces;

public interface ISubscriptionTypeService
{
    Task<IEnumerable<SubscriptionTypeDto>> GetAllAsync();
    Task<IEnumerable<SubscriptionTypeByUserDto>> GetAllByUserAsync(int userID);
    Task<SubscriptionTypeDto> GetByIDAsync(int subscriptionTypeID);

    Task<int> CreateAsync(CreateSubscriptionTypeDto data);
    Task EditAsync(EditSubscriptionTypeDto data);
    Task DeleteAsync(DeleteSubscriptionTypeDto data);

    Task<int> AddBenefitAsync(AddSubscriptionTypeBenefitDto data);
    Task EditBenefitAsync(EditSubscriptionTypeBenefitDto data);
    Task RemoveBenefitAsync(RemoveSubscriptionTypeBenefitDto data);
}
