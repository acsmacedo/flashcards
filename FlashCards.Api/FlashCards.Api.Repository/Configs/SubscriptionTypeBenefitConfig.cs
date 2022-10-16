using FlashCards.Api.Core.SubscriptionTypes;

namespace FlashCards.Api.Repository.Configs;

public class SubscriptionTypeBenefitConfig : IEntityTypeConfiguration<SubscriptionTypeBenefit>
{
    public void Configure(EntityTypeBuilder<SubscriptionTypeBenefit> builder)
    {
        builder
            .ToTable("subscription_type_benefits");

        builder
            .HasKey(x => x.ID)
            .HasName("pk_subscription_type_benefit_id");

        builder
            .Property(x => x.ID)
            .HasColumnName("subscription_type_benefit_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.SubsriptionTypeID)
            .HasColumnName("subscription_type_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.Benefit)
            .HasColumnName("benefit")
            .HasColumnType("varchar")
            .HasMaxLength(SubscriptionTypeBenefit.BenefitMaxLength)
            .IsRequired();

        builder.HasData(GetSubscriptionTypeBenefits());
    }

    private SubscriptionTypeBenefit[] GetSubscriptionTypeBenefits()
    {
        var result = new List<SubscriptionTypeBenefit>();

        var lastBenefitID = 0;
        
        result.AddRange(GenerateSubscriptionTypeBenefit(
            lastBenefitID: ref lastBenefitID,
            subscriptionTypeID: -1,
            benefitCount: 3));

        result.AddRange(GenerateSubscriptionTypeBenefit(
            lastBenefitID: ref lastBenefitID,
            subscriptionTypeID: -2,
            benefitCount: 4));

        result.AddRange(GenerateSubscriptionTypeBenefit(
            lastBenefitID: ref lastBenefitID,
            subscriptionTypeID: -3,
            benefitCount: 6));

        return result.ToArray();
    }

    private IEnumerable<SubscriptionTypeBenefit> GenerateSubscriptionTypeBenefit(
        ref int lastBenefitID,
        int subscriptionTypeID,
        int benefitCount)
    {
        var result = new List<SubscriptionTypeBenefit>();

        for (var i = 0; i < benefitCount; i++)
        {
            lastBenefitID -= 1;

            var benefit = new SubscriptionTypeBenefit(
                id: lastBenefitID,
                subsriptionTypeID: subscriptionTypeID,
                benefit: "Lorem ipsum is simply dummy");

            result.Add(benefit);
        }

        return result;
    }
}