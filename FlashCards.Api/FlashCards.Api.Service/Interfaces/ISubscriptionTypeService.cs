using FlashCards.Api.Service.DTO.SubscriptionTypes;

namespace FlashCards.Api.Service.Interfaces;

public interface ISubscriptionTypeService
{
    Task<IEnumerable<SubscriptionTypeDto>> GetAllAsync();
    Task<IEnumerable<SubscriptionTypeByUserDto>> GetAllByUserAsync(int userID);

    Task CreateAsync(CreateSubscriptionTypeDto data);
    Task EditAsync(EditSubscriptionTypeDto data);
    Task DeleteAsync(DeleteSubscriptionTypeDto data);

    Task AddBenefitAsync(AddSubscriptionTypeBenefitDto data);
    Task EditBenefitAsync(EditSubscriptionTypeBenefitDto data);
    Task RemoveBenefitAsync(RemoveSubscriptionTypeBenefitDto data);
}
