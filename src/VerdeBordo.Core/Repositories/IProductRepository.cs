using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetBySupplierAsync(Guid supplierId);
    }
}
