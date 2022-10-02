namespace FlashCards.Api.Service.DTO.SubscriptionTypes;

public class DeleteSubscriptionTypeDto
{
    [Key]
    public int ID { get; private set; }

    public DeleteSubscriptionTypeDto(int id)
    {
        ID = id;
    }
}
