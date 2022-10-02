namespace FlashCards.Api.Service.DTO.SubscriptionTypes;

public class RemoveSubscriptionTypeBenefitDto
{
    [Key]
    public int SubscriptionTypeID { get; private set; }

    [Key]
    public int SubscriptionTypeBenefitID { get; private set; }

    public RemoveSubscriptionTypeBenefitDto(
        int subscriptionTypeID, 
        int subscriptionTypeBenefitID)
    {
        SubscriptionTypeID = subscriptionTypeID;
        SubscriptionTypeBenefitID = subscriptionTypeBenefitID;
    }
}
