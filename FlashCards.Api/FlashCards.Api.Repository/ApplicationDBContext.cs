using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Core.Categories;
using FlashCards.Api.Core.Denunciations;
using FlashCards.Api.Core.Directories;
using FlashCards.Api.Core.FlashCards;
using FlashCards.Api.Core.Notifications;
using FlashCards.Api.Core.NotificationSettings;
using FlashCards.Api.Core.SubscriptionTypes;
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
    public DbSet<User> Users { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationSetting> NotificationSettings { get; set; }
    public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
    public DbSet<Denunciation> Denunciations { get; set; }
    public DbSet<UserDirectory> Directories { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FlashCardCollection> FlashCards { get; set; }
    #nullable enable

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfig());
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new UserRelationshipConfig());
        modelBuilder.ApplyConfiguration(new NotificationConfig());
        modelBuilder.ApplyConfiguration(new NotificationSettingConfig());
        modelBuilder.ApplyConfiguration(new UserNotificationSettingConfig());
        modelBuilder.ApplyConfiguration(new SubscriptionTypeConfig());
        modelBuilder.ApplyConfiguration(new SubscriptionTypeBenefitConfig());
        modelBuilder.ApplyConfiguration(new DenunciationConfig());
        modelBuilder.ApplyConfiguration(new UserDirectoryConfig());
        modelBuilder.ApplyConfiguration(new CategoryConfig());
        modelBuilder.ApplyConfiguration(new FlashCardCollectionConfig());
        modelBuilder.ApplyConfiguration(new FlashCardItemConfig());
        modelBuilder.ApplyConfiguration(new FlashCardRatingConfig());
        modelBuilder.ApplyConfiguration(new FlashCardTagConfig());
    }
}
