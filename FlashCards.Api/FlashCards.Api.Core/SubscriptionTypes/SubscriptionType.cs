using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Core.SubscriptionTypes;

public class SubscriptionType
{
    public const int NameMaxLength = 80;

    public int ID { get; private set; }
    public string Name { get; private set; }
    public double? Price { get; private set; }
    public IReadOnlyCollection<User> Users { get; private set; }
        = new List<User>();

    public SubscriptionType(int id, string name, double? price)
    {
        ID = id;
        Name = name;
        Price = price;
    }

    public SubscriptionType(string name, double? price)
    {
        Name = name;
        Price = price;
    }

    public void Edit(string name, double? price)
    {
        Name = name;
        Price = price;
    }

    private List<SubscriptionTypeBenefit> _benefits = new();
    public IReadOnlyCollection<SubscriptionTypeBenefit> Benefits => _benefits;

    public void AddBenefit(string benefitText)
    {
        _benefits.Add(new SubscriptionTypeBenefit(benefitText));
    }

    public void AddBenefit(SubscriptionTypeBenefit benefit)
    {
        _benefits.Add(benefit);
    }

    public void EditBenefit(int subscriptionTypeBenefitID, string newBenefitText)
    {
        var benefit = _benefits.FirstOrDefault(x => x.ID == subscriptionTypeBenefitID);

        if (benefit != null)
        {
            benefit.Edit(newBenefitText);
        }
    }

    public void RemoveBenefit(int subscriptionTypeBenefitID)
    {
        var benefit = _benefits.FirstOrDefault(x => x.ID == subscriptionTypeBenefitID);

        if (benefit != null)
        {
            _benefits.Remove(benefit);
        }
    }
}
