namespace API.db.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> CreateAsync(T entity)
    {
        entity.Id = Guid.NewGuid();
        entity.CreatedOn = DateTime.UtcNow;
        entity.LastModifiedOn = DateTime.UtcNow;

        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var existingEntity = await _dbSet.FindAsync(entity.Id);
        if (existingEntity == null)
        {
            throw new KeyNotFoundException($"Entity with Id {entity.Id} not found.");
        }

        entity.LastModifiedOn = DateTime.UtcNow;
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);

        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
}