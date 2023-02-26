using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories.Shared;

namespace VerdeBordo.Infrastructure.Persistence.Repositories.Shared;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly VerdeBordoDbContext Context;

    protected BaseRepository(VerdeBordoDbContext context)
    {
        Context = context;
    }
    
    public async Task<List<T>> GetAllAsync(params Expression<Func<T, object?>>[]? includes)
    {
        var query = Context.Set<T>().AsQueryable();

        if (includes is not null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.Where(x => x.IsActive).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object?>>[]? includes)
    {
        var query = Context.Set<T>().AsQueryable();

        if (includes is not null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.Where(x => x.Id.Equals(id)).SingleOrDefaultAsync();
    }

    public async Task CreateAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);

        await Context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync();
    }
}