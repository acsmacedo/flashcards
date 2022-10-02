using FlashCards.Api.Core.SubscriptionTypes;

namespace FlashCards.Api.Service.DTO.SubscriptionTypes;

public class EditSubscriptionTypeDto
{
    [Key]
    public int ID { get; private set; }

    [Required]
    [StringLength(SubscriptionType.NameMaxLength)]
    public string Name { get; private set; }

    public double? Price { get; private set; }

    public EditSubscriptionTypeDto(int id, string name, double? price)
    {
        ID = id;
        Name = name;
        Price = price;
    }
}
