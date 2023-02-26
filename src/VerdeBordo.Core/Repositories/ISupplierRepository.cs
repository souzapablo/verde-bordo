using System.Linq.Expressions;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories.Shared;

namespace VerdeBordo.Core.Repositories;

public interface ISupplierRepository : IBaseRepository<Supplier>
{
    Task<List<Supplier>> GetByUserIdAsync(Guid userId, params Expression<Func<Supplier, object?>>[]? includes);
}
