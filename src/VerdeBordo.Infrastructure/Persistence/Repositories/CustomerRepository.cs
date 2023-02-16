using Microsoft.EntityFrameworkCore;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Infrastructure.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly VerdeBordoDbContext _dbContext;

    public CustomerRepository(VerdeBordoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _dbContext.Customers.Where(x => x.IsActive)
            .ToListAsync();
    }
}
