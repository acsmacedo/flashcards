using FlashCards.Api.Core.SubscriptionTypes;
using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Service.DTO.SubscriptionTypes;

public class SubscriptionTypeByUserDto
{
    public int SubscriptionTypeID { get; private set; }
    public int UserID { get; private set; }
    public bool IsSubscribed { get; private set; }
    public string Name { get; private set; }
    public double? Price { get; private set; }
    public IEnumerable<SubscriptionTypeBenefitDto> Benefits { get; }

    public SubscriptionTypeByUserDto(SubscriptionType data, User user)
    {
        SubscriptionTypeID = data.ID;
        UserID = user.ID;
        IsSubscribed = user.SubscriptionTypeID == SubscriptionTypeID;
        Name = data.Name;
        Price = data.Price;
        Benefits = data.Benefits.Select(x => new SubscriptionTypeBenefitDto(x));
    }
}
