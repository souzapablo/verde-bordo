using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;
using VerdeBordo.Core.Repositories.Shared;
using VerdeBordo.Infrastructure.Persistence.Repositories.Shared;

namespace VerdeBordo.Infrastructure.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(VerdeBordoDbContext context) : base(context) { }

    public async Task<List<Product>> GetBySupplierIdAsync(Guid supplierId, params Expression<Func<Product, object?>>[]? includes)
    {
        var query = Context.Set<Product>().AsQueryable();

        if (includes is not null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));
       
        return await query.Where(x => x.IsActive && x.SupplierId == supplierId)
                .ToListAsync();
    }
}
