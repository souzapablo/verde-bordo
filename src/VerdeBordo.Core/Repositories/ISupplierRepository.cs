using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(Guid id);
        Task CreateSupplierAsync(Supplier supplier);
        Task UpdateSupplier(Supplier supplier);
    }
}
