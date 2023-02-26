using System.Linq.Expressions;
using VerdeBordo.Application.DTOs.Reports;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories.Shared;

namespace VerdeBordo.Core.Repositories;

public interface IPurchaseRepository : IBaseRepository<Purchase>
{
    Task<List<Purchase>> GetByUserIdAsync(Guid userId, params Expression<Func<Purchase, object?>>[]? includes);
    Task<IEnumerable<PurchaseReportDTO>> GetReportData();
}
