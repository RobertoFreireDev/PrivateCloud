namespace API.db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<FileEntity> Files { get; set; }
    public DbSet<PageEntity> Pages { get; set; }
}