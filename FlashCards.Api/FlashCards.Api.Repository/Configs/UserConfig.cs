using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Repository.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
    }
}
