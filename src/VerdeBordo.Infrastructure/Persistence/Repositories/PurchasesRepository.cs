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
            .Include(x => x.Product)
            .ToListAsync();
    }

    public async Task<Purchase?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Purchases
            .Include(x => x.Product)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Purchase purchase)
    {
        await _dbContext.Purchases.AddAsync(purchase);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Purchase purchase)
    {
        _dbContext.Purchases.Update(purchase);

        await _dbContext.SaveChangesAsync();
    }
}
