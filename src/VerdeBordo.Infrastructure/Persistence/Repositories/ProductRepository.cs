using Microsoft.EntityFrameworkCore;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly VerdeBordoDbContext _dbContext;

        public ProductRepository(VerdeBordoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products
                .Where(x => x.IsActive)
                .Include(x => x.Supplier)
                .ToListAsync();
        }

        public async Task<List<Product>> GetBySupplierAsync(Guid supplierId)
        {
            return await _dbContext.Products
                    .Where(x => x.IsActive && x.SupplierId == supplierId)
                    .ToListAsync();
        }
    }
}
