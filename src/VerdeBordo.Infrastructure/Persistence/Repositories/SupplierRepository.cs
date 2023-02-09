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

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _dbContext.Suppliers.Where(s => s.IsActive)
                .Include(s => s.Products)
                .ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Suppliers
                .Include(s => s.Products)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateSupplierAsync(Supplier supplier)
        {
            await _dbContext.Suppliers.AddAsync(supplier);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
            _dbContext.Suppliers.Update(supplier);

            await _dbContext.SaveChangesAsync();
        }
    }
}
