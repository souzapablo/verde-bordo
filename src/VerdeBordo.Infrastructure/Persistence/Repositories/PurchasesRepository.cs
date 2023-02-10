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
}
