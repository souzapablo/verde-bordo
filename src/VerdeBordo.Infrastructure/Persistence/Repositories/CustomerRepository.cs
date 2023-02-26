using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;
using VerdeBordo.Infrastructure.Persistence.Repositories.Shared;

namespace VerdeBordo.Infrastructure.Persistence.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(VerdeBordoDbContext context) : base(context) { }
  
    public async Task<List<Customer>> GetByUserIdAsync(Guid userId, params Expression<Func<Customer, object?>>[]? includes)
    {
        var query = Context.Set<Customer>().AsQueryable();

        if (includes is not null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.Where(x => x.IsActive && x.UserId == userId)
            .ToListAsync();
    }
}
