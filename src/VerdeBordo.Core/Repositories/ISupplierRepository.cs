using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories;

public interface ISupplierRepository
{
    Task<List<Supplier>> GetAllAsync();
    Task<List<Supplier>> GetByUserIdAsync(Guid userId);
    Task<Supplier?> GetByIdAsync(Guid id);
    Task CreateAsync(Supplier supplier);
    Task UpdateAsync(Supplier supplier);
}
