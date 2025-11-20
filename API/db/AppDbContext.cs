namespace API.db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<FileEntity> Files { get; set; }
    public DbSet<PageEntity> Pages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FileEntity>()
            .HasKey(f => f.Id);

        modelBuilder.Entity<FileEntity>()
            .HasIndex(f => f.Name)
            .IsUnique();

        modelBuilder.Entity<PageEntity>()
            .HasKey(f => f.Id);

        modelBuilder.Entity<PageEntity>()
            .HasIndex(f => f.Name)
            .IsUnique();
    }
}