namespace FlashCards.App.Models.SubscriptionTypes
{
    public class SubscriptionTypeBenefit
    {
        public int ID { get; private set; }
        public string Benefit { get; private set; }

        public SubscriptionTypeBenefit(int id, string benefit)
        {
            ID = id;
            Benefit = benefit;
        }
    }
}
