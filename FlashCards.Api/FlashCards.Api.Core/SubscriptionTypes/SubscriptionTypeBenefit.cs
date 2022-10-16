namespace FlashCards.Api.Core.SubscriptionTypes;

public class SubscriptionTypeBenefit
{
    public const int BenefitMaxLength = 1000;

    public int ID { get; private set; }
    public int SubsriptionTypeID { get; private set; }
    public string Benefit { get; private set; }
    public virtual SubscriptionType? SubsriptionType { get; private set; }

    public SubscriptionTypeBenefit(string benefit)
    {
        Benefit = benefit;
    }

    public SubscriptionTypeBenefit(
        int id, 
        int subsriptionTypeID, 
        string benefit)
    {
        ID = id;
        SubsriptionTypeID = subsriptionTypeID;
        Benefit = benefit;
    }

    public void Edit(string benefit)
    {
        Benefit = benefit;
    }
}
