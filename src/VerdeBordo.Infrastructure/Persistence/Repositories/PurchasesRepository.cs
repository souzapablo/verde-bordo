using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VerdeBordo.Application.DTOs.Reports;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Infrastructure.Persistence.Repositories;

public class PurchasesRepository : IPurchaseRepository
{
    private readonly VerdeBordoDbContext _dbContext;
    private readonly string _connectionString;

    public PurchasesRepository(VerdeBordoDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _connectionString = configuration.GetConnectionString("VerdeBordoCs")!;
    }
    
    public async Task<List<Purchase>> GetAllAsync()
    {
        return await _dbContext.Purchases
            .Where(x => x.IsActive)
            .Include(x => x.Product)
            .ToListAsync();
    }

    public async Task<List<Purchase>> GetByUserIdAsync(Guid userId)
    {
        return await _dbContext.Purchases
            .Where(x => x.IsActive && x.UserId == userId)
            .Include(x => x.Product)
            .ToListAsync();
    }

    public async Task<Purchase?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Purchases
            .Include(x => x.Product)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Purchase purchase)
    {
        await _dbContext.Purchases.AddAsync(purchase);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Purchase purchase)
    {
        _dbContext.Purchases.Update(purchase);

        await _dbContext.SaveChangesAsync();
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
