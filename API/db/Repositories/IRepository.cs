namespace API.db.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> CreateAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> DeleteByNameAsync(string name);    
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}