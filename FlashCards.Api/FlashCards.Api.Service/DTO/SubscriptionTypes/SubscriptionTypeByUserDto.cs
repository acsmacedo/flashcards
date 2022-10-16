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
    public IEnumerable<SubscriptionTypeBenefitDto> Benefits { get; private set; }

    public SubscriptionTypeByUserDto(SubscriptionType data, User user)
    {
        SubscriptionTypeID = data.ID;
        UserID = user.ID;
        IsSubscribed = user.SubscriptionTypeID.HasValue 
            ? user.SubscriptionTypeID == SubscriptionTypeID
            : data.Price == null;
        Name = data.Name;
        Price = data.Price;
        Benefits = data.Benefits.Select(x => new SubscriptionTypeBenefitDto(x));
    }
}
