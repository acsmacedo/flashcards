namespace FlashCards.Api.Service.DTO.Users;

public class ChangeSubscriptionTypeDto
{
    public int UserID { get; private set; }
    public int SubscriptionTypeID { get; private set; }

    public ChangeSubscriptionTypeDto(int userID, int subscriptionTypeID)
    {
        UserID = userID;
        SubscriptionTypeID = subscriptionTypeID;
    }
}
