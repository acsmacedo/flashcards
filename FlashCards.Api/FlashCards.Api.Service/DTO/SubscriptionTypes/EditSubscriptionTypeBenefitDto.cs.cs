using FlashCards.Api.Core.SubscriptionTypes;

namespace FlashCards.Api.Service.DTO.SubscriptionTypes;

public class EditSubscriptionTypeBenefitDto
{
    [Key]
    public int SubscriptionTypeID { get; private set; }

    [Key]
    public int SubscriptionTypeBenefitID { get; private set; }

    [Required]
    [StringLength(SubscriptionTypeBenefit.BenefitMaxLength)]
    public string Benefit { get; private set; }

    public EditSubscriptionTypeBenefitDto(
        int subscriptionTypeID, 
        int subscriptionTypeBenefitID, 
        string benefit)
    {
        SubscriptionTypeID = subscriptionTypeID;
        SubscriptionTypeBenefitID = subscriptionTypeBenefitID;
        Benefit = benefit;
    }
}
