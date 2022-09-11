using FlashCards.Api.Core.Accounts;

namespace FlashCards.Api.Repository.Configs;

public class AccountConfig : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .ToTable("accounts");

        builder
            .HasKey(x => x.ID)
            .HasName("pk_account_id");

        builder
            .Property(x => x.ID)
            .HasColumnName("account_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(Account.EmailMaxlength)
            .IsRequired();

        builder
            .Property(x => x.Password)
            .HasColumnName("password")
            .HasColumnType("varchar")
            .HasMaxLength(Account.PasswordMaxlength);
    }
}
