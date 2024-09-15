using Microsoft.EntityFrameworkCore;

namespace Maps;

public class ApplicationContext : DbContext
{
    public ApplicationContext() => Database.EnsureCreated();

    private DbSet<Category> Categories => Set<Category>();
    private DbSet<Establishment> Establishments => Set<Establishment>();
    private DbSet<Tag> Tags => Set<Tag>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; DataBase=MapsApi; Trusted_Connection=true");
    }
}