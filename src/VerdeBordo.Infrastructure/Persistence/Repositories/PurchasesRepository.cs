using System.Linq.Expressions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VerdeBordo.Application.DTOs.Reports;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;
using VerdeBordo.Infrastructure.Persistence.Repositories.Shared;

namespace VerdeBordo.Infrastructure.Persistence.Repositories;

public class PurchasesRepository : BaseRepository<Purchase>, IPurchaseRepository
{
    private readonly string _connectionString;

    public PurchasesRepository(VerdeBordoDbContext context, IConfiguration configuration) : base(context)
    {
        _connectionString = configuration.GetConnectionString("VerdeBordoCs")!;
    }

    public async Task<List<Purchase>> GetByUserIdAsync(Guid userId, params Expression<Func<Purchase, object?>>[]? includes)
    {
        var query = Context.Set<Purchase>().AsQueryable();

        if (includes is not null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));
       
        return await query.Where(x => x.IsActive && x.UserId == userId)
                .ToListAsync();
    }

    public async Task<IEnumerable<PurchaseReportDTO>> GetReportData()
    {
        using var sqlConnection = new SqlConnection(_connectionString);

        sqlConnection.Open();

        var script = @"SELECT purchase.PurchaseDate, product.Description, purchase.PurchasedAmount, product.Price, purchase.Shipment, supplier.Name 
                        FROM Purchases purchase
                        JOIN Products product
                        ON purchase.ProductId  = product.Id
                        JOIN Suppliers supplier
                        ON product.SupplierId = supplier.Id
                        ";

        return await sqlConnection.QueryAsync<PurchaseReportDTO>(script);
    }
}
