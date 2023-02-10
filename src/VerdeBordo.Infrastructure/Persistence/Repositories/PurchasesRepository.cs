using Microsoft.EntityFrameworkCore;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Infrastructure.Persistence.Repositories;

public class PurchasesRepository : IPurchaseRepository
{
    private readonly VerdeBordoDbContext _dbContext;

    public PurchasesRepository(VerdeBordoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Purchase>> GetAllAsync()
    {
        return await _dbContext.Purchases
            .Where(x => x.IsActive)
            .ToListAsync();
    }

    public async Task<Purchase?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Purchases
            .Include(x => x.Product)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}
