using FlashCards.Api.Core.SubscriptionTypes;

namespace FlashCards.Api.Service.DTO.SubscriptionTypes;

public class AddSubscriptionTypeBenefitDto
{
    [Key]
    public int SubscriptionTypeID { get; private set; }

    [Required]
    [StringLength(SubscriptionTypeBenefit.BenefitMaxLength)]
    public string Benefit { get; private set; }

    public AddSubscriptionTypeBenefitDto(
        int subscriptionTypeID,
        string benefit)
    {
        SubscriptionTypeID = subscriptionTypeID;
        Benefit = benefit;
    }
}
