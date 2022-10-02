namespace FlashCards.Api.Service.DTO.SubscriptionTypes;

public class GetSubscriptionTypesByUserDto
{
    public int UserID { get; private set; }

    public GetSubscriptionTypesByUserDto(int userID)
    {
        UserID = userID;
    }
}
