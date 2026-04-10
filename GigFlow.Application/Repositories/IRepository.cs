using System.Linq.Expressions;

namespace GigFlow.Application.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();

    Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);

    Task SaveChangesAsync();
}