using GoogleRankTracker.Server;
using Microsoft.EntityFrameworkCore;

class GoogleSearchResultDb : DbContext
{
    public GoogleSearchResultDb(DbContextOptions<GoogleSearchResultDb> options)
        : base(options) { }

    public DbSet<GoogleSearchResult> GoogleSearchResults => Set<GoogleSearchResult>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GoogleSearchResult>()
            .Property(b => b.Id)
            .ValueGeneratedOnAdd();
    }
}
