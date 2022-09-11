using Microsoft.EntityFrameworkCore.Design;

namespace FlashCards.Api.Repository;

public class ApplicationDbContextFactory
    : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    private const string ConnectionString
        = "Server=(localdb)\\mssqllocaldb;Database=flash_card_app;Trusted_Connection=True;MultipleActiveResultSets=true";

    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer(ConnectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
