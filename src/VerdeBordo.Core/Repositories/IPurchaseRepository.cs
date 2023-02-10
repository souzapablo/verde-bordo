using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories;

public interface IPurchaseRepository
{
    Task<List<Purchase>> GetAllAsync();
}
