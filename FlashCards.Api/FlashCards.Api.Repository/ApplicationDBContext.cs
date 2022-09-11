using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Core.Categories;
using FlashCards.Api.Core.Denunciations;
using FlashCards.Api.Core.Directories;
using FlashCards.Api.Core.FlashCards;
using FlashCards.Api.Core.Notifications;
using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Repository;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    #nullable disable
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    //public DbSet<Denunciation> Denunciations { get; set; }
    //public DbSet<UserDirectory> Directories { get; set; }
    //public DbSet<FlashCardCollection> FlashCards { get; set; }
    //public DbSet<Notification> Notifications { get; set; }
    //public DbSet<User> Users { get; set; }
    #nullable enable

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfig());
        modelBuilder.ApplyConfiguration(new CategoryConfig());
        //modelBuilder.ApplyConfiguration(new DenunciationConfig());
        //modelBuilder.ApplyConfiguration(new UserDirectoryConfig());
        //modelBuilder.ApplyConfiguration(new FlashCardCollectionConfig());
        //modelBuilder.ApplyConfiguration(new FlashCardItemConfig());
        //modelBuilder.ApplyConfiguration(new FlashCardRatingConfig());
        //modelBuilder.ApplyConfiguration(new FlashCardTagConfig());
        //modelBuilder.ApplyConfiguration(new NotificationConfig());
        //modelBuilder.ApplyConfiguration(new UserConfig());
    }
}
