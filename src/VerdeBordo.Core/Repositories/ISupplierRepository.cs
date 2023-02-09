using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetSuppliersAsync();
    }
}
