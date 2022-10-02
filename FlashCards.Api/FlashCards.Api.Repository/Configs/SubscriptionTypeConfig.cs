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
    }
}
