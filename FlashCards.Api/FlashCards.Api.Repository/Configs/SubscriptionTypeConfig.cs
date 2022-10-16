using FlashCards.Api.Core.SubscriptionTypes;

namespace FlashCards.Api.Repository.Configs;

public class SubscriptionTypeConfig : IEntityTypeConfiguration<SubscriptionType>
{
    public void Configure(EntityTypeBuilder<SubscriptionType> builder)
    {
        builder
            .ToTable("subscription_types");

        builder
            .HasKey(x => x.ID)
            .HasName("pk_subscription_type_id");

        builder
            .Property(x => x.ID)
            .HasColumnName("subscription_type_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(SubscriptionType.NameMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Price)
            .HasColumnName("price")
            .HasColumnType("smallmoney");

        builder
            .HasMany(x => x.Benefits)
            .WithOne(x => x.SubsriptionType)
            .HasForeignKey(x => x.SubsriptionTypeID);

        builder.HasData(GetSubscritionTypes());
    }

    private SubscriptionType[] GetSubscritionTypes()
    {
        var result = new SubscriptionType[3];

        var lastBenefitID = 0;
        result[0] = GenerateSubscriptionType(
            id: -1, 
            name: "Plano Free", 
            price: null, 
            benefitsCount: 3,
            lastBenefitID: ref lastBenefitID);

        result[1] = GenerateSubscriptionType(
            id: -2,
            name: "Plano Essencial",
            price: 9.99,
            benefitsCount: 4,
            lastBenefitID: ref lastBenefitID);

        result[2] = GenerateSubscriptionType(
            id: -3,
            name: "Plano Premium",
            price: 29.99,
            benefitsCount: 6,
            lastBenefitID: ref lastBenefitID);

        return result;
    }

    private SubscriptionType GenerateSubscriptionType(
        int id, 
        string name,
        double? price,
        int benefitsCount,
        ref int lastBenefitID)
    {
        var subscriptionType = new SubscriptionType(
            id: id,
            name: name,
            price: price);

        //for (var i = 0; i < benefitsCount; i++)
        //{
        //    lastBenefitID -= 1;

        //    var benefit = new SubscriptionTypeBenefit(
        //        id: lastBenefitID, 
        //        subsriptionTypeID: id,
        //        benefit: "Lorem ipsum is simply dummy");

        //    subscriptionType.AddBenefit(benefit);
        //}

        return subscriptionType;
    }
}
