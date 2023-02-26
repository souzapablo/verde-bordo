using System.Linq.Expressions;
using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories.Shared;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync(params Expression<Func<T, object?>>[]? includes);
    Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object?>>[]? includes);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
}