using System.Linq.Expressions;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories.Shared;

namespace VerdeBordo.Core.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    Task<List<Customer>> GetByUserIdAsync(Guid id, params Expression<Func<Customer, object?>>[]? includes);
} 
