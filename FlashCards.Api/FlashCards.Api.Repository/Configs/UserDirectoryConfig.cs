using FlashCards.Api.Core.Directories;

namespace FlashCards.Api.Repository.Configs;

public class UserDirectoryConfig : IEntityTypeConfiguration<UserDirectory>
{
    public void Configure(EntityTypeBuilder<UserDirectory> builder)
    {
    }
}
