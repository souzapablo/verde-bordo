using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<List<Product>> GetBySupplierIdAsync(Guid supplierId);
    Task<Product?> GetByIdAsync(Guid id);
    Task CreateAsync(Product product);
    Task UpdateAsync(Product product);
}
