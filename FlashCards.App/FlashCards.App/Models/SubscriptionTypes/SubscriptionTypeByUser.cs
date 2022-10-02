using System.Collections.Generic;

namespace FlashCards.App.Models.SubscriptionTypes
{
    public class SubscriptionTypeByUser : BaseModel
    {
        public int SubscriptionTypeID { get; private set; }
        public int UserID { get; private set; }
        public string Name { get; private set; }
        public double? Price { get; private set; }
        public IEnumerable<SubscriptionTypeBenefit> Benefits { get; private set; }

        private bool _isSubscribed;
        public bool IsSubscribed
        {
            get => _isSubscribed;
            set
            {
                _isSubscribed = value;
                RaisePropertyChanged(nameof(IsSubscribed));
            }
        }

        private bool _isNotSubscribed;
        public bool IsNotSubscribed
        {
            get => _isNotSubscribed;
            set
            {
                _isNotSubscribed = value;
                RaisePropertyChanged(nameof(IsNotSubscribed));
            }
        }

        public SubscriptionTypeByUser(
            int subscriptionTypeID,
            int userID, 
            bool isSubscribed,
            string name, 
            double? price,
            IEnumerable<SubscriptionTypeBenefit> benefits)
        {
            SubscriptionTypeID = subscriptionTypeID;
            UserID = userID;
            IsSubscribed = isSubscribed;
            Name = name;
            Price = price;
            Benefits = benefits;
            IsNotSubscribed = !isSubscribed;
        }

        public void Change(bool isSubscribed)
        {
            IsSubscribed = isSubscribed;
            IsNotSubscribed = !isSubscribed;
        }
    }
}
