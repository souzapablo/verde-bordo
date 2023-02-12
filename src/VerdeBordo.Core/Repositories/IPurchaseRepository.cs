using VerdeBordo.Application.DTOs.Reports;
using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories;

public interface IPurchaseRepository
{
    Task<List<Purchase>> GetAllAsync();
    Task<Purchase?> GetByIdAsync(Guid id);
    Task CreateAsync(Purchase purchase);
    Task UpdateAsync(Purchase purchase);
    Task<IEnumerable<PurchaseReportDTO>> GetReportData();
}
