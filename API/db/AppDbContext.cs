namespace API.db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<FileEntity> Files => Set<FileEntity>();
    public DbSet<PageEntity> Pages => Set<PageEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileEntity>(entity =>
        {
            entity.ToTable("Files");
            entity.HasKey(f => f.Id);

            entity.Property(f => f.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(f => f.Name)
                  .IsRequired()
                  .HasMaxLength(255);

            entity.HasIndex(f => f.Name)
                  .IsUnique();
        });

        modelBuilder.Entity<PageEntity>(entity =>
        {
            entity.ToTable("Pages");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(p => p.Name)
                  .IsRequired()
                  .HasMaxLength(255);

            entity.HasIndex(p => p.Name)
                  .IsUnique();
        });

        base.OnModelCreating(modelBuilder);
    }
}