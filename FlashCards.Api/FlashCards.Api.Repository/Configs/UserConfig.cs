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
            name: "Anderson Macedo");

        result[1] = GenerateUser(
            id: -2,
            name: "Maria Souza");

        result[2] = GenerateUser(
            id: -3,
            name: "Gustavo Oliveira");

        result[3] = GenerateUser(
            id: -4,
            name: "Paulo Pereira");

        result[4] = GenerateUser(
            id: -5,
            name: "Aldo Ferreira");

        result[5] = GenerateUser(
            id: -6,
            name: "Patrícia Castro");

        result[6] = GenerateUser(
            id: -7,
            name: "Fernanda Albuquerque");

        result[7] = GenerateUser(
            id: -8,
            name: "Otávio Santos");

        result[8] = GenerateUser(
            id: -9,
            name: "Bruno Gomes");

        result[9] = GenerateUser(
            id: -10,
            name: "Usuário Teste");

        return result;
    }

    private User GenerateUser(
        int id, 
        string name)
    {
        var user = new User(
            id: id,
            name: name);

        user.UpdatePhoto($@"http://acsmacedo.somee.com/images/photos/photo-{id}.jpg");

        return user;
    }
}
