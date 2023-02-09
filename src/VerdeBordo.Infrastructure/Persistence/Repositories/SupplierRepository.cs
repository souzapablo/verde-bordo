using Microsoft.EntityFrameworkCore;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Infrastructure.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly VerdeBordoDbContext _dbContext;

        public SupplierRepository(VerdeBordoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Supplier>> GetSuppliersAsync()
        {
            return await _dbContext.Suppliers.Where(s => s.IsActive)
                .Include(s => s.Products)
                .ToListAsync();
        }
    }
}
