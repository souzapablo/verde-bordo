using System.Linq.Expressions;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories.Shared;

namespace VerdeBordo.Core.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<List<Product>> GetBySupplierIdAsync(Guid supplierId, params Expression<Func<Product, object?>>[]? includes);
}
