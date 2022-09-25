using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsSubscriptionPage : ContentPage
    {
        public SettingsSubscriptionPage()
        {
            InitializeComponent();
            _carousel.ItemsSource = new List<Subscription>()
            {
                new Subscription("Plano Free", "R$ 0,00", GenerateBenefits(3)),
                new Subscription("Plano Essencial", "R$ 9,99", GenerateBenefits(5)),
                new Subscription("Plano Premium", "R$ 29,99", GenerateBenefits(6)),
            };
        }

        private List<Benefit> GenerateBenefits(int qty)
        {
            var benefits = new List<Benefit>();
            for (var i = 0; i < qty; i++)
            {
                benefits.Add(new Benefit("The standard chunk of Lorem"));
            }

            return benefits;
        }
    }

    public class Subscription
    {
        public string Name { get; private set; }
        public string Price { get; private set; }
        public IReadOnlyCollection<Benefit> Benefits { get; private set; }

        public Subscription(string name, string price, List<Benefit> benefits)
        {
            Name = name;
            Price = price;
            Benefits = benefits;
        }
    }

    public class Benefit
    {
        public string BenefitName { get; private set; }

        public Benefit(string benefitName)
        {
            BenefitName = benefitName;
        }
    }
}