using Microsoft.EntityFrameworkCore;

namespace FlashCards.Api.Service.Tests;

public class ApplicationDbContextFactory
{
    private const string ConnectionString
        = "Server=(localdb)\\mssqllocaldb;Database=flash_card_app;Trusted_Connection=True;MultipleActiveResultSets=true";

    public ApplicationDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;

        return new ApplicationDbContext(options);
    }
}
