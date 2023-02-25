using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();
    Task<List<Customer>> GetByUserIdAsync(Guid userId);
    Task<Customer?> GetByIdAsync(Guid id);
    Task CreateAsync(Customer customer);
    Task UpdateAsync(Customer customer);
} 
