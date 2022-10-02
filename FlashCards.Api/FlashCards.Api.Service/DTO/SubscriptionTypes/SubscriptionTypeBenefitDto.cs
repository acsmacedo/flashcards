using FlashCards.Api.Core.SubscriptionTypes;

namespace FlashCards.Api.Service.DTO.SubscriptionTypes;

public class SubscriptionTypeBenefitDto
{
    public int ID { get; private set; }
    public string Benefit { get; private set; }

    public SubscriptionTypeBenefitDto(SubscriptionTypeBenefit data)
    {
        ID = data.ID;
        Benefit = data.Benefit;
    }
}
