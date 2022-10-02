using FlashCards.Api.Core.SubscriptionTypes;

namespace FlashCards.Api.Service.DTO.SubscriptionTypes;

public class CreateSubscriptionTypeDto
{
    [Required]
    [StringLength(SubscriptionType.NameMaxLength)]
    public string Name { get; private set; }

    public double? Price { get; private set; }

    public CreateSubscriptionTypeDto(string name, double? price)
    {
        Name = name;
        Price = price;
    }
}
