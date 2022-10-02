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
    }
}