using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace FlashCards.Api.Repository;

public class ApplicationDbContextFactory
    : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    private const string ConnectionString
        = "Server=(localdb)\\mssqllocaldb;Database=flash_card_app;Trusted_Connection=True;MultipleActiveResultSets=true";

    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder
            .UseSqlServer(ConnectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
