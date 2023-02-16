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

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Customers
            .SingleOrDefaultAsync(x => x.Id == id && x.IsActive);
    }

    public async Task CreateAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        _dbContext.Customers.Update(customer);

        await _dbContext.SaveChangesAsync();
    }
}
