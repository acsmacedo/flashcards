using FlashCards.Api.Core.SubscriptionTypes;

namespace FlashCards.Api.Service.DTO.SubscriptionTypes;

public class SubscriptionTypeDto
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public double? Price { get; private set; }
    public IEnumerable<SubscriptionTypeBenefitDto> Benefits { get;  }

    public SubscriptionTypeDto(SubscriptionType data)
    {
        ID = data.ID;
        Name = data.Name;
        Price = data.Price;
        Benefits = data.Benefits.Select(x => new SubscriptionTypeBenefitDto(x));
    }
}
