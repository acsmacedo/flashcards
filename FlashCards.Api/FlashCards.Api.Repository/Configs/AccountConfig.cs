using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Core.Users;

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

        builder.HasData(GetAccounts());
    }

    private Account[] GetAccounts()
    {
        var result = new Account[10];

        result[0] = GenerateAccount(
            id: -1,
            email: "anderson@flashcard.com.br",
            password: "23011993");

        result[1] = GenerateAccount(
            id: -2,
            email: "maria@flashcard.com.br",
            password: "23011993");

        result[2] = GenerateAccount(
            id: -3,
            email: "gustavo@flashcard.com.br",
            password: "23011993");

        result[3] = GenerateAccount(
            id: -4,
            email: "paulo@flashcard.com.br",
            password: "23011993");

        result[4] = GenerateAccount(
            id: -5,
            email: "ana@flashcard.com.br",
            password: "23011993");

        result[5] = GenerateAccount(
            id: -6,
            email: "patricia@flashcard.com.br",
            password: "23011993");

        result[6] = GenerateAccount(
            id: -7,
            email: "fernanda@flashcard.com.br",
            password: "23011993");

        result[7] = GenerateAccount(
            id: -8,
            email: "otavio@flashcard.com.br",
            password: "23011993");

        result[8] = GenerateAccount(
            id: -9,
            email: "bruno@flashcard.com.br",
            password: "23011993");

        result[9] = GenerateAccount(
            id: -10,
            email: "teste@flashcard.com.br",
            password: "123456");

        return result;
    }

    private Account GenerateAccount(
        int id,
        string email,
        string password)
    {
        var account = new Account(
            id: id,
            email: email,
            password: password);

        return account;
    }
}
