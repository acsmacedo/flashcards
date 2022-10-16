using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Repository.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("users");

        builder
            .HasKey(x => x.ID)
            .HasName("pk_user_id");

        builder
            .Property(x => x.ID)
            .HasColumnName("user_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.AccountID)
            .HasColumnName("account_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(User.NameMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Instagram)
            .HasColumnName("instagram")
            .HasColumnType("varchar")
            .HasMaxLength(User.InstagramMaxLength);

        builder
            .Property(x => x.Interests)
            .HasColumnName("interests")
            .HasColumnType("varchar")
            .HasMaxLength(User.InterestsMaxLength);

        builder
            .Property(x => x.Photo)
            .HasColumnName("photo")
            .HasColumnType("varchar")
            .HasMaxLength(User.PhotoMaxLength);

        builder
            .HasOne(x => x.Account)
            .WithOne()
            .HasForeignKey<User>(x => x.AccountID);

        builder
            .HasOne(x => x.SubscriptionType)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.SubscriptionTypeID);

        builder
            .HasMany(x => x.NotiicationSettings)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserID);

        builder.HasData(GetUsers());
    }

    private User[] GetUsers()
    {
        var result = new User[10];

        result[0] = GenerateUser(
            id: -1,
            name: "Anderson Macedo",
            email: "anderson@flashcard.com.br",
            password: "23011993");

        result[1] = GenerateUser(
            id: -2,
            name: "Maria Souza",
            email: "maria@flashcard.com.br",
            password: "23011993");

        result[2] = GenerateUser(
            id: -3,
            name: "Gustavo Oliveira",
            email: "gustavo@flashcard.com.br",
            password: "23011993");

        result[3] = GenerateUser(
            id: -4,
            name: "Paulo Pereira",
            email: "paulo@flashcard.com.br",
            password: "23011993");

        result[4] = GenerateUser(
            id: -5,
            name: "Ana Ferreira",
            email: "ana@flashcard.com.br",
            password: "23011993");

        result[5] = GenerateUser(
            id: -6,
            name: "Patrícia Castro",
            email: "patricia@flashcard.com.br",
            password: "23011993");

        result[6] = GenerateUser(
            id: -7,
            name: "Fernanda Albuquerque",
            email: "fernanda@flashcard.com.br",
            password: "23011993");

        result[7] = GenerateUser(
            id: -8,
            name: "Otávio Santos",
            email: "otavio@flashcard.com.br",
            password: "23011993");

        result[8] = GenerateUser(
            id: -9,
            name: "Bruno Gomes",
            email: "bruno@flashcard.com.br",
            password: "23011993");

        result[9] = GenerateUser(
            id: -10,
            name: "Usuário Teste",
            email: "teste@flashcard.com.br",
            password: "123456");

        return result;
    }

    private User GenerateUser(
        int id, 
        string name,
        string email,
        string password)
    {
        var user = new User(
            id: id,
            name: name);

        return user;
    }
}
